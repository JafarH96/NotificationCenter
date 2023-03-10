using System;
using System.Threading;
using System.Collections.Generic;
using SerialDispatchQueueDotNetFramework;

namespace NotificationCenter
{
    public class SenderClass
    {
        private NotificationName notifName;
        private SerialQueue queue;
        public SenderClass()
        {
            queue = new SerialQueue();
            notifName = new NotificationName("DefaultName");
        }

        public void Start()
        {
            var userInfo = new Dictionary<string, object>();
            userInfo.Add("Num", 1);
            queue.Async((_) =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Hello there!");
                NotificationCenter.Default.Post(this, notifName, "Hello there!", userInfo);
                Thread.Sleep(3000);
                Console.WriteLine($"I'm class 1");
                NotificationCenter.Default.Post(this, notifName, "I Am Here!", null);
            });
        }
    }

    public class NotifiableClass2: Notifiable
    {
        private NotificationName notifName;
        private SerialQueue queue;
        public NotifiableClass2()
        {
            queue = new SerialQueue();
            notifName = new NotificationName("DefaultName");
            NotificationCenter.Default.AddObserver(this, notifName);
        }

        public void OnNotification(Notification notification)
        {
            Console.WriteLine(notification.ToString());
        }

        public void Start()
        {
            queue.Async((_) =>
            {
                while (true)
                {
                    Console.WriteLine("Waiting for notifications");
                    Thread.Sleep(500);
                }
            });
        }
    }
}
