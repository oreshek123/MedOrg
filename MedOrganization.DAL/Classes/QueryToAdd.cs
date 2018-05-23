using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedOrganization.DAL.Classes
{
    public class QueryToAdd
    {
        public DateTime? CreateDate { get; set; }
        public DateTime? Obrabotka { get; set; }
        public Patient Patient { get; set; }
        public MedOrg MedOrg { get; set; }
        public bool Active { get; set; }

        public void PrintInfo()
        {
            string res = Active ? "В обработке" : "Обработано";
            Console.WriteLine($"Дата создания : {CreateDate}\nДата обработки : {Obrabotka}\nСтатус запроса : {res}\nМед. организация, в которую пациент переводится: {MedOrg.Name}");
            Patient.PrintInfo();


        }
    }
}
