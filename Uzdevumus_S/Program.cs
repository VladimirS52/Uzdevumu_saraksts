using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzdevumus_S
{
    internal class Program
    {
        static List<TaskItem> uzdevumi = new List<TaskItem>();
        class TaskItem
        {
            public string Nosaukums { get; set; }
            public bool Izpildits { get; set; }
        }
        static void Main(string[] args)
        {
            bool turpinat = true;

            while (turpinat)
            {
                Console.Clear();
                Console.WriteLine("1 - Parādīt uzdevumus");
                Console.WriteLine("2 - Pievienot uzdevumu");
                Console.WriteLine("3 - Atzīmēt uzdevumu kā izpildītu");
                Console.WriteLine("4 - Dzēst uzdevumu");
                Console.WriteLine("0 - Iziet");
                Console.Write("Izvēlies darbību: ");

                string izvele = Console.ReadLine();

                switch (izvele)
                {
                    case "1":
                        ParaditUzdevumus();
                        break;
                    case "2":
                        PievienotUzdevumu();
                        break;
                    case "3":
                        AtzimetKaIzpilditu();
                        break;
                    case "4":
                        DzesUzdevumu();
                        break;
                    case "0":
                        turpinat = false;
                        break;
                    default:
                        Console.WriteLine("Nepareiza izvēle.");
                        Pauze();
                        break;
                }
            }
        }
        static void ParaditUzdevumus()
        {
            Console.Clear();
            Console.WriteLine("VISI UZDEVUMI");

            if (uzdevumi.Count == 0)
            {
                Console.WriteLine("Uzdevumu saraksts ir tukšs.");
            }
            else
            {
                for (int i = 0; i < uzdevumi.Count; i++)
                {
                    string statuss = uzdevumi[i].Izpildits ? "[Izpildīts]" : "[Nav izpildīts]";
                    Console.WriteLine((i + 1) + ". " + uzdevumi[i].Nosaukums + " " + statuss);
                }
            }

            Pauze();
        }

        static void PievienotUzdevumu()
        {
            Console.Clear();
            Console.WriteLine("PIEVIENOT UZDEVUMU");
            Console.Write("Ievadi uzdevuma nosaukumu: ");

            string nosaukums = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nosaukums))
            {
                TaskItem jaunsUzdevums = new TaskItem();
                jaunsUzdevums.Nosaukums = nosaukums;
                jaunsUzdevums.Izpildits = false;

                uzdevumi.Add(jaunsUzdevums);
                Console.WriteLine("Uzdevums pievienots.");
            }
            else
            {
                Console.WriteLine("Nosaukums nevar būt tukšs.");
            }

            Pauze();
        }

        static void AtzimetKaIzpilditu()
        {
            Console.Clear();
            Console.WriteLine("ATZĪMĒT KĀ IZPILDĪTU");

            if (uzdevumi.Count == 0)
            {
                Console.WriteLine("Nav neviena uzdevuma.");
                Pauze();
                return;
            }

            for (int i = 0; i < uzdevumi.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + uzdevumi[i].Nosaukums);
            }

            Console.Write("Ievadi uzdevuma numuru: ");
            string ievade = Console.ReadLine();

            int numurs;
            if (int.TryParse(ievade, out numurs))
            {
                if (numurs >= 1 && numurs <= uzdevumi.Count)
                {
                    uzdevumi[numurs - 1].Izpildits = true;
                    Console.WriteLine("Uzdevums atzīmēts kā izpildīts.");
                }
                else
                {
                    Console.WriteLine("Nepareizs numurs.");
                }
            }
            else
            {
                Console.WriteLine("Jāievada skaitlis.");
            }

            Pauze();
        }

        static void DzesUzdevumu()
        {
            Console.Clear();
            Console.WriteLine("DZĒST UZDEVUMU");

            if (uzdevumi.Count == 0)
            {
                Console.WriteLine("Nav neviena uzdevuma.");
                Pauze();
                return;
            }

            for (int i = 0; i < uzdevumi.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + uzdevumi[i].Nosaukums);
            }

            Console.Write("Ievadi dzēšamā uzdevuma numuru: ");
            string ievade = Console.ReadLine();

            int numurs;
            if (int.TryParse(ievade, out numurs))
            {
                if (numurs >= 1 && numurs <= uzdevumi.Count)
                {
                    uzdevumi.RemoveAt(numurs - 1);
                    Console.WriteLine("Uzdevums dzēsts.");
                }
                else
                {
                    Console.WriteLine("Nepareizs numurs.");
                }
            }
            else
            {
                Console.WriteLine("Jāievada skaitlis.");
            }

            Pauze();
        }

        static void Pauze()
        {
            Console.WriteLine();
            Console.WriteLine("Nospied Enter, lai turpinātu...");
            Console.ReadLine();
        }
    }
}

