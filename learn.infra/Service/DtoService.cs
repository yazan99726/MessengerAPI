using learn.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.infra.Service
{
    public class DtoService : IDtoService
    {
        private readonly IDtoRepository dtoRepository;

        public DtoService(IDtoRepository dtoRepository)
        {
            this.dtoRepository = dtoRepository;
        }

        public async Task<CreateMessageGroupAndGroupMember> createMessageGroupAndMember(CreateMessageGroupAndGroupMember groupAndGroupMember)
        {
            return await dtoRepository.createMessageGroupAndMember(groupAndGroupMember);
        }

        public GetAllNumberOfFriends getAllNumberOfFriends(int userId)
        {
            return dtoRepository.getAllNumberOfFriends(userId);
        }

       
    }
}
