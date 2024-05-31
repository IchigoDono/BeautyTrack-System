using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.IO;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IPatientRepository _patientRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IProcedureRepository procedureRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _procedureRepository = procedureRepository;
            _patientRepository = patientRepository;
        }

        public async Task<ServiceResponse<AppointmentAddDTO>> AddAppointment(AppointmentAddDTO appointmentModel)
        {
            ServiceResponse<AppointmentAddDTO> serviceResponse = new ServiceResponse<AppointmentAddDTO>();

            Client patientEntityModel = await _patientRepository.GetById(appointmentModel.PatientId);

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Patient is not exist";
                return serviceResponse;
            }

            Procedure procedureEntityModel = await _procedureRepository.GetById(appointmentModel.ProcedureId);

            if (procedureEntityModel == null)
            {
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }
            appointmentModel.Price = procedureEntityModel.Price;
            Appointment appointmentEntityModel = AppointmentMapper.GetAppointmentAddModel(appointmentModel);

            await _appointmentRepository.AddAppointment(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentAddDTO>> UpdateProcedure(AppointmentAddDTO appointmentModel)
        {
            ServiceResponse<AppointmentAddDTO> serviceResponse = new ServiceResponse<AppointmentAddDTO>();

            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(appointmentModel.Id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }
            Client patientEntityModel = await _patientRepository.GetById(appointmentModel.PatientId);

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Patient is not exist";
                return serviceResponse;
            }

            Procedure procedureEntityModel = await _procedureRepository.GetById(appointmentModel.ProcedureId);

            if (procedureEntityModel == null)
            {
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }
            appointmentModel.Price = procedureEntityModel.Price;

            Appointment appointmentEntityModel = AppointmentMapper.GetAppointmentUpdateModel(appointmentModel);

            await _appointmentRepository.UpdateAppointment(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentByPatient(Int32 id)
        {
            ServiceResponse<List<AppointmentGetDTO>> serviceResponse = new ServiceResponse<List<AppointmentGetDTO>>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetByPatientId(id);

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentList()
        {
            ServiceResponse<List<AppointmentGetDTO>> serviceResponse = new ServiceResponse<List<AppointmentGetDTO>>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetAll();

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentListByDate(DateTime appointmentDate)
        {
            ServiceResponse<List<AppointmentGetDTO>> serviceResponse = new ServiceResponse<List<AppointmentGetDTO>>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetByDate(appointmentDate);

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<MemoryStream>> GetReport(DateTime appointmentDate)
        {
            ServiceResponse<MemoryStream> serviceResponse = new ServiceResponse<MemoryStream>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetByDate(appointmentDate);
            List<AppointmentGetDTO> appointmentGetDTO = new List<AppointmentGetDTO>();

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            appointmentGetDTO = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            using (MemoryStream stream = new MemoryStream())
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    Worksheet worksheet = new Worksheet();
                    SheetData sheetData = new SheetData();

                    Row headerRow = new Row();
                    headerRow.Append(
                        new Cell { CellValue = new CellValue("Дата"), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue("ПІБ"), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue("Назва процедури"), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue("Ціна"), DataType = CellValues.String }
                    );
                    sheetData.AppendChild(headerRow);

                    foreach (var appointment in appointmentGetDTO)
                    {
                        Row dataRow = new Row();
                        dataRow.Append(
                            new Cell { CellValue = new CellValue(appointment.Date), DataType = CellValues.String },
                            new Cell { CellValue = new CellValue(appointment.FullName), DataType = CellValues.String },
                            new Cell { CellValue = new CellValue(appointment.ProcedureName), DataType = CellValues.String },
                            new Cell { CellValue = new CellValue(appointment.Price), DataType = CellValues.String }
                        );
                        sheetData.AppendChild(dataRow);
                    }

                    worksheet.AppendChild(sheetData);
                    worksheetPart.Worksheet = worksheet;

                    sheets.Append(new Sheet
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Appointments"
                    });

                    workbookPart.Workbook.Save();
                }

                stream.Position = 0;
                serviceResponse.Data = stream;
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Appointments retrieved and Excel file created successfully";

                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<Boolean>> DeleteProcedure(Int32 id)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();
            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }

            Appointment appointmentEntityModel = new Appointment();
            appointmentEntityModel = await _appointmentRepository.GetById(id);

            await _appointmentRepository.Delete(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }
    }
}
