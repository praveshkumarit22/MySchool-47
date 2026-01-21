using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Attendance.Interfaces;
using SchoolERP.Application.Common.Contracts;
using SchoolERP.Application.Common.Interfaces;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Interfaces;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Infrastructure.Academics.Services;
using SchoolERP.Infrastructure.Attendance;
using SchoolERP.Infrastructure.Auth;
using SchoolERP.Infrastructure.Common;
using SchoolERP.Infrastructure.Data;
using SchoolERP.Infrastructure.Exams;
using SchoolERP.Infrastructure.Identity;
using SchoolERP.Infrastructure.Identity.Security;
using SchoolERP.Infrastructure.Identity.Services;
using SchoolERP.Infrastructure.Repositories;
using SchoolERP.Infrastructure.Students.Services;

namespace SchoolERP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SchoolDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITenantContext, TenantContext>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, SchoolDbContext>();
         
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddScoped<PasswordHasher>();
        services.AddScoped<JwtTokenService>();
         
        services.AddScoped<IJwtService, JwtService>(); 
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddHttpContextAccessor();

        services.AddScoped<ICurrentUser, CurrentUser>();

        services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddScoped<IMenuService, MenuService>();

        services.AddScoped<IStudentAdmissionService, StudentAdmissionService>();

        services.AddScoped<IStudentEnrollmentService, StudentEnrollmentService>();
        services.AddScoped<IStudentPromotionService, StudentPromotionService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IExamService, ExamService>();

        // Exam Paper Related Services
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IPaperBuilderService, PaperBuilderService>();

       
        services.AddScoped<IAcademicMasterService, AcademicMasterService>();

        services.AddScoped<IStudentAdmissionService, StudentAdmissionService>();
        services.AddScoped<IStudentEnrollmentService, StudentEnrollmentService>();
        services.AddScoped<IStudentPromotionService, StudentPromotionService>();



        // Excel
       
        return services;
    }


    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Later: validators, mediators, behaviors, etc.
        return services;
    }

}
