using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Operators.Service.Model
{
    public class ServiceUser
    {
        private string Path { get; set; }
        public ServiceUser(string path)
        {
            Path = path;
        }
        private XmlDocument GetDocument()
        {
            FileInfo f = new FileInfo(Path);
            XmlDocument doc = new XmlDocument();
            if (f.Exists == true)
            {
                doc.Load(Path);
                if (doc.DocumentElement == null)
                {
                    XmlElement el = doc.CreateElement("Users");
                    doc.AppendChild(el);
                    doc.Save(Path);
                }
            }
            else
            {
                XmlElement el = doc.CreateElement("Users");
                doc.AppendChild(el);
                doc.Save(Path);
            }
            return doc;
        }


        /// <summary>
        /// Method of Registration
        /// </summary>
        /// <param name="user"> User Info</param>
        /// <returns></returns>
        public bool Registration(User user)
        {
            XmlDocument document = GetDocument();

            XmlElement us = document.CreateElement("user");

            XmlElement login = document.CreateElement("login");
            login.InnerText = user.Login;
            us.AppendChild(login);

            XmlElement password = document.CreateElement("password");
            password.InnerText = user.Password;
            us.AppendChild(password);

            XmlElement fullName = document.CreateElement("fullName");
            fullName.InnerText = user.FullName;
            us.AppendChild(fullName);

            document.AppendChild(us);

            try
            {

                document.Save(Path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User LogIn(string login, string password)
        {
            XmlDocument document = GetDocument();
            User _user = new User();
            foreach (XmlNode user in document.SelectNodes("Users/User"))
            {
                if(user.SelectSingleNode("Login").InnerText == login
                && user.SelectSingleNode("Password").InnerText == password)
                {
                    _user.FullName = user.SelectSingleNode("Fullname").InnerText;
                    _user.Login = login;
                    _user.Password = password;
                    return _user;
                }
            }
            return null;
        }


    }
}
