using AutoMapper;
using VirtualLearningAcademic.DTO.Assignament;
using VirtualLearningAcademic.DTO.Communication;
using VirtualLearningAcademic.DTO.Course;
using VirtualLearningAcademic.DTO.Forum;
using VirtualLearningAcademic.DTO.ForumPost;
using VirtualLearningAcademic.DTO.Grade;
using VirtualLearningAcademic.DTO.Menu;
using VirtualLearningAcademic.DTO.Rol;
using VirtualLearningAcademic.DTO.SendEmail;
using VirtualLearningAcademic.DTO.StudentEnrollment;
using VirtualLearningAcademic.DTO.User;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.Utility.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
       {
            #region Assignment
            CreateMap<Assignment, GetAssignamentDTO>()
                .ForMember(destination =>
                    destination.DescriptionCourse,
                    options => options.MapFrom(origin => origin.Course.CourseName)
                 )
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 );

            CreateMap<GetAssignamentDTO, Assignment>()
                .ForMember(destination =>
                    destination.Course,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateAssignmentDTO
            CreateMap<Assignment, CreateAssignamentDTO>().ReverseMap();
            #endregion

            #region UpdateAssignmentDTO
            CreateMap<Assignment, UpdateAssignamentDTO>().ReverseMap();
            #endregion

            #region Communication
            CreateMap<Communication, GetCommunicationDTO>()
                .ForMember(destination =>
                    destination.DescriptionCourse,
                    options => options.MapFrom(origin => origin.Course.CourseName)
                 )
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 );

            CreateMap<GetCommunicationDTO, Communication>()
                .ForMember(destination =>
                    destination.Course,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateCommunicationDTO
            CreateMap<Communication, CreateCommunicationDTO>().ReverseMap();
            #endregion

            #region UpdateCommunicationDTO
            CreateMap<Communication, UpdateCommunicationDTO>().ReverseMap();
            #endregion

            #region Course
            CreateMap<Course, GetCourseDTO>()
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 );

            CreateMap<GetCourseDTO, Course>()
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateCourseDTO
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            #endregion

            #region UpdateCourseDTO
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            #endregion

            #region Forum
            CreateMap<Forum, GetForumDTO>()
                .ForMember(destination =>
                    destination.DescriptionCourse,
                    options => options.MapFrom(origin => origin.Course.CourseName)
                 )
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 );

            CreateMap<GetForumDTO, Forum>()
                .ForMember(destination =>
                    destination.Course,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateForumDTO
            CreateMap<Forum, CreateForumDTO>().ReverseMap();
            #endregion

            #region UpdateForumDTO
            CreateMap<Forum, UpdateForumDTO>().ReverseMap();
            #endregion

            #region ForumPost
            CreateMap<ForumPost, GetForumPostDTO>()
                .ForMember(destination =>
                    destination.DescriptionForum,
                    options => options.MapFrom(origin => origin.Forum.Descriptionforums)
                 )
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 );

            CreateMap<GetForumPostDTO, ForumPost>()
                .ForMember(destination =>
                    destination.Forum,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateForumPostDTO
            CreateMap<ForumPost, CreateForumPostDTO>().ReverseMap();
            #endregion

            #region UpdateForumPostDTO
            CreateMap<ForumPost, UpdateForumPostDTO>().ReverseMap();
            #endregion

            #region Grade
            CreateMap<Grade, GetGradeDTO>()
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 )
                .ForMember(destination =>
                    destination.DescriptionCourse,
                    options => options.MapFrom(origin => origin.Course.CourseName)
                 )
                .ForMember(destination =>
                    destination.DescriptionAssignment,
                    options => options.MapFrom(origin => origin.Assignment.AssignmentDescription)
                 );

            CreateMap<GetGradeDTO, Grade>()
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.Course,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.Assignment,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateGradeDTO
            CreateMap<Grade, CreateGradeDTO>().ReverseMap();
            #endregion

            #region UpdateGradeDTO
            CreateMap<Grade, UpdateGradeDTO>().ReverseMap();
            #endregion

            #region StudentEnrollment
            CreateMap<StudentEnrollment, GetStudentEnrollmentDTO>()
                .ForMember(destination =>
                    destination.DescriptionUser,
                    options => options.MapFrom(origin => origin.UserInformation.FullName)
                 )
                .ForMember(destination =>
                    destination.DescriptionCourse,
                    options => options.MapFrom(origin => origin.Course.CourseName)
                 );

            CreateMap<GetStudentEnrollmentDTO, StudentEnrollment>()
                .ForMember(destination =>
                    destination.UserInformation,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.Course,
                    options => options.Ignore()
                 );
            #endregion

            #region CreateStudentEnrollmentDTO
            CreateMap<StudentEnrollment, CreateStudentEnrollmentDTO>().ReverseMap();
            #endregion

            #region UpdateStudentEnrollmentDTO
            CreateMap<StudentEnrollment, UpdateStudentEnrollmentDTO>().ReverseMap();
            #endregion

            #region Menu
            CreateMap<Menu, GetMenuDTO>().ReverseMap();
            #endregion

            #region Rol
            CreateMap<Rol, GetRolDTO>().ReverseMap();
            #endregion

            #region User
            CreateMap<UserInformation, GetUserDTO>()
                .ForMember(destination =>
                destination.DescriptionRol,
                options => options.MapFrom(origin => origin.Rol.NameRol)
                )
                .ForMember(destination =>
                destination.IsActive,
                options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<GetUserDTO, UserInformation>()
               .ForMember(destination =>
                    destination.Rol,
                    options => options.Ignore()
               )
               .ForMember(destination =>
                   destination.IsActive,
                   options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
               );
            #endregion

            #region CreateUserDTO
            CreateMap<UserInformation, CreateUserDTO>().ReverseMap();
            #endregion

            #region UpdateUserDTO
            CreateMap<UserInformation, UpdateUserDTO>().ReverseMap();
            #endregion

            #region UsersSession
            CreateMap<UserInformation, SessionDTO>()
                .ForMember(destination =>
                destination.DescriptionRol,
                options => options.MapFrom(origin => origin.Rol.NameRol)
                );
            #endregion

       }

    }

}