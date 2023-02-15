
namespace NotificationCenter
{
    public class NotificationName
    {
        public string Name { get; }
        public NotificationName(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
