using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerAPI
{
    public class Chat :Hub
    {
        public void NewMessage(string userName, string message, string messageType, string imgUserSender, DateTime messageDate)
        {
            Clients.All.SendAsync("newMessage",userName,message, messageType, imgUserSender, messageDate);
        }
    }
}
