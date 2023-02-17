
namespace NotificationCenter
{
    public interface Notifiable
    {
        /// <summary>
        /// Trigger when a notification is received
        /// </summary>
        /// <param name="notification">Notification including the data received from the sender</param>
        void OnNotification(Notification notification);
    }
}
