using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        bool Register(Admin user);
        List<Admin> GetRegister();
        bool Update(Admin admin);
        bool Delete(int id);
        bool Login(string adminName, string adminPassword);
    }
}
