using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCenter
{
    public interface Notifiable
    {
        void OnNotification(Notification notification);
    }
}
