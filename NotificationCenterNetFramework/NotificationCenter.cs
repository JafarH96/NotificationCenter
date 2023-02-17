using System;
using System.Collections.Generic;
using SerialDispatchQueueDotNetFramework;

namespace NotificationCenter
{
    public class NotificationCenter
    {
        private readonly Dictionary<string, List<Notifiable>> observers;
        private readonly SerialQueue queue;

        /// <summary>
        /// The shared instance of the notification center
        /// </summary>
        public static NotificationCenter Default = new NotificationCenter();
        public NotificationCenter()
        {
            observers = new Dictionary<string, List<Notifiable>>();
            queue = new SerialQueue();
        }

        /// <summary>
        /// Register a class as an observer to receive the notifications
        /// </summary>
        /// <param name="observer">Observer class</param>
        /// <param name="name">The name that the observer wants to receive the notifications on</param>
        public void AddObserver(Notifiable observer, NotificationName name)
        {
            if (observers.ContainsKey(name.Name) && observers[name.Name].Contains(observer))
            {
                return;
            }

            if (!observers.ContainsKey(name.Name))
            {
                observers.Add(name.Name, new List<Notifiable>());
            }

            observers[name.Name].Add(observer);
            Console.WriteLine($"[Notification Center] {observer.GetType().Name} was added to the notifiation center as an observer");
        }

        /// <summary>
        /// Remove the observer from the observers list
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(Notifiable observer)
        {
            foreach(var dic in observers)
            {
                if (dic.Value.Contains(observer))
                {
                    dic.Value.Remove(observer);
                }
            }
            Console.WriteLine($"[Notification Center] Removed {observer.GetType().Name} from the notification center");
        }

        /// <summary>
        /// Remove the observer from the observers list on a specific notification name
        /// </summary>
        /// <param name="observer">Observer class</param>
        /// <param name="name">Notification name</param>
        public void RemoveObserver(Notifiable observer, NotificationName name)
        {
            if (observers.ContainsKey(name.Name) && observers[name.Name].Contains(observer))
            {
                observers[name.Name].Remove(observer);
                Console.WriteLine($"[Notification Center] Removed {observer.GetType().Name} from notification name '{name.Name}'");
            }
        }

        /// <summary>
        /// Post notification on a specific name and notify observers
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="name">Notification name</param>
        /// <param name="obj">Custom object</param>
        /// <param name="userInfo">Custom user info</param>
        public void Post(object sender, NotificationName name, object obj, Dictionary<string, object> userInfo)
        {
            Console.WriteLine($"[Notification Center] Notifying Observers");
            if (!observers.ContainsKey(name.Name))
            {
                return;
            }
            
            Notification notification = new Notification(sender.GetType().Name, name, obj, userInfo);
            queue.Async((_) =>
            {
                foreach(var observer in observers[name.Name])
                {
                    observer.OnNotification(notification);
                }
            });
        }
    }
}
