using System;
using System.Threading;

namespace NotificationCenter
{
    public class NotifiableClass1: Notifiable
    {
        private NotificationName notifName;
        private DispatchQueue.DispatchQueue queue;
        public NotifiableClass1()
        {
            queue = new DispatchQueue.DispatchQueue();
            notifName = new NotificationName("DefaultName");
            NotificationCenter.Default.AddObserver(this, notifName);
        }

        public void OnNotification(Notification notification)
        {
            Console.WriteLine($"Class 1 => On name: {notification.name}, Date: {notification.notifyDate}, Object: {notification.obj.ToString()}");
        }

        public void Start()
        {
            queue.Async((_) =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Hello there!");
                NotificationCenter.Default.Post(this, notifName, "Hello there!", null);
                Thread.Sleep(3000);
                Console.WriteLine($"I'm class 1");
                NotificationCenter.Default.Post(this, notifName, "I Am Here!", null);
                NotificationCenter.Default.RemoveObserver(this);
            });
        }
    }

    public class NotifiableClass2: Notifiable
    {
        private NotificationName notifName;
        private DispatchQueue.DispatchQueue queue;
        public NotifiableClass2()
        {
            queue = new DispatchQueue.DispatchQueue();
            notifName = new NotificationName("DefaultName");
            NotificationCenter.Default.AddObserver(this, notifName);
        }

        public void OnNotification(Notification notification)
        {
            Console.WriteLine($"Class 2 => On name: {notification.name}, Date: {notification.notifyDate}, Object: {notification.obj.ToString()}");
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
