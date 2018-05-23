using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedOrganization.DAL.Classes;
using MedOrganization.DAL.Modules;

namespace MedOrganization
{
    class Program
    {
        static void Main(string[] args)
        {
            ModulPatientAttach modul = new ModulPatientAttach();
            modul.GenerateBase();

            start:
            Patient patient;
            MedOrg medOrg;
            Console.WriteLine("1 - Вывести всех пацинтов по мед. органициям\n2 - Запрос на прикрепление, на выбранную организацию\n3 - Все запросы на прикрепление\n4 - Одобрение либо отклонение выбранного запроса на прикрепление ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    {
                        Report.PrintAllBaseOfMegOrgs(ref modul);
                        Console.WriteLine("Для выхода в меню нажмите ENTER");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            goto start;
                        break;
                    }
                case 2:
                    {
                        patient = modul.Search(out medOrg);
                        modul.CheckForNullAndPrintInfoAboutPatient(ref patient);
                        if (patient != null)
                        {
                            Console.WriteLine("Введите дату запроса");
                            DateTime.TryParse(Console.ReadLine(), out DateTime date);
                            Console.WriteLine("Введите мед.организацию, в которую пациент хочет перевестись");
                            int i = 0;
                            foreach (MedOrg item in modul.MedOrgs)
                            {
                                Console.WriteLine($"{++i} {item.Name}");
                            }
                            string name = Console.ReadLine();
                            foreach (MedOrg item in modul.MedOrgs)
                            {
                                if (item.Name == name)
                                {
                                    medOrg = item;
                                    break;
                                }
                            }
                            if(medOrg!=null)
                            modul.CreateQuaryToAdd(date, ref patient, ref medOrg);
                        }

                        Console.WriteLine("Для выхода в меню нажмите ENTER");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            goto start;
                        break;
                    }
                case 3:
                    {
                        ControlModul.PrintALlQueriesToAdd(ref modul);
                        Console.WriteLine("Для выхода в меню нажмите ENTER");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            goto start;
                        break;
                    }
                case 4:
                    {
                        ControlModul.AddPatientToOrganization(ref modul);
                        Console.WriteLine("Для выхода в меню нажмите ENTER");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            goto start;
                        break;
                    }

            }



            Console.ReadLine();
        }


    }
}
