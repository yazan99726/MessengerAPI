using learn.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.infra.Service
{
    public class FrindService : IFrindService
    {
        private readonly IFrindRepository frindRepository;

        public FrindService(IFrindRepository frindRepository)
        {
            this.frindRepository = frindRepository;
        }
        public void AddFrind(Frinds frind)
        {
            frindRepository.AddFrind(frind);
        }

        public void BlockFriend(int id)
        {
            frindRepository.BlockFriend(id);
        }

        public void confirmFriend(int id)
        {
            frindRepository.confirmFriend(id);
        }

        public void DeleteFrind(int friendId)
        {
            frindRepository.DeleteFrind(friendId);
        }

        public async Task<IList<Frinds>> GetAllFrinds(int userId)
        {
            return await frindRepository.GetAllFrinds(userId);
        }

        public Frinds GetFrindById(int userId, int reciveId)
        {
            return frindRepository.GetFrindById(userId, reciveId);
        }

        public void UpdateFrind(Frinds frind)
        {
            frindRepository.UpdateFrind(frind);
        }
    }
}
