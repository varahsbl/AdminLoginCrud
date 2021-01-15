using BussinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public bool Delete(int id)
        {
            return adminRL.Delete(id);
        }

        public List<Admin> GetAllEmployee()
        {
            return adminRL.GetRegister();
        }

        public bool Register(Admin user)
        {
            return adminRL.Register(user);
        }

        public bool Update(Admin admin)
        {
            return adminRL.Update(admin);
        }

        public bool Login(string adminName, string adminPassword)
        {
            return adminRL.Login(adminName, adminPassword);
        }
    }
}
