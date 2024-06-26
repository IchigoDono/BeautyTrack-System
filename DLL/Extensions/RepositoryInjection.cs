﻿using BeautyTrackSystem.DLL.Repositories.Interfaces;
using BeautyTrackSystem.DLL.Repositories.Realization;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyTrackSystem.DLL.Extensions
{
    public static class RepositoryInjection
    {
        public static void AddRepositoryInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentDescriptionRepository,  AppointmentDescriptionRepository>();
        }
    }
}