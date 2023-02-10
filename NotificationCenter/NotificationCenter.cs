using System;
using System.Collections.Generic;
using DispatchQueue;

namespace NotificationCenter
{
    public class NotificationCenter
    {
        private readonly Dictionary<string, List<Notifiable>> observers;
        private readonly SerialQueue queue;

        public static NotificationCenter Default = new NotificationCenter();
        public NotificationCenter()
        {
            observers = new Dictionary<string, List<Notifiable>>();
            queue = new SerialQueue();
        }

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
            if (observers.ContainsKey(name.Name) && observers[name.Name].Contains(observer))
            {
                observers[name.Name].Remove(observer);
                Console.WriteLine($"[Notification Center] Removed {observer.GetType().Name} from notification name '{name.Name}'");
            }
        }

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
