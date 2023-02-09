using System;
using System.Collections.Generic;

namespace NotificationCenter
{
    public class Notification
    {
        public NotificationName name { get; }
        public DateTime notifyDate { get; }
        public object obj { get; }
        public Dictionary<string, object> userInfo { get; }
        public Notifiable sender { get; }

        public Notification(Notifiable sender, NotificationName name, object obj, Dictionary<string, object> userInfo)
        {
            this.name = name;
            this.obj = obj;
            this.userInfo = userInfo;

            this.sender = sender;
            this.notifyDate = DateTime.Now;
        }
    }
}
