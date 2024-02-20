using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.ForumPost;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.ForumPost;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.ForumPostService
{
    public class ForumPostService : IForumPostService
    {
        private readonly IGenericRepository<ForumPost> _forumPostRepository;
        private readonly IMapper _mapper;
        public ForumPostService(IGenericRepository<ForumPost> forumPostRepository, IMapper mapper)
        {
            _forumPostRepository = forumPostRepository;
            _mapper = mapper;
        }
        public async Task<List<GetForumPostDTO>> GetListForumPost()
        {
            try
            {
                var forumPostQuery = await _forumPostRepository.ValidateDataExistence();
                var listForumPost = forumPostQuery
                   .Include(f => f.Forum)
                   .Include(f => f.UserInformation)
                   .ToList();

                return _mapper.Map<List<GetForumPostDTO>>(listForumPost);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetForumPostDTO> CreateForumPost(CreateForumPostDTO model)
        {
            try
            {
                var forumPostCreated = await _forumPostRepository.CreateData(_mapper.Map<ForumPost>(model));

                if (forumPostCreated.UserInformationId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _forumPostRepository.ValidateDataExistence(u =>
                    u.ForumPostId == forumPostCreated.ForumPostId);

                var enrollmentWithDetails = query
                    .Include(f => f.Forum)
                    .Include(f => f.UserInformation)
                    .First();

                return _mapper.Map<GetForumPostDTO>(enrollmentWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateForumPost(UpdateForumPostDTO model)
        {
            try
            {
                var forumPostModel = _mapper.Map<ForumPost>(model);
                var forumPostFound = await _forumPostRepository.GetDataDetails(c =>
                    c.ForumPostId == forumPostModel.ForumPostId);

                if (forumPostFound == null)
                    throw new TaskCanceledException("No existe");

                forumPostFound.ForumId = forumPostModel.ForumId;
                forumPostFound.UserInformationId = forumPostModel.UserInformationId;
                forumPostFound.PostText = forumPostModel.PostText;

                bool response = await _forumPostRepository.UpdateData(forumPostFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateForumPost(int id)
        {
            try
            {
                var forumPostFound = await _forumPostRepository.GetDataDetails(c => c.ForumPostId == id);

                if (forumPostFound == null)
                    throw new TaskCanceledException("No existe");

                bool response = await _forumPostRepository.RemoveData(forumPostFound);

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