using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
   public interface IAdminBL
    {
        bool Register(Admin user);
        List<Admin> GetAllEmployee();
        bool Update(Admin admin);
        bool Delete(int id);
        bool Login(string adminName, string adminPassword);
    }
}
