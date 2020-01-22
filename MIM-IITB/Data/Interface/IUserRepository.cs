using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(Guid id);
    }
}