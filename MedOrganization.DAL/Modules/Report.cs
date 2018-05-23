using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Classes;

namespace MedOrganization.DAL.Modules
{
    public class Report
    {
        public static void PrintAllBaseOfMegOrgs(ref ModulPatientAttach modul)
        {
            foreach (MedOrg item in modul.MedOrgs)
            {
                item.PrintInfo();
            }
        }
    }
}
