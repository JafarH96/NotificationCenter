# NotificationCenter

A communication path between all classes of a project using the notification center.
Transferring data between observers at high speed and completely asynchronously. Implemented similarly to "NotificationCenter" in Swift.

## Dependencies

[Nuget](https://www.nuget.org/packages/SerialDispatchQueueDotNetFramework)


## Usage

The class that is going to be an observer of the notifications must implement the "Notifiable" interface:

```csharp
public class Observer: Notifiable
{

	public void OnNotification(Notification notification)
	{
		Console.WriteLine(notification.ToString());
	}
}

```

A class must be a member of the **Notification Center** observers to receive notifications:

```csharp
private NotificationName notifName;

public Observer()
{
	notifName = new NotificationName("DefaultName");
	NotificationCenter.Default.AddObserver(this, notifName);
}

```

A class can be an observer of different names. Each notification name is a separate list of observers.
It means that a class receives a notification when another class sends a notification with the same name.

To post a notification:

```csharp
NotificationCenter.Default.Post(sender: this, name: notifName, obj: "Hey there!", userInfo: null);

```

The main notification data has two parts:
- Object: which can carry any type of data
- UserInfo: includes a dictionary of keys and desired values

