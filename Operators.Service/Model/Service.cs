using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;


namespace Operators.Service.Model
{
    public class Service
    {
        private string Path { get; set; }
        public Service(string path)
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
                    XmlElement el = doc.CreateElement("Operators");
                    doc.AppendChild(el);
                    doc.Save(Path);
                }
            }
            else
            {
                XmlElement el = doc.CreateElement("Operators");
                doc.AppendChild(el);
                doc.Save(Path);
            }
            return doc;
        }
        public bool AddOperator(Operator operator_)
        {
            if (CheckOperator(operator_) == true)
            {
                XmlDocument document = GetDocument();

                XmlElement oper = document.CreateElement("operator");


                XmlElement name = document.CreateElement("name");
                name.InnerText = operator_.Name;
                oper.AppendChild(name);

                XmlElement logo = document.CreateElement("logo");
                logo.InnerText = operator_.Logo;
                oper.AppendChild(logo);

                XmlElement percentage = document.CreateElement("percentage");
                percentage.InnerText = operator_.Persentage.ToString();
                oper.AppendChild(percentage);

                XmlElement prefixes = document.CreateElement("prefixes");

                foreach (int item in operator_.Prefixes)
                {
                    if (CheckPrefix(item) == true)
                    {
                        XmlElement prefix = document.CreateElement("prefix");
                        prefix.InnerText = item.ToString();
                        prefixes.AppendChild(prefix);
                    }
                    else
                    {
                        return false;
                        
                    }
                }
                oper.AppendChild(prefixes);

                document.AppendChild(oper);

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
            else
            {
                return false;
            }
    
        }

        private bool CheckOperator(Operator _operator)
        {
            XmlDocument check = GetDocument();
            foreach (XmlNode item in check.SelectNodes("operators/Operator/name"))
            {
                if(item.InnerText == _operator.Name)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckPrefix(int pref)
        {
            XmlDocument check = GetDocument();
            foreach (XmlNode item in check.SelectNodes("operators/Operator/prefixes/prefix"))
            {
                if (item.InnerText == pref.ToString())
                {
                    return false;
                }
            }
            return true;
        }


    }

}
