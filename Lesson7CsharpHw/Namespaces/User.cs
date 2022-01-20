using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserNamespace
{
    internal sealed partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }


    internal sealed partial class User
    {
        // constructor
        public User(int id, string name, string surname, int age, string username, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Username = username;
            this.Password = password;
        }

        // override
        public override string ToString() =>
            $"Id: {Id}  |  Name: {Surname}  |  Surname: {Surname}" +
            $"  |  Age: {Age}  |  Username: {Password}  |  Password: {Password}";
    }

}
