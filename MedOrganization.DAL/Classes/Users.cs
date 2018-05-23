using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Modules;
using RandomNameGenerator;

namespace MedOrganization.DAL.Classes
{
    public enum AccessLevel
    {
        NoPrivileges, Privileges
    }
    public class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public AccessLevel AccessLevel { get; set; }
        


        public void PrintInfo()
        {
            Console.WriteLine("--------------------------Пользователь----------------------------------");
            Console.WriteLine($"Логин : {Login} Пароль : {Password} Уровень доступа: {AccessLevel}\n");
        }
    }
}
