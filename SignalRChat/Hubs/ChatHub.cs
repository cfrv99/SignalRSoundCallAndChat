using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        static Dictionary<string, string> callTime = new Dictionary<string, string>();
        static List<CallMember> callMembers = new List<CallMember>();
        public ChatHub(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Connected", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("DisConnected", Context.ConnectionId);
        }

        public async Task SendMessage(MessageModel message, string groupname)
        {
            var con = Context.ConnectionId;
            var name = httpContextAccessor.HttpContext.Session.GetString("UserName");
            message.NickName = name;
            message.ConnectionId = Context.ConnectionId;
            await Clients.Group(groupname).SendAsync("ReceiveMessage", message);
        }
        public async Task Subscribe(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
        }
        public async Task Join(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
        }

        public async Task CallUser(string connectionId,string sourceConnId)
        {
            if (callMembers.Any(i => i.DestinationConnectionId == connectionId || i.SourceConnectionId == connectionId))
            {
                await Clients.Clients(sourceConnId,connectionId).SendAsync("BusyCall", "This user on the call");
            }
            else
            {
                await Clients.Client(connectionId).SendAsync("ReceiveCall", new CallModel { CallerUserName = httpContextAccessor.HttpContext.Session.GetString("UserName"), SourceConnectionId = connectionId, IsTake = false });
            }

        }

        public async Task TakeCall(string sourceConnectionId, string destinationConnectionId, bool callStatus)
        {
            if (callStatus)
            {
                callMembers.Add(new CallMember { SourceConnectionId = sourceConnectionId, DestinationConnectionId = destinationConnectionId });
                await Clients.Client(destinationConnectionId).SendAsync("CallStatus", "Call is Taking");

            }
            else
            {
                await Clients.Client(destinationConnectionId).SendAsync("CallStatus", "Call dismis");
            }
        }
    }


    public class CallModel
    {
        public string SourceConnectionId { get; set; }
        public bool IsTake { get; set; }

        public string CallerUserName { get; set; }
    }

    public class CallMember
    {
        public string SourceConnectionId { get; set; }
        public string DestinationConnectionId { get; set; }
    }
}
