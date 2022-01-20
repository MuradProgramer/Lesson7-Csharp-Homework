using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamespace
{
    //// Class Post
    
    internal sealed partial class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDatetime { get; set; }

        public int LikeCount { get; set; }

        public int ViewCount { get; set; }
    }

    internal sealed partial class Post
    {
        // constructor
        public Post(int id, string content, int likeCount, int viewCount)
        {
            this.Id = id;
            this.Content = content;
            this.CreationDatetime = DateTime.Now;
            this.LikeCount = likeCount;
            this.ViewCount = viewCount;
        }


        // methods
        public void ShowPost()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t ____________________________                ");
            Console.WriteLine("\t|                            |               ");
            Console.WriteLine("\t|     * * * *    * * * *     |               ");
            Console.WriteLine("\t|   *         *          *   |               ");
            Console.WriteLine("\t|  *                      *  |               ");
            Console.WriteLine("\t|  *          C #         *  |               ");
            Console.WriteLine("\t|   *     PROGRAMING     *   |               ");
            Console.WriteLine("\t|     *                *     |               ");
            Console.WriteLine("\t|       *            *       |               ");
            Console.WriteLine("\t|         *        *         |               ");
            Console.WriteLine("\t|           *    *           |               ");
            Console.WriteLine("\t|              *             |               ");
            Console.WriteLine("\t|____________________________|               ");
            Console.WriteLine();
            Console.WriteLine($"\t Views: {ViewCount}  |  Likes: {LikeCount} ");
            Console.Write("\t ");
            
        }

        // override
        public override string ToString() =>
            $"Id: {Id}  |  Content: {Content}  |  Creation DateTime: {CreationDatetime.ToShortDateString()}  |  " +
            $"Like Count: {LikeCount}  |  View Count: {ViewCount}";
    }



    //// Class Notification

    internal sealed partial class Notification
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public string FromUser { get; set; }
    }

    internal sealed partial class Notification
    {
        // constructor 
        public Notification(int id, string text, string fromUser)
        {
            this.Id = id;
            this.Text = text;
            this.DateTime = DateTime.Now;
            this.FromUser = fromUser;
        }

        // override
        public override string ToString() =>
            $"ID: {Id}  |  TEXT: {Text}  |  DateTime: {DateTime}  |  From: \"{FromUser}\" user.";
    }


}
