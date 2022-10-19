using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.core.Service
{
    public interface IDtoService
    {
        public GetAllNumberOfFriends getAllNumberOfFriends(int userId);
        public Task<CreateMessageGroupAndGroupMember> createMessageGroupAndMember(CreateMessageGroupAndGroupMember groupAndGroupMember);

    }
}
