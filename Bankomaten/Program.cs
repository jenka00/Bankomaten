using System;
using System.Collections.Generic;
using System.Threading;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] users = new string[5, 5];

            //Användare 1
            users[0, 0] = "Jenny"; //Namn
            users[0, 1] = "1234";//Lösenord
            users[0, 2] = "Lönekonto"; //Bankkonto 1
            users[0, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 2
            users[1, 0] = "Thomas"; //Namn
            users[1, 1] = "8181";//Lösenord
            users[1, 2] = "Lönekonto"; //Bankkonto 1
            users[1, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 3
            users[2, 0] = "Alma"; //Namn
            users[2, 1] = "1212";//Lösenord
            users[2, 2] = "Lönekonto"; //Bankkonto 1
            users[2, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 4
            users[3, 0] = "Viktor"; //Namn
            users[3, 1] = "1313";//Lösenord
            users[3, 2] = "Lönekonto"; //Bankkonto 1
            users[3, 3] = "Sparkonto"; //Bankkonto 2

            //Användare 5
            users[4, 0] = "Felix"; //Namn
            users[4, 1] = "1818";//Lösenord
            users[4, 2] = "Lönekonto"; //Bankkonto 1
            users[4, 3] = "Sparkonto"; //Bankkonto 2

            Console.WriteLine("Skriv ditt användarnamn");
            string userName = Console.ReadLine().ToUpper();

            //Console.WriteLine("Skriv ditt lösenord");
            //string password = Console.ReadLine();

            if (LogIn(users, userName))

            {
                Console.WriteLine("Välkommen {0}. Du loggas in", userName);
            }
            else
            {
                Console.WriteLine("Du har angett fel lösenord 3 gånger. Programmet stängs ner. Välkommen åter.");
                Environment.Exit(0); //Stänger ner programmet
            }

            Menu();

            ShowAccount();
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
                        if (users[i, 0].ToUpper() == userName)
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

            {
                return false;
            }
        }
        static void Menu()
        {
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
                        ShowAccount();
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
        static void ShowAccount()
        {

        }
    }
}