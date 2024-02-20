using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.Course;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Course;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCourseDTO>> GetListCourse()
        {
            try
            {
                var courseQuery = await _courseRepository.ValidateDataExistence();
                var listCourse = courseQuery.Include(c => c.UserInformation).ToList();

                return _mapper.Map<List<GetCourseDTO>>(listCourse);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetCourseDTO> CreateCourse(CreateCourseDTO model)
        {
            try
            {
                var courseCreated = await _courseRepository.CreateData(_mapper.Map<Course>(model));

                if (courseCreated.UserInformationId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _courseRepository.ValidateDataExistence(c =>
                    c.CourseId == courseCreated.CourseId);

                courseCreated = query.Include(u => u.UserInformation).First();

                return _mapper.Map<GetCourseDTO>(courseCreated);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateCourse(UpdateCourseDTO model)
        {
            try
            {
                var courseModel = _mapper.Map<Course>(model);

                var courseFound = await _courseRepository.GetDataDetails(c =>
                    c.CourseId == courseModel.CourseId);

                if (courseFound == null)
                    throw new TaskCanceledException("El curso no existe");

                courseFound.CourseName= courseModel.CourseName;
                courseFound.UserInformationId = courseModel.UserInformationId;

                bool response = await _courseRepository.UpdateData(courseFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateCourse(int id)
        {
            try
            {
                var courseFound = await _courseRepository.GetDataDetails(c => c.CourseId == id);

                if (courseFound == null)
                    throw new TaskCanceledException("El curso no existe");

                bool response = await _courseRepository.RemoveData(courseFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo eliminar");

                return response;
            }
            catch
            {
                throw;
            }

        }


    }

}