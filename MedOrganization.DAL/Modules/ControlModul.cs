using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Classes;

namespace MedOrganization.DAL.Modules
{
    public class ControlModul
    {
        public static void PrintALlQueriesToAdd(ref ModulPatientAttach modul)
        {
            if (modul.QueriesToAdd != null)
            {
                foreach (QueryToAdd queryToAdd in modul.QueriesToAdd)
                {
                    queryToAdd.PrintInfo();
                }
            }
            else Console.WriteLine("В списке пока нет записей");
        }

        public static void AddPatientToOrganization(ref ModulPatientAttach modul)
        {
            MedOrg patientsMedOrg = null;
            foreach (QueryToAdd query in modul.QueriesToAdd)
            {
                if (query.Active)
                {
                    query.PrintInfo();

                    Patient pat = query.Patient;


                    Console.WriteLine("1 - принять 0 - отклонить");
                    string value = Console.ReadLine();


                    foreach (MedOrg item in modul.MedOrgs)
                    {
                        foreach (Patient p in item.Patients)
                        {
                            if (p == query.Patient)
                            {
                                patientsMedOrg = item;
                                break;
                            }
                        }

                    }

                    if (value == "1")
                    {
                        patientsMedOrg.Patients.RemoveAt(patientsMedOrg.Patients.IndexOf(query.Patient));
                        query.MedOrg.Patients.Add(pat);
                        query.Obrabotka = DateTime.Now;
                        query.Active = false;
                        Console.WriteLine("Пациент успешно перенесен в новую организацию");
                    }
                    else if (value == "0")
                    {
                        query.Obrabotka = DateTime.Now;
                        query.Active = false;
                        Console.WriteLine("Пациент не добавлен");
                    }
                    else
                    {
                        Console.WriteLine("Проверьте ввод");
                        break;
                    }


                    Console.WriteLine("Для продолжения нажмите пробел");
                    if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                        break;
                }
            }
        }
    }
}
