using System;
using System.Collections.Generic;

namespace NotificationCenter
{
    public class Notification
    {
        /// <summary>
        /// Notification unique name
        /// </summary>
        public NotificationName Name { get; }
        public DateTime NotifyDate { get; }
        /// <summary>
        /// The object sent by the sender
        /// </summary>
        public object Obj { get; }
        /// <summary>
        /// A dictionary contains arbitrary data set by the sender
        /// </summary>
        public Dictionary<string, object> UserInfo { get; }
        /// <summary>
        /// Sender name
        /// </summary>
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
