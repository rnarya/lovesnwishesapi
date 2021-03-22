// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatRoom
{
    public class ChatHub : Hub
    {
        //public void Send(string name, string message)
        //{
        //    Clients.All.broadcastMessage(name, message);
        //}

        public void AddMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void Connect()
        {
        
        }
        public void DisConnect()
        {

        }
    }
}