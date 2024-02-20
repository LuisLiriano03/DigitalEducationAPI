using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.StudentEnrollment;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.StudentEnrollment;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.EnrollmentService
{
    public class StudentEnrollmentService : IStudentEnrollmentService
    {
        private readonly IGenericRepository<StudentEnrollment> _enrollmentRepository;
        private readonly IMapper _mapper;

        public StudentEnrollmentService(IGenericRepository<StudentEnrollment> enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetStudentEnrollmentDTO>> GetListEnrollment()
        {
            try
            {
                var enrollmentQuery = await _enrollmentRepository.ValidateDataExistence();
                var listEnrollments = enrollmentQuery
                   .Include(e => e.UserInformation)
                   .Include(e => e.Course)
                   .ToList();

                return _mapper.Map<List<GetStudentEnrollmentDTO>>(listEnrollments);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetStudentEnrollmentDTO> CreateEnrollment(CreateStudentEnrollmentDTO model)
        {
            try
            {
                var enrollmentCreated = await _enrollmentRepository.CreateData(_mapper.Map<StudentEnrollment>(model));

                if (enrollmentCreated.UserInformationId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _enrollmentRepository.ValidateDataExistence(u =>
                    u.EnrollmentId == enrollmentCreated.EnrollmentId);

                var enrollmentWithDetails = query
                    .Include(e => e.UserInformation)
                    .Include(e => e.Course)
                    .First();

                return _mapper.Map<GetStudentEnrollmentDTO>(enrollmentWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateEnrollment(UpdateStudentEnrollmentDTO model)
        {
            try
            {
                var enrollmentModel = _mapper.Map<StudentEnrollment>(model);
                var enrollmentFound = await _enrollmentRepository.GetDataDetails(c =>
                    c.EnrollmentId == enrollmentModel.EnrollmentId);

                if (enrollmentFound == null)
                    throw new TaskCanceledException("El curso no existe");

                enrollmentFound.UserInformationId = enrollmentModel.UserInformationId;
                enrollmentFound.CourseId = enrollmentModel.CourseId;

                bool response = await _enrollmentRepository.UpdateData(enrollmentFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateEnrollment(int id)
        {
            try
            {
                var enrollmentFound = await _enrollmentRepository.GetDataDetails(e => e.EnrollmentId == id);

                if (enrollmentFound == null)
                    throw new TaskCanceledException("El curso no existe");

                bool response = await _enrollmentRepository.RemoveData(enrollmentFound);

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