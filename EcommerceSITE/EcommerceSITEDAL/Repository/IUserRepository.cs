using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public interface IUserRepository
    {
        Task AddNewUser(Users users);
        Task<Users?> GetUserbyID(string Username);
    }
}
