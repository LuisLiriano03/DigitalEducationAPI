using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.Forum;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Forum;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.ForumService
{
    public class ForumService : IForumService
    {
        private readonly IGenericRepository<Forum> _forumRepository;
        private readonly IMapper _mapper;

        public ForumService(IGenericRepository<Forum> forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;
        }

        public async Task<List<GetForumDTO>> GetListForum()
        {
            try
            {
                var forumQuery = await _forumRepository.ValidateDataExistence();
                var listForum = forumQuery
                   .Include(f => f.Course)
                   .Include(f => f.UserInformation)
                   .ToList();

                return _mapper.Map<List<GetForumDTO>>(listForum);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetForumDTO> CreateForum(CreateForumDTO model)
        {
            try
            {
                var forumCreated = await _forumRepository.CreateData(_mapper.Map<Forum>(model));

                if (forumCreated.CourseId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _forumRepository.ValidateDataExistence(u =>
                    u.ForumId == forumCreated.ForumId);

                var forumWithDetails = query
                    .Include(f => f.Course)
                    .Include(f => f.UserInformation)
                    .First();

                return _mapper.Map<GetForumDTO>(forumWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateForum(UpdateForumDTO model)
        {
            try
            {
                var forumModel = _mapper.Map<Forum>(model);

                var forumFound = await _forumRepository.GetDataDetails(c =>
                    c.ForumId == forumModel.ForumId);

                if (forumFound == null)
                    throw new TaskCanceledException("El curso no existe");

                forumFound.CourseId = forumModel.CourseId;
                forumFound.Title = forumModel.Title;
                forumFound.Descriptionforums = forumModel.Descriptionforums;
                forumFound.UserInformationId = forumModel.UserInformationId;

                bool response = await _forumRepository.UpdateData(forumFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateForum(int id)
        {
            try
            {
                var forumFound = await _forumRepository.GetDataDetails(f => f.ForumId == id);

                if (forumFound == null)
                    throw new TaskCanceledException("No existe");

                bool response = await _forumRepository.RemoveData(forumFound);

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