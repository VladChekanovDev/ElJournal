using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElJournal.Entities
{
    public class User
    {
        [Required] public int UserID { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string Pass { get; set; }
        [Required] public int UserType { get; set; }
        /*
         * ~~~UserTypes~~~
         * 0 - Admin
         * 1 - Teacher
        */
        [Required] public Admin Admin { get; set; }
        [Required] public Teacher Teacher { get; set; }

        public User()
        {

        }

        public User(string login, string pass, int usertype)
        {
            Login = login;
            Pass = pass;
            UserType = usertype;
        }
    }
}
