using AdminNamespace;
using Methods;
using PostNamespace;
using System.Text;
using UserNamespace;

Console.Title = "LESSON 7   H O M E W O R K";

#region Introduction
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

string[] texts = new string[] {
    "Hello Teacher, Its My Homework...",
    "In Menues, You must control selecting with down or up arrow, then select with 'ENTER' key.",
    "Now Lets Begin."
};
Console.ForegroundColor = ConsoleColor.Green;
foreach (var text in texts)
{
    for (int i = 0; i < text.Length; i++)
    {
        Console.Write(text[i]);
        Thread.Sleep(60);
    }
    Thread.Sleep(1000);
    Console.WriteLine();
}
Console.Clear();
#endregion

int postID = 1;
int userID = 1;
int notID = 1;

User[] Users = new User[]
{
    new(userID, "Murad", "Musali", 15, "fireman", "user"),
    new(userID, "Ramazan", "Mustafazade", 15, "ramo", "copier"),
    new(userID, "Pervin", "Aliyev", 15, "parvin", "user")
};

Admin Admin = new Admin(1, "bluefire", "admin",
    new Post[]
    {
        new(postID++, "Love Is TREASURE!", 10, 5),
        new(postID++, "Spend your time without any bad noises.", 12763, 10203),
        new(postID++, "Smell Forever.", 7200, 402)
    },
    new Notification[0]
);

labelMenu:;
Console.CursorVisible = false;
Console.Clear();
string[] menu = new string[] { "ADMIN\n", "USER\n" };
int ind = Method.Selecting(menu);

if (ind == 0)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;

labelLogAdmin:;
    Console.CursorVisible = true;
    Console.Write("\n\n\n\t\t\u25ba ENTER USERNAME: ");
    string? username = Console.ReadLine();
    if (username == Admin.Username)
    {
    labelLogAdminPsw:;
        string psw = Method.ToPassword("\t\t\u25ba ENTER PASSWORD: ", username);
        if (psw == Admin.Password)
        {
        labelAdminMenu:;
            Console.Clear();
            Console.CursorVisible = false;
            int ind1 = Method.Selecting(
                new string[] { $"SHOW NOTIFICATIONS ({Admin.Notifications.Length})\n", "ADD NEW POST\n", "COMEBACK TO MENU\n" }
            );

            if (ind1 == 0)
            {
                Console.Clear();
                if (Admin.Notifications.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\n\n\t\t\tY O U   D O N T   H A V E   A N Y   N O T I F I C A T I O N");
                    Thread.Sleep(2000);
                    goto labelAdminMenu;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ______________________________ ");
                Console.WriteLine("|   N O T I F I C A T I O N S  |");
                Console.WriteLine(" ------------------------------ \n");
                Admin.ShowAllNotifications();
                Console.Write("\nPress any key to come back...");
                notID = 1;
                Admin.DeleteAllNotifications();
                Console.ReadKey();
                goto labelAdminMenu;
            }

            else if (ind1 == 1)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n\t\tEnter Content of Post: ");
                string? cont = Console.ReadLine();
                Admin.AddPost(new Post(postID++, cont, 0, 0));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\tP O S T   S U C C E S F U L Y   A D D E D");
                Thread.Sleep(2000);
                Console.CursorVisible = false;
                goto labelAdminMenu;
            }

            else
                goto labelMenu;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\n\n\n\t\t\u25ba ENTER USERNAME: {username}");
            goto labelLogAdminPsw;
        }
    }
    else
    {
        Console.Clear();
        goto labelLogAdmin;
    }

}

else if (ind == 1)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;

labelLogUser:;
    Console.CursorVisible = true;
    int userIndex = 0;
    Console.Clear();
    Console.Write("\n\n\n\t\t\u25ba ENTER USERNAME: ");
    string? username = Console.ReadLine();
    bool check = false;
    foreach (var user in Users)
    {
        if (username == user.Username)
        {
            check = true;
            break;
        }
        userIndex++;
    }
    if (!check)
        goto labelLogUser;

    labelLogUserPsw:;
    check = false;
    string pswU = Method.ToPassword("\t\t\u25ba ENTER PASSWORD: ", username);

    foreach (var user in Users)
    {
        if (pswU == user.Password)
        {
            check = true;
            break;
        }
    }

    if (!check)
    {
        Console.Clear();
        Console.WriteLine($"\n\n\n\t\t\u25ba ENTER USERNAME: {username}");
        goto labelLogUserPsw;
    }
    Console.CursorVisible = false;

    labelUserMenu:;
    Console.Clear();
    int ind2 = Method.Selecting(new string[] { "SHOW POST\n", "COME BACK\n" });

    if (ind2 == 0)
    {
        int indexOfPost = 0;
        bool isOpenedContent = false;
        bool isLiked = false;
        labelShowingPosts:;
        Console.Clear();
        if (indexOfPost == Admin.Posts.Length)
            indexOfPost = 0;
        menu = new string[] { "...\n", "\t LIKE", "\n\n\t\t\t\t\t\t\t\tNEXT POST (ESC -> for comeback)" };

        void ShowPostContent(bool check)
        {
            if (!check)
                if (Admin.Posts[indexOfPost].Content.Length >= 12)
                    for (int i = 0; i < 12; i++)
                        Console.Write(Admin.Posts[indexOfPost].Content[i]);
                else
                    Console.Write(Admin.Posts[indexOfPost].Content);
            else
                Console.Write(Admin.Posts[indexOfPost].Content);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Admin.Posts[indexOfPost].ShowPost();
        ShowPostContent(isOpenedContent);
        Console.CursorVisible = false;

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write($"{menu[0]}");
        Console.ResetColor();

        for (int i = 1; i < menu.Length; i++)
            Console.Write($"{menu[i]}");

        ind = 0;

        while (true)
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
            {
                Admin.Posts[indexOfPost].ViewCount++;
                Admin.AddNotification(new(notID++, "The post viewed", Users[userIndex].Username));
                goto labelUserMenu;
            }

            else if (key.Key == ConsoleKey.Enter)
                break;

            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (ind + 1 == menu.Length)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Admin.Posts[indexOfPost].ShowPost();
                    ShowPostContent(isOpenedContent);
                    Console.ResetColor();
                    ind = 0;
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (i == ind)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{menu[i]}");
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write($"{menu[i]}");
                    }
                    Thread.Sleep(60);
                    continue;
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Admin.Posts[indexOfPost].ShowPost();
                    ShowPostContent(isOpenedContent);
                    Console.ResetColor();
                    ind++;
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (i == ind)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{menu[i]}");
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write($"{menu[i]}");
                    }
                    Thread.Sleep(60);
                }
            }

            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (ind - 1 < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Admin.Posts[indexOfPost].ShowPost();
                    ShowPostContent(isOpenedContent);
                    Console.ResetColor();
                    ind = menu.Length - 1;
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (i == ind)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{menu[i]}");
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write($"{menu[i]}");
                    }
                    Thread.Sleep(60);
                    continue;
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Admin.Posts[indexOfPost].ShowPost();
                    ShowPostContent(isOpenedContent);
                    Console.ResetColor();
                    ind--;
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (i == ind)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{menu[i]}");
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write($"{menu[i]}");
                    }
                    Thread.Sleep(60);
                }
            }

            else
                continue;
        }

        if (ind == 0)
        {
            isOpenedContent = !isOpenedContent;
            goto labelShowingPosts;
        }
        else if (ind == 1)
        {
            if (isLiked)
            {
                isLiked = false;
                Admin.Posts[indexOfPost].LikeCount--;
                Admin.AddNotification(new(notID++, "The Post UnLiked", Users[userIndex].Username));
                goto labelShowingPosts;
            }
            else
            {
                isLiked = true;
                Admin.Posts[indexOfPost].LikeCount++;
                Admin.AddNotification(new(notID++, "The Post Liked", Users[userIndex].Username));
                goto labelShowingPosts;
            }
        }
        else
        {
            Admin.Posts[indexOfPost].ViewCount++;
            Admin.AddNotification(new(notID++, "The post viewed", Users[userIndex].Username));
            indexOfPost++;
            isOpenedContent = false;
            isLiked = false;
            goto labelShowingPosts;
        }

    }
    else
        goto labelMenu;
}

else if (ind == -1)
{
    Console.Clear();
    Console.WriteLine("PPress any key to continue...");
    Console.ReadKey();
}