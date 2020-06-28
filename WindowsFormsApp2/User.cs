using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RPDModule
{
    static class User
    {
        public static int ID;
        public static string login, lastname,firstname,patronymic,password;
        public static bool add, delete, edit, isAdmin, editFOS, editQuestions;
        public delegate void UserChanged();
        public static UserChanged UserEventHandler;
        public static string getHash (string password)
        {
                byte[] bytes = Encoding.Unicode.GetBytes(password);


                MD5CryptoServiceProvider CSP =
                    new MD5CryptoServiceProvider();
                byte[] byteHash = CSP.ComputeHash(bytes);
                string hash = string.Empty;
                foreach (byte b in byteHash)
                    hash += string.Format("{0:x2}", b);

                return hash;
            }
        public static void refreshUser()
        {
            ID = 0;
            login = "";
            lastname = "";
            firstname = "";
            patronymic = "";
            password = "";
            add = delete = edit = isAdmin = editFOS = editQuestions = false;
        }
    }
}
