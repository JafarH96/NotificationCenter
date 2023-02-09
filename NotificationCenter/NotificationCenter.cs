using System;
using System.Collections.Generic;

namespace NotificationCenter
{
    public class NotificationCenter
    {
        private readonly Dictionary<string, List<Notifiable>> observers;
        private readonly DispatchQueue.DispatchQueue queue;

        public static NotificationCenter Default = new NotificationCenter();
        public NotificationCenter()
        {
            observers = new Dictionary<string, List<Notifiable>>();
            queue = new DispatchQueue.DispatchQueue();
        }

        public void AddObserver(Notifiable observer, NotificationName name)
        {
            if (observers.ContainsKey(name.name) && observers[name.name].Contains(observer))
            {
                return;
            }

            if (!observers.ContainsKey(name.name))
            {
                observers.Add(name.name, new List<Notifiable>());
            }

            observers[name.name].Add(observer);
            Console.WriteLine($"[Notification Center] Adding {observer.GetType().Name} to the notifiation center");
        }
        
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

        public void RemoveObserver(Notifiable observer, NotificationName name)
        {
            if (observers.ContainsKey(name.name) && observers[name.name].Contains(observer))
            {
                observers[name.name].Remove(observer);
                Console.WriteLine($"[Notification Center] Removed {observer.GetType().Name} from notification name '{name.name}'");
            }
        }

        public void Post(Notifiable sender, NotificationName name, object obj, Dictionary<string, object> userInfo)
        {
            Console.WriteLine($"[Notification Center] Notifying Observers");
            if (!observers.ContainsKey(name.name))
            {
                return;
            }
            
            Notification notification = new Notification(sender, name, obj, userInfo);
            queue.Async((_) =>
            {
                foreach(var observer in observers[name.name])
                {
                    if (observer == sender) continue;
                    observer.OnNotification(notification);
                }
            });
        }
    }
}
