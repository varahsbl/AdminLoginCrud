using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly AdminDbContext adminContext;

        public AdminRL(AdminDbContext adminContext)
        {
            this.adminContext = adminContext;
        }

        public bool Delete(int id)
        {
            Admin dbUser = this.adminContext.users.Where(user => user.UserId == id).FirstOrDefault();



            if (dbUser != null)
            {
                this.adminContext.users.Remove(dbUser);
                int result = this.adminContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public List<Admin> GetRegister()
        {
            return this.adminContext.users.ToList();
        }

        public bool Register(Admin user)
        {
            String encryptedPassword = Encryptdata(user.Password);
            user.Password = encryptedPassword;
            this.adminContext.users.Add(user);
            int result = this.adminContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Admin admin)
        {
            Admin dbUser = this.adminContext.users.Where(user => user.UserId == admin.UserId).FirstOrDefault();
            dbUser.UserName = admin.UserName;
            dbUser.Email = admin.Email;
            dbUser.Password = admin.Password;
            int result = this.adminContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        public bool Login(string adminName, string adminPassword)
        {
            Admin dbUser = this.adminContext.users.Where(user => user.UserName == adminName ).FirstOrDefault();
            string ps=dbUser.Password;
            if (dbUser != null && Decryptdata(ps) == adminPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
