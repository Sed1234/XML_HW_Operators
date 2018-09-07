using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operators.Service.Model;
using Operators.Service;

namespace Operator.View
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operators.Service.Model.Operator op = 
            //    new Operators.Service.Model.Operator();
            //op.Name = "Beeline";
            //op.Logo = "BYBY";
            //op.Persentage = 2.3;
            //op.Prefixes.Add(777);
            //op.Prefixes.Add(705);

            //Service service = new Service(@"\\dc\Студенты\ПКО\SEP-172.1\Izabella.xml");
            //if(service.AddOperator(op) == true)
            //{
            //    Console.WriteLine("Operator added");
            //}
            //else
            //{
            //    Console.WriteLine("Operator WAS NOT added");
            //}

           
            ServiceUser service = new ServiceUser(@"\\dc\Студенты\ПКО\SEP-172.1\User.xml");
            User user = service.LogIn("JSmith", "123456");
            if (user != null)
            {
                Console.WriteLine($"Hello, {user.FullName}");
            }
            else
            {
                Console.WriteLine("Wrong login or password");
            }


        }
    }
}
