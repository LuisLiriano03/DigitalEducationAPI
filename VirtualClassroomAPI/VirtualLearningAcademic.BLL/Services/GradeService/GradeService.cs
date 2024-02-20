using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.Grade;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Grade;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IGenericRepository<Grade> _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGenericRepository<Grade> gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetGradeDTO>> GetListGrade()
        {
            try
            {
                var gradeQuery = await _gradeRepository.ValidateDataExistence();
                var listGrade = gradeQuery
                   .Include(u => u.UserInformation)
                   .Include(c => c.Course)
                   .Include(a => a.Assignment)
                   .ToList();

                return _mapper.Map<List<GetGradeDTO>>(listGrade);
            }
            catch
            {
                throw;
            }
        }

        public async Task<GetGradeDTO> CreateGrade(CreateGradeDTO model)
        {
            try
            {
                var gradeCreated = await _gradeRepository.CreateData(_mapper.Map<Grade>(model));

                if (gradeCreated.UserInformationId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _gradeRepository.ValidateDataExistence(u =>
                    u.GradeId == gradeCreated.GradeId);

                var gradeWithDetails = query
                    .Include(u => u.UserInformation)
                    .Include(c => c.Course)
                    .Include(a => a.Assignment)
                    .First();

                return _mapper.Map<GetGradeDTO>(gradeWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateGrade(UpdateGradeDTO model)
        {
            try
            {
                var gradeModel = _mapper.Map<Grade>(model);

                var gradeFound = await _gradeRepository.GetDataDetails(c =>
                    c.GradeId == gradeModel.GradeId);

                if (gradeFound == null)
                    throw new TaskCanceledException("No existe");

                gradeFound.UserInformationId = gradeModel.UserInformationId;
                gradeFound.CourseId = gradeModel.CourseId;
                gradeFound.AssignmentId = gradeModel.AssignmentId;
                gradeFound.Score = gradeModel.Score;
                gradeFound.Comment = gradeModel.Comment;

                bool response = await _gradeRepository.UpdateData(gradeFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateGrade(int id)
        {
            try
            {
                var gradeFound = await _gradeRepository.GetDataDetails(g => g.GradeId == id);

                if (gradeFound == null)
                    throw new TaskCanceledException("La calificacion no existe");

                bool response = await _gradeRepository.RemoveData(gradeFound);

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