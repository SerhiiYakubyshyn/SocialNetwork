using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Hubs
{
    public class ChatHub : Hub
    {

        public async Task Send(string message, string userName)
        {
            await this.Clients.All.SendAsync("Send", message, userName);
        }


        //public async Task SendTo(string message, string to)
        //{
        //    var userName = Context.User.Identity.Name;

        //    if(Context.UserIdentifier != to)
        //    {
        //        await this.Clients.User(Context.UserIdentifier).SendAsync("SendTo", message, "MY");
        //    }
        //    await this.Clients.User(to).SendAsync("SendTo", message, userName);

        //}

    }
}
