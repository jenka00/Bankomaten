using System;
using System.Collections.Generic;
using System.Threading;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            do
            {
                string[,] users = new string[5, 6];

                //Användare 1
                users[0, 0] = "JENNY"; //Namn
                users[0, 1] = "1234";//Lösenord
                users[0, 2] = "Lönekonto Jenny"; //Bankkonto 1            
                users[0, 3] = "30000"; //Summa konto 1
                users[0, 4] = "Sparkonto Jenny"; //Bankkonto 2
                users[0, 5] = "300000"; //Summa konto 2

                //Användare 2
                users[1, 0] = "THOMAS"; //Namn
                users[1, 1] = "8181";//Lösenord
                users[1, 2] = "Lönekonto"; //Bankkonto 1
                users[1, 3] = "50000"; //Summa konto 1
                users[1, 4] = "Sparkonto"; //Bankkonto 2
                users[1, 5] = "500000"; //Summa konto 2


                //Användare 3
                users[2, 0] = "ALMA"; //Namn
                users[2, 1] = "1212";//Lösenord
                users[2, 2] = "Alma veckopengar"; //Bankkonto 1
                users[2, 3] = "12000"; //Summa konto 1
                users[2, 4] = "Alma sparkonto"; //Bankkonto 2
                users[2, 5] = "50000"; //Summa konto 2

                //Användare 4
                users[3, 0] = "VIKTOR"; //Namn
                users[3, 1] = "1313";//Lösenord
                users[3, 2] = "Viktor veckopengar"; //Bankkonto 1
                users[3, 3] = "8000"; //Summa konto 1
                users[3, 4] = "PS5 sparkonto"; //Bankkonto 2
                users[3, 5] = "3400"; //Summa konto 1

                //Användare 5
                users[4, 0] = "FELIX"; //Namn
                users[4, 1] = "1818";//Lösenord
                users[4, 2] = "Felix veckopengar"; //Bankkonto 1
                users[4, 3] = "4000"; //Summa konto 1
                users[4, 4] = "Felix sparkonto"; //Bankkonto 2
                users[4, 5] = "30000"; //Summa konto 2

                Console.WriteLine("\n\n\t\tVÄLKOMMEN TILL BANKEN ");

                Console.WriteLine("\n\n\t\tSkriv ditt användarnamn");

                string userName = Console.ReadLine().ToUpper();

                if (LogIn(users, userName))

                {
                    Console.WriteLine("\n\n\t\tVälkommen {0}. Du loggas in.", userName);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\n\n\t\tDu har angett fel lösenord 3 gånger. " +
                                      "\n\t\tProgrammet stängs ner. Välkommen åter.");

                    Environment.Exit(0); //Stänger ner programmet
                }

                int userNumber = FindUserNumber(users, userName);

                decimal sumAccount1 = Convert.ToDecimal(users[userNumber, 3]);
                decimal sumAccount2 = Convert.ToDecimal(users[userNumber, 5]);

                bool runMenu = true;
                int menuChoice = 0;

                do
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\t\tVad vill du göra?" +
                                       "\n\n\t\t1. Se dina konton och saldo" +
                                       "\n\n\t\t2. Överföring mellan konton" +
                                       "\n\n\t\t3. Ta ut pengar" +
                                       "\n\n\t\t4. Logga ut");
                    try
                    {
                        menuChoice = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("\n\n\t\tFel! Du måste ange ett nummer.");
                        continue;
                    }

                    Console.Clear();

                    switch (menuChoice)
                    {
                        case 1:
                            ShowAccount(users, userNumber, sumAccount1, sumAccount2);
                            GoToMenu();
                            break;

                        case 2:
                            MoneyTransfer(users, userNumber, ref sumAccount1, ref sumAccount2);

                            Console.WriteLine("\n\n\t\t{0}: {1} kr " +
                                              "\n\n\t\t{2}: {3} kr",
                                              users[userNumber, 2], sumAccount1,
                                              users[userNumber, 4], sumAccount2);
                            GoToMenu();
                            break;

                        case 3:
                            MoneyWithdrawal(users, userNumber, ref sumAccount1, ref sumAccount2);

                            Console.WriteLine("\n\n\t\t{0}: {1} kr " +
                                                "\n\n\t\t{2}: {3} kr",
                                                users[userNumber, 2], sumAccount1,
                                                users[userNumber, 4], sumAccount2);

                            GoToMenu();
                            break;

                        case 4:
                            runMenu = false;
                            Console.WriteLine("\n\n\t\tDu loggas ut.");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            break; ;

                        default:
                            Console.WriteLine("\n\n\t\tOgiltigt val.");
                            GoToMenu();
                            break;
                    }
                }
                while (runMenu);
            }
            while (runProgram);
        }

        static bool LogIn(string[,] users, string userName)
        {
            bool isChecking = false;
            int tryPass = 0;

            while (tryPass < 3)
            {
                Console.WriteLine("\n\t\tSkriv ditt lösenord");

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
                            Console.WriteLine("\n\n\t\tFel lösenord.");

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

        static int FindUserNumber(string[,] users, string userName)
        {
            int userNumber = 0;
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == userName)

                {
                    userNumber = i;
                }
            }
            return userNumber;
        }
        static void GoToMenu()
        {
            Console.WriteLine("\n\n\t\tTryck enter för att komma till huvudmenyn.");
            Console.ReadLine();
        }

        static void ShowAccount(string[,] users, int userNumber, decimal sumAccount1, decimal sumAccount2)
        {
            Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr " +
                                "\n\n\t\t{2}: {3}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);
        }

        static void MoneyTransfer(string[,] users, int userNumber, ref decimal sumAccount1, ref decimal sumAccount2)
        {
            bool isRunning = true;

            decimal transferAmount = 0;

            Console.WriteLine("\n\n\t\tVälj konto att föra över pengar ifrån: " +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr ",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);

            string transferAccount = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n\t\tVälj konto att föra över pengar till: " +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr ",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);

            string reciverAccount = Console.ReadLine();

            Console.Clear();

            while (isRunning)
            {
                if (transferAccount == "1" && sumAccount1 == 0 || transferAccount == "2" && sumAccount2 == 0)
                {
                    Console.WriteLine("\n\n\t\tDu har inga pengar på det valda kontot.");
                    break;
                }

                else if (transferAccount == "1" && sumAccount1 != 0 && reciverAccount == "2")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 2], sumAccount1,
                                        users[userNumber, 4], sumAccount2);

                    bool validAmount = true;

                    while (validAmount)
                    {
                        Console.WriteLine("\n\n\t\tVilken summa vill du föra över?");

                        try
                        {
                            transferAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Clear();

                            if (sumAccount1 >= transferAmount)
                            {
                                sumAccount1 = sumAccount1 - transferAmount;
                                sumAccount2 = sumAccount2 + transferAmount;

                                Console.WriteLine("\n\n\t\tTillgänglig summa efter överföring: ");

                                validAmount = false;
                                isRunning = false;
                            }

                            else
                            {
                                Console.WriteLine("\n\n\t\tDu har inte tillräckligt med pengar på kontot. Välj en lägre summa.");
                            }
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\t\tAnge summan i siffror.");
                            break;
                        }
                    }
                }

                else if (transferAccount == "2" && sumAccount2 != 0 && reciverAccount == "1")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 4], sumAccount2,
                                        users[userNumber, 2], sumAccount1);

                    bool validAmount = true;

                    while (validAmount)
                    {
                        Console.WriteLine("\n\n\t\tVilken summa vill du föra över?");

                        try
                        {
                            transferAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Clear();

                            if (sumAccount2 >= transferAmount)
                            {
                                sumAccount2 = sumAccount2 - transferAmount;
                                sumAccount1 = sumAccount1 + transferAmount;

                                Console.WriteLine("\n\n\t\tTillgänglig summa efter överföring: ");

                                validAmount = false;
                                isRunning = false;
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t\tDu har inte tillräckligt med pengar på kontot. Välj en lägre summa.");
                            }
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\t\tAnge summan i siffror.");
                        }
                    }
                }
               
                else
                {
                    Console.WriteLine("\n\n\t\tOgiltigt val.");
                    break;
                }
            }
        }
        static void MoneyWithdrawal(string[,] users, int userNumber, ref decimal sumAccount1, ref decimal sumAccount2)
        {
            bool isRunning = true;

            bool isDecimal = true;

            string tempStr = "";

            Console.WriteLine("\n\n\t\tVälj vilket konto du vill ta ut pengar ifrån." +
                            "\n\n\t\t1. {0}: {1}kr " +
                            "\n\n\t\t2. {2}: {3}kr",
                            users[userNumber, 2], sumAccount1,
                            users[userNumber, 4], sumAccount2);

            Int32.TryParse(Console.ReadLine(), out int chosenAccount);

            Console.Clear();

            while (isRunning)
            {
                if (chosenAccount == 1 && sumAccount1 == 0 || chosenAccount == 2 && sumAccount2 == 0)
                {
                    Console.WriteLine("\n\n\t\tDet finns inga pengar på det valda kontot.");
                    break;
                }

                else if (chosenAccount == 1 && sumAccount1 != 0)
                {
                    Console.WriteLine("\n\n\t\tTillgänglig summa {0}: {1} kr",
                                    users[userNumber, 2], sumAccount1);

                    Console.WriteLine("\n\n\t\tVilken summa vill du ta ut?");

                    tempStr = Console.ReadLine();

                    Console.Clear();

                    while (isDecimal)
                    {
                        try
                        {
                            decimal transferAmount = Convert.ToDecimal(tempStr);

                            Console.Clear();

                            if (sumAccount1 >= transferAmount)
                            {
                                Console.WriteLine("\n\n\t\tAnge ditt lösenord för att genomföra uttaget. ");

                                string pin = Console.ReadLine();
                                if (pin == users[userNumber, 1])
                                {

                                    sumAccount1 = sumAccount1 - transferAmount;

                                    Console.WriteLine("\n\n\t\tTillgänglig summa efter uttag: ");

                                    isDecimal = false;
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("\n\n\t\tFel kod.");
                                    break;
                                    isRunning = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t\tDu har inte tillräckligt med pengar på kontot. Välj en lägre summa.");
                                break;
                            }
                        }
                        catch
                        {   
                            Console.Clear();

                            Console.WriteLine("\n\n\t\tAnge summan i siffror.");
                            break;
                        }
                    }
                }

                else if (chosenAccount == 2 && sumAccount2 != 0)
                {
                    Console.WriteLine("\n\n\t\tTillgänglig summa {0}: {1} kr",
                                    users[userNumber, 4], sumAccount2);

                    Console.WriteLine("\n\n\t\tVilken summa vill du ta ut?");

                    tempStr = Console.ReadLine();

                    Console.Clear();

                    while (isDecimal)
                    {
                        try
                        {
                            decimal transferAmount = Convert.ToDecimal(tempStr);

                            Console.Clear();

                            if (sumAccount2 >= transferAmount)
                            {
                                Console.WriteLine("\n\n\t\tAnge ditt lösenord för att ta genomföra uttaget.");

                                string pin = Console.ReadLine();

                                if (pin == users[userNumber, 1])
                                {
                                    sumAccount2 = sumAccount2 - transferAmount;

                                    Console.WriteLine("\n\n\t\tTillgänglig summa efter uttag: ");

                                    isDecimal = false;
                                    isRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine("\n\n\t\tFel kod.");
                                    isRunning = false;
                                    break;
                                }
                            }
                        
                            else
                            {
                                Console.WriteLine("\n\n\t\tDu har inte tillräckligt med pengar på kontot. Välj en lägre summa.");
                                break;
                            }
                        }

                        catch
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\t\tAnge summan i siffror.");
                            break; ;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("\n\n\t\tOgiltigt val.");
                    break;
                }
            }
        }
    }
}

