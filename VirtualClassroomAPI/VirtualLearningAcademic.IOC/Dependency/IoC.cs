using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualLearningAcademic.BLL.Services.AssignamentService;
using VirtualLearningAcademic.BLL.Services.CommunicationService;
using VirtualLearningAcademic.BLL.Services.Contracts.Assignament;
using VirtualLearningAcademic.BLL.Services.Contracts.Communication;
using VirtualLearningAcademic.BLL.Services.Contracts.Course;
using VirtualLearningAcademic.BLL.Services.Contracts.Email;
using VirtualLearningAcademic.BLL.Services.Contracts.Forum;
using VirtualLearningAcademic.BLL.Services.Contracts.ForumPost;
using VirtualLearningAcademic.BLL.Services.Contracts.Grade;
using VirtualLearningAcademic.BLL.Services.Contracts.Menu;
using VirtualLearningAcademic.BLL.Services.Contracts.Rol;
using VirtualLearningAcademic.BLL.Services.Contracts.StudentEnrollment;
using VirtualLearningAcademic.BLL.Services.Contracts.User;
using VirtualLearningAcademic.BLL.Services.CourseService;
using VirtualLearningAcademic.BLL.Services.EmailService;
using VirtualLearningAcademic.BLL.Services.EnrollmentService;
using VirtualLearningAcademic.BLL.Services.ForumPostService;
using VirtualLearningAcademic.BLL.Services.ForumService;
using VirtualLearningAcademic.BLL.Services.GradeService;
using VirtualLearningAcademic.BLL.Services.MenuService;
using VirtualLearningAcademic.BLL.Services.RolService;
using VirtualLearningAcademic.BLL.Services.UserService;
using VirtualLearningAcademic.DAL.Context.DBContext;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DAL.Repository.Repositorys;
using VirtualLearningAcademic.Utility.AutoMapper;

namespace VirtualLearningAcademic.IOC.Dependency
{
    public static class IoC
    {
        public static void DependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbdigitalEducationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnectDB"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuServices, MenuService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentEnrollmentService, StudentEnrollmentService>();
            services.AddScoped<IAssignamentService, AssignamentService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<ICommunicationService, CommunicationService>();
            services.AddScoped<IForumPostService, ForumPostService>();
            services.AddScoped<IEmailService, EmailService>();

        }

    }

}