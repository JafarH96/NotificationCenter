using System;
using System.Collections.Generic;

namespace NotificationCenter
{
    public class Notification
    {
        public NotificationName Name { get; }
        public DateTime NotifyDate { get; }
        public object Obj { get; }
        public Dictionary<string, object> UserInfo { get; }
        public string Sender { get; }

        public Notification(string sender, NotificationName name, object obj, Dictionary<string, object> userInfo)
        {
            this.Name = name;
            this.Obj = obj;
            this.UserInfo = userInfo;

            this.Sender = sender;
            this.NotifyDate = DateTime.Now;
        }

        public override string ToString()
        {
            string description = $"{NotifyDate}: Name: {Name}, Sender: {Sender}, Object: {Obj}, User Info: [";
            if(UserInfo != null)
            {
                int i = 0;
                foreach (var info in UserInfo)
                {
                    description += $"{info.Key.ToString()} : {info.Value.ToString()}";
                    i++;
                    if (i != UserInfo.Count)
                    {
                        description += ", ";
                    }
                }
            }
            description += "]";

            return description;
        }
    }
}
