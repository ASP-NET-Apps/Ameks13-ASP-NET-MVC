using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWoodenHouse.Constants.Models
{
    public partial class Consts
    {
        public struct SeedUser
        {
            public struct Administrator
            {
                public const string Username = "administrator@abv.bg";
                public const string Password = "111111";
                public const string Email = "administrator@abv.bg";
            }

            public struct Admin
            {
                public const string Username = "admin@abv.bg";
                public const string Password = "111111";
                public const string Email = "admin@abv.bg";
            }

            public struct User
            {
                public const string Username = "user@abv.bg";
                public const string Password = "123456";
                public const string Email = "user@abv.bg";
            }
        };
    }
}
