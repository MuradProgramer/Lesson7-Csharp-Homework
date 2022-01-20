using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamespace;
using UserNamespace;

namespace AdminNamespace
{
    internal sealed partial class Admin
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Post[] Posts { get; set; }

        public Notification[] Notifications { get; set; }
    }

    internal sealed partial class Admin
    {
        // constructor
        public Admin(int id, string username, string password, Post[] posts, Notification[] natifications)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Posts = posts;
            this.Notifications = natifications;
        }

        // methods
        public void AddNotification(Notification notification)
        {
            Notification[] newNotifications = new Notification[Notifications.Length + 1];
            for (int i = 0; i < Notifications.Length; i++)
                newNotifications[i] = Notifications[i];
            newNotifications[Notifications.Length] = notification;
            Notifications = newNotifications;
        }

        public void DeleteNotification(Notification notification)
        {
            Notification[] nots = new Notification[Notifications.Length - 1];
            for (int i = 0, k = 0; i < Notifications.Length; i++)
            {
                if (Notifications[i] == notification)
                    continue;
                nots[k++] = Notifications[i];
            }
            Notifications = nots;
        }

        public void DeleteAllNotifications()
        {
            Notifications = new Notification[0];
        }

        public void ShowAllNotifications()
        {
            foreach (Notification notification in Notifications)
                Console.WriteLine(notification);
        }

        public void AddPost(Post post)
        {
            Post[] newPosts = new Post[Posts.Length + 1];
            for (int i = 0; i < Posts.Length; i++)
                newPosts[i] = Posts[i];
            newPosts[Posts.Length] = post;
            Posts = newPosts;
        }

        // override 
        public override string ToString() => $"Id: {Id}  |  Username: {Username}  |  Password: {Password}";
    }
}
