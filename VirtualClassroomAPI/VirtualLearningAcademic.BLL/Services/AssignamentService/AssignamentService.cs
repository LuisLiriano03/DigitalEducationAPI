using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.Assignament;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Assignament;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.AssignamentService
{
    public class AssignamentService : IAssignamentService
    {
        private readonly IGenericRepository<Assignment> _assignmentRepository;
        private readonly IMapper _mapper;
        public AssignamentService(IGenericRepository<Assignment> assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAssignamentDTO>> GetListAssignament()
        {
            try
            {
                var assignamentQuery = await _assignmentRepository.ValidateDataExistence();
                var listAssignament = assignamentQuery
                   .Include(a => a.UserInformation)
                   .Include(a => a.Course)
                   .ToList();

                return _mapper.Map<List<GetAssignamentDTO>>(listAssignament);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetAssignamentDTO> CreateAssignament(CreateAssignamentDTO model)
        {
            try
            {
                var assignamentCreated = await _assignmentRepository.CreateData(_mapper.Map<Assignment>(model));

                if (assignamentCreated.CourseId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var assignamentQuery = await _assignmentRepository.ValidateDataExistence(u =>
                    u.AssignmentId == assignamentCreated.AssignmentId);

                var assignamentWithDetails = assignamentQuery
                    .Include(a => a.Course)
                    .Include(a => a.UserInformation)
                    .First();

                return _mapper.Map<GetAssignamentDTO>(assignamentWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateAssignament(UpdateAssignamentDTO model)
        {
            try
            {
                var assignamentModel = _mapper.Map<Assignment>(model);
                var assignamentFound = await _assignmentRepository.GetDataDetails(a =>
                    a.AssignmentId == assignamentModel.AssignmentId);

                if (assignamentFound == null)
                    throw new TaskCanceledException("El curso no existe");

                assignamentFound.CourseId = assignamentModel.CourseId;
                assignamentFound.Title = assignamentModel.Title;
                assignamentFound.AssignmentDescription = assignamentModel.AssignmentDescription;
                assignamentFound.DueDate = assignamentModel.DueDate;


                bool response = await _assignmentRepository.UpdateData(assignamentFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateAssignament(int id)
        {
            try
            {
                var assignamentFound = await _assignmentRepository.GetDataDetails(a => a.AssignmentId == id);

                if (assignamentFound == null)
                    throw new TaskCanceledException("El curso no existe");

                bool response = await _assignmentRepository.RemoveData(assignamentFound);

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