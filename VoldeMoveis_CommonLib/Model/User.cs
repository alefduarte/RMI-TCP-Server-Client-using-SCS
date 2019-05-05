using System;
using System.Collections.Generic;
using System.Text;

namespace VoldeMoveis_CommonLib.Model
{
    public enum RoleEnum : int
    {
        Retailer = 1,
        Stockist = 2,
        Employee = 3,
        Manager = 4,
        Admin = 5
    }

    [Serializable]
    public class User
    {
        public User()
        {
            this.ID = 0;
            this.Name = "";
            this.Username = "";
            this.Password = "";
            this.Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), "Retailer");
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public RoleEnum Role { get; set; }
    }
}
