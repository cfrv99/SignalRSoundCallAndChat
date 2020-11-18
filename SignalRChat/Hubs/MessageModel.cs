using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class MessageModel
    {
        public string Message { get; set; }
        public string NickName { get; set; }
        public string ConnectionId { get; set; }
    }
}
