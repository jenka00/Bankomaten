using System;
using System.Collections.Generic;
using System.Threading;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] users = new string[5, 6];

            //Användare 1
            users[0, 0] = "JENNY"; //Namn
            users[0, 1] = "1234";//Lösenord
            users[0, 2] = "Lönekonto Jenny"; //Bankkonto 1            
            users[0, 3] = "50000"; //Summa konto 1
            users[0, 4] = "Sparkonto Jenny"; //Bankkonto 2
            users[0, 5] = "500000"; //Summa konto 2

            //Användare 2
            users[1, 0] = "THOMAS"; //Namn
            users[1, 1] = "8181";//Lösenord
            users[1, 2] = "Lönekonto"; //Bankkonto 1
            users[1, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 3
            users[2, 0] = "ALMA"; //Namn
            users[2, 1] = "1212";//Lösenord
            users[2, 2] = "Lönekonto"; //Bankkonto 1
            users[2, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 4
            users[3, 0] = "VIKTOR"; //Namn
            users[3, 1] = "1313";//Lösenord
            users[3, 2] = "Lönekonto"; //Bankkonto 1
            users[3, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 5
            users[4, 0] = "FELIX"; //Namn
            users[4, 1] = "1818";//Lösenord
            users[4, 2] = "Lönekonto"; //Bankkonto 1
            users[4, 3] = "Sparkonto"; //Bankkonto 2

            Console.WriteLine("Skriv ditt användarnamn");
            string userName = Console.ReadLine().ToUpper();

            if (LogIn(users, userName))

            {
                Console.WriteLine("Välkommen {0}. Du loggas in", userName);
            }
            else
            {
                Console.WriteLine("Du har angett fel lösenord 3 gånger. Programmet stängs ner. Välkommen åter.");
                Environment.Exit(0); //Stänger ner programmet
            }

            bool loop = true;
            int menuChoice = 0;
            do
            {
                Console.WriteLine("\n\t\tVad vill du göra?" +
                                   "\n\n\n\t\t1. Se dina konton och saldo" +
                                   "\n\t\t2. Överföring mellan konton" +
                                   "\n\t\t3. Ta ut pengar" +
                                   "\n\t\t4. Logga ut");
                try
                {
                    menuChoice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Fel! Du måste ange ett nummer.");
                }

                switch (menuChoice)
                {
                    case 1:
                        ShowAccount(users, userName);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            while (loop);
        }

        static bool LogIn(string[,] users, string userName)
        {
            bool isChecking = false;
            int tryPass = 0;

            while (tryPass < 3)
            {
                Console.WriteLine("Skriv ditt lösenord");

                string password = Console.ReadLine();

                Console.Clear();
                for (int i = 0; i < users.GetLength(0); i++)
                {
                    if (users[i, 1] == password)
                    {
                        if (users[i, 0] == userName)
                        {
                            isChecking = true;
                            tryPass = 3;
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Fel lösenord.");

                            break;
                        }
                    }
                }
                tryPass++;
            }
            if (isChecking == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ShowAccount(string[,] users, string userName)
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == userName)
                {
                    Console.WriteLine("Tillgängliga konton: \n{0}: {1}kr \n{2}: {3}kr", users[i, 2], users[i, 3], users[i, 4], users[i, 5]);
                    Console.ReadLine();
                }
            }
        }
    }
}