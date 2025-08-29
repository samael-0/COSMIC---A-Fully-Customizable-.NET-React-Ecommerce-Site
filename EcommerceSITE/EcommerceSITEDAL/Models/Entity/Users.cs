using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Models.Entity
{
    public class Users
    {
        public int UserID {  get; set; }
        public string Username { get; set; }

        public string Email {  get; set; }

        public string PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Phone {  get; set; }

        public string Address {  get; set; }

        public string Role {  get; set; }

        public DateTime CreatedAt {  get; set; }



    }
}
