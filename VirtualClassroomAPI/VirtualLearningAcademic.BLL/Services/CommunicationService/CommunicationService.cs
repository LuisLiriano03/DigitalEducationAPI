using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.BLL.Services.Contracts.Communication;
using VirtualLearningAcademic.DAL.Repository.Contracts;
using VirtualLearningAcademic.DTO.Communication;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.BLL.Services.CommunicationService
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IGenericRepository<Communication> _communicationRepository;
        private readonly IMapper _mapper;

        public CommunicationService(IGenericRepository<Communication> communicationRepository, IMapper mapper)
        {
            _communicationRepository = communicationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCommunicationDTO>> GetListCommunication()
        {
            try
            {
                var communicationQuery = await _communicationRepository.ValidateDataExistence();
                var listCommunication = communicationQuery
                   .Include(c => c.Course)
                   .Include(c => c.UserInformation)
                   .ToList();

                return _mapper.Map<List<GetCommunicationDTO>>(listCommunication);
            }
            catch
            {
                throw;
            }

        }

        public async Task<GetCommunicationDTO> CreateCommunication(CreateCommunicationDTO model)
        {
            try
            {
                var communicationCreated = await _communicationRepository.CreateData(_mapper.Map<Communication>(model));

                if (communicationCreated.CourseId == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _communicationRepository.ValidateDataExistence(u =>
                    u.CommunicationId == communicationCreated.CommunicationId);

                var communicationWithDetails = query
                    .Include(c => c.Course)
                    .Include(c => c.UserInformation)
                    .First();

                return _mapper.Map<GetCommunicationDTO>(communicationWithDetails);

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateCommunication(UpdateCommunicationDTO model)
        {
            try
            {
                var communicationModel = _mapper.Map<Communication>(model);

                var communicationFound = await _communicationRepository.GetDataDetails(c =>
                    c.CommunicationId == communicationModel.CommunicationId);

                if (communicationFound == null)
                    throw new TaskCanceledException("El curso no existe");

                communicationFound.CourseId = communicationModel.CourseId;
                communicationFound.UserInformationId = communicationModel.UserInformationId;
                communicationFound.MessageCommunicactions = communicationModel.MessageCommunicactions;

                bool response = await _communicationRepository.UpdateData(communicationFound);

                if (!response)
                    throw new TaskCanceledException("No se pudo editar");

                return response;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> EliminateCommunication(int id)
        {
            try
            {
                var communicationFound = await _communicationRepository.GetDataDetails(c => c.CommunicationId == id);

                if (communicationFound == null)
                    throw new TaskCanceledException("El curso no existe");

                bool response = await _communicationRepository.RemoveData(communicationFound);

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