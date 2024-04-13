using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.BLL.Services.Realization;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyTrackSystem.BLL.Extensions
{
    public static class ServicesInjection
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
        }
    }
}
