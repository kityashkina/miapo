using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ГИБДД
{
    public static class CurrentDriver
    {
        public static int Id { get; set; }
        public static string LastName { get; set; }
        public static string FirstName { get; set; }
        public static string MiddleName { get; set; }
        public static string Passport { get; set; }

        public static void Clear()
        {
            Id = 0;
            LastName = "";
            FirstName = "";
            MiddleName = "";
            Passport = "";
        }
    }
}