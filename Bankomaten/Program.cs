using System;
using System.Collections.Generic;
using System.Threading;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sumAccount1 = 0;
            decimal sumAccount2 = 0;
            decimal sumAccount3 = 0;

            bool runProgram = true;

            while (runProgram)
            {
                /*Tvådimensionell array som hanterar 
                 programmets 5 användare, där var och en har plats för 6 värden.
                 Värdet på första indexplatsen i arrayen följer den enskilda användaren.
                 Värdet på andra indexplatsen i arrayen håller följande värden:
                 0 = namn 
                 1 = lösenord 
                 2 = bankkonto 1
                 3 = summa bankkonto 1
                 4 = bankkonto 2
                 5 = summa bankkonto 2*/

                string[,] users = new string[5, 8];

                //Användare 1
                users[0, 0] = "JENNY"; //Namn
                users[0, 1] = "1234";//Lösenord
                users[0, 2] = "Lönekonto Jenny"; //Bankkonto 1            
                users[0, 3] = "30000"; //Summa konto 1
                users[0, 4] = "Sparkonto Jenny"; //Bankkonto 2
                users[0, 5] = "300000"; //Summa konto 2
                users[0, 6] = "Resekonto";
                users[0, 7] = "2000";

                //Användare 2
                users[1, 0] = "THOMAS"; //Namn
                users[1, 1] = "8181";//Lösenord
                users[1, 2] = "Lönekonto"; //Bankkonto 1
                users[1, 3] = "50000"; //Summa konto 1
                users[1, 4] = "Sparkonto"; //Bankkonto 2
                users[1, 5] = "500000"; //Summa konto 2
                users[1, 6] = "Företagskonto";
                users[1, 7] = "580000";


                //Användare 3
                users[2, 0] = "ALMA"; //Namn
                users[2, 1] = "1212";//Lösenord
                users[2, 2] = "Toca Boca konto"; //Bankkonto 1
                users[2, 3] = "100"; //Summa konto 1
                users[2, 4] = "Alma sparkonto"; //Bankkonto 2
                users[2, 5] = "9000"; //Summa konto 2
                users[2, 6] = null;
                users[2, 7] = "";

                //Användare 4
                users[3, 0] = "VIKTOR"; //Namn
                users[3, 1] = "1313";//Lösenord
                users[3, 2] = "Viktor veckopengar"; //Bankkonto 1
                users[3, 3] = "8000"; //Summa konto 1
                users[3, 4] = "PS5 sparkonto"; //Bankkonto 2
                users[3, 5] = "3400"; //Summa konto 1
                users[3, 6] = null;
                users[3, 7] = "";

                //Användare 5
                users[4, 0] = "FELIX"; //Namn
                users[4, 1] = "1818";//Lösenord
                users[4, 2] = "Felix Super Mario konto"; //Bankkonto 1
                users[4, 3] = "1000"; //Summa konto 1
                users[4, 4] = null;
                users[4, 5] = "";
                users[4, 6] = null;
                users[4, 7] = "";

                int userNumber = 0;

                string userName = "";
                Console.WriteLine("\n\n\t\tVÄLKOMMEN TILL BANKEN ");

                if (CheckValidUser(users, ref userNumber))

                {
                    userName = users[userNumber, 0];

                    Console.WriteLine("\n\n\t\tVälkommen {0}. Du loggas in.", userName);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\n\n\t\tDu har angett fel lösenord 3 gånger. " +
                                      "\n\n\t\tProgrammet stängs ner. Välkommen åter.");

                    Environment.Exit(0); //Stänger ner programmet då fel lösenord angetts 3 gånger
                }

                /*Här kontrolleras innehållet i arrayerna som håller konton, för att undvika att försöka konvertera
                 tomma konton och därmed hamna utanför index
                 */

                if (users[userNumber, 4] != null && (users[userNumber, 6] != null))
                {
                    sumAccount1 = Convert.ToDecimal(users[userNumber, 3]);
                    sumAccount2 = Convert.ToDecimal(users[userNumber, 5]);
                    sumAccount3 = Convert.ToDecimal(users[userNumber, 7]);
                }

                else if (users[userNumber, 4] != null && (users[userNumber, 6] == null))

                {
                    sumAccount1 = Convert.ToDecimal(users[userNumber, 3]);
                    sumAccount2 = Convert.ToDecimal(users[userNumber, 5]);
                }

                else if (users[userNumber, 4] == null && (users[userNumber, 6] == null))

                {
                    sumAccount1 = Convert.ToDecimal(users[userNumber, 3]);
                }

                bool runMenu = true; //Menyn kör så länge villkoret är sant
                int menuChoice = 0;

                do
                {
                    Console.Clear();


                    //Presenterar menyn för användaren

                    Console.WriteLine("\n\n\t\tVad vill du göra?" +
                                       "\n\n\t\t1 Se dina konton och saldo" +
                                       "\n\n\t\t2 Överföring mellan konton" +
                                       "\n\n\t\t3 Ta ut pengar" +
                                       "\n\n\t\t4 Logga ut" +
                                       "\n\n\t\tVälj en siffra mellan 1 och 4 och tryck enter");
                    try
                    {
                        menuChoice = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("\n\n\t\tFel! Du måste ange ett nummer.");    //Felmeddelande om inte tal mellan 1 - 4 angetts
                                                                                        //Användaren skickas tillbaka till menypresentation
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }

                    Console.Clear();

                    switch (menuChoice)
                    {
                        case 1:

                            if (userNumber == 0) //Presentation av användare 1's konton
                            {
                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr " +
                                "\n\n\t\t{2}: {3}kr" +
                                "\n\n\t\t{4}: {5}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);

                            }

                            else if (userNumber == 1) //Presentation av användare 2's konton
                            {
                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                               "\n\n\t\t{0}: {1}kr " +
                               "\n\n\t\t{2}: {3}kr" +
                               "\n\n\t\t{4}: {5}kr",
                               users[userNumber, 2], sumAccount1,
                               users[userNumber, 4], sumAccount2,
                               users[userNumber, 6], sumAccount3);
                            }

                            else if (userNumber == 2) //Presentation av användare 3's konton

                            {
                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr " +
                                "\n\n\t\t{2}: {3}kr",
                                users[2, 2], sumAccount1,
                                users[2, 4], sumAccount2);

                            }
                            else if (userNumber == 3) //Presentation av användare 4's konton
                            {
                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr " +
                                "\n\n\t\t{2}: {3}kr",
                                users[3, 2], sumAccount1,
                                users[3, 4], sumAccount2);

                            }

                            else if (userNumber == 4) //Presentation av användare 5's konton
                            {

                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr ",
                                users[4, 2], sumAccount1);
                            }

                            GoToMenu(); //Metod för att gå till menystart

                            break;

                        case 2:

                            if (userNumber == 0 || userNumber == 1)
                            //Här kan användare 1 eller 2 föra över pengar mellan sina egna konton. Anropar metoden 
                            //MoneyTransfer som kan ta tre summor (sumAccount 1, 2 och 3) och anger dessa
                            //som referens för att den ändrade summan ska följa med till Main
                            {
                                MoneyTransfer(userNumber, users, ref sumAccount1, ref sumAccount2, ref sumAccount3);

                                Console.WriteLine("\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr" +
                                "\n\n\t\t3. {4}: {5}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);
                            }

                            else if (userNumber == 2 || userNumber == 3)
                            //Här kan användare 3 eller 4 föra över pengar mellan sina egna konton. Anropar metoden 
                            //MoneyTransfer som kan ta två summor (sumAccount 1 och 2) och anger dessa
                            //som referens för att den ändrade summan ska följa med till Main
                            {
                                MoneyTransfer(userNumber, users, ref sumAccount1, ref sumAccount2);

                                Console.WriteLine("\n\n\t\t{0}: {1}kr " +
                                "\n\n\t\t{2}: {3}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);
                            }

                            else if (userNumber == 4)
                            {
                                Console.WriteLine("\n\n\t\tTillgängliga konton: " +
                                "\n\n\t\t{0}: {1}kr ",
                                users[userNumber, 2], sumAccount1);
                                Console.WriteLine("\n\n\t\tDu har inga andra konton att föra över pengar till.");
                            }

                            GoToMenu();

                            break;

                        case 3:


                            if (userNumber == 0 || userNumber == 1)
                            {
                                /*Här kan användare 1 och 2 ta ut pengar genom metoden MoneyWithdrawal med tre paramentrar
                                för summor (sumAccount 1, 2 och 3) som även här anges som referens för att ändrade summor
                                ska följa med ut i Main*/

                                MoneyWithdrawal(users, userNumber, ref sumAccount1, ref sumAccount2, ref sumAccount3);
                                Console.WriteLine("\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr" +
                                "\n\n\t\t3. {4}: {5}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);
                            }

                            else if (userNumber == 2 || userNumber == 3)

                            /*Här kan användare 3 och 4 ta ut pengar genom metoden MoneyWithdrawal med två paramentrar
                            för summor (sumAccount 1 och 2) som även här anges som referens för att ändrade summor
                            ska följa med ut i Main*/
                            {
                                MoneyWithdrawal(users, userNumber, ref sumAccount1, ref sumAccount2);
                                Console.WriteLine("\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);
                            }

                            else if (userNumber == 4)

                            /*Här kan användare 5 ta ut pengar genom metoden MoneyWithdrawal med en paramenter
                            för summor (sumAccount 1) som även här anges som referens för att ändrad summa
                            ska följa med ut i Main*/
                            {
                                MoneyWithdrawal(users, userNumber, ref sumAccount1);
                                Console.WriteLine("\n\n\t\t1. {0}: {1}kr",
                                users[userNumber, 2], sumAccount1);
                            }

                            GoToMenu();

                            break;

                        case 4:
                            runMenu = false;        //Loggar ut användaren och återgår till inloggning

                            Console.WriteLine("\n\n\t\tDu loggas ut.");
                            System.Threading.Thread.Sleep(1000);

                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("\n\n\t\tOgiltigt val."); //Felmeddelande om användaren inte väljer enligt menyn

                            GoToMenu();

                            break;
                    }
                }
                while (runMenu);
            }

        }
        static bool CheckValidUser(string[,] users, ref int userNumber)
        {
            /* Metod för att kolla om användarnamnet som användaren angett finns i sträng arrayen users[,] och om lösenordet
               som användaren anger är korrekt. Första indexvärdet är användarens nummer och kommer öka med 1, 
               i loopen så länge användarnamnet inte hittats. 
               Andra indexvärdet hålls konstant på 0, då det är här användarnamnen finns.
               Tar emot parametrarna för arrayen users och för userName. Returnerar sant om användarnamnet hittats,
               annars falskt.*/

            bool findUser = true;

            int validUser = 0;

            while (findUser)
            {
                Console.WriteLine("\n\n\t\tSkriv ditt användarnamn");

                string userName = Console.ReadLine().ToUpper(); //Läser in från användaren och omvandlar till 
                                                                //inläst text till stora bokstäver

                Console.Clear();

                for (int i = 0; i < users.GetLength(0); i++)    //Loop som fortsätter lika många varv som max värdet
                                                                // på sträng arrayen users första indexplats. För att
                                                                //inte orsaka out of range under körning
                {
                    if (userName == users[i, 0])
                    {
                        userNumber = i;                         //Definierar värdet på första arrayindexet i users som
                                                                //usernumber, för tydlighet. Värdet kommer användas i funktioner
                                                                //för att hitta gällande användares övriga värden på andra index-
                                                                //platsen
                    }
                }

                if (userName != users[userNumber, 0])           //Om inläst användarnamn inte finns i users, skickas användaren
                                                                //tillbaka med hjälp av continue och får skriva in nytt användarnamn.
                                                                //Obegränsat antal försök att hitta användarnamn.
                {
                    Console.WriteLine("\n\n\t\tOkänd användare.");
                    continue;
                }
                for (int x = 0; x < 3; x++)                     //Loop som startar om användarnamnet finns i users. Kollar om inläst
                                                                //lösenord finns på plats 1 på andra indexvärdet. Användaren har tre
                                                                //försök att hitta rätt lösenord
                {
                    Console.WriteLine("\n\n\t\tAnge lösenord");

                    string tryPass = Console.ReadLine();

                    Console.Clear();

                    if (tryPass == users[userNumber, 1])        //Om lösenordet är rätt tilldelas variabeln validUser värdet 1, som
                                                                //sedan används för att sätta metodens bool till sann
                    {
                        validUser = 1;
                        findUser = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\n\n\t\tFel lösenord");

                    }
                }
                findUser = false;
            }
            if (validUser == 1)     //Returnerar "sant" om användarnamn och tillsvarandes
                                    //lösenord hittats
            {
                return true;
            }
            else                    //Returnerar "falskt" om lösenordet inte hittats på tre försök
            {
                return false;
            }
        }

        static void GoToMenu()      //Metod som skickar tillbaka användaren till menyval efter 
                                    //tryck på enter. Används för att skapa tydlighet.
        {
            Console.WriteLine("\n\n\t\tTryck enter för att komma till huvudmenyn.");
            Console.ReadLine();
        }
        static void MoneyTransfer(int userNumber, string[,] users, ref decimal sumAccount1, ref decimal sumAccount2, ref decimal sumAccount3)

        /*Metod för att föra över pengar för de användare som har tre konton. Den har därför parametrar för tre summor
         (sumAccount 1, 2 och 3) som här satts som referens då de ändras i metoden, och ändringarna ska följa med ut i Main. Användaren 
        kan bara välja överföringskonto och mottagarkonto mellan sina egna konton. Felmeddelande om pengar saknas på valda överföringskontot,
        eller om vald summa överstiger tillgångarna på överföringskontot*/
        {
            bool isRunning = true;

            decimal transferAmount = 0;

            Console.WriteLine("\n\n\t\tVälj konto att föra över pengar ifrån: " +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr " +
                                 "\n\n\t\t3. {4}: {5}kr ",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);

            string transferAccount = Console.ReadLine();

            Console.WriteLine("\n\n\t\tVälj konto att föra över pengar till: " +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr " +
                                 "\n\n\t\t3. {4}: {5}kr ",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);

            string reciverAccount = Console.ReadLine();

            Console.Clear();

            while (isRunning)
            {
                if (transferAccount == "1" && sumAccount1 == 0 ||
                    transferAccount == "2" && sumAccount2 == 0 ||
                    transferAccount == "3" && sumAccount3 == 0)
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
                else if (transferAccount == "1" && sumAccount1 != 0 && reciverAccount == "3")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 2], sumAccount1,
                                        users[userNumber, 6], sumAccount3);

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
                                sumAccount3 = sumAccount3 + transferAmount;

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
                else if (transferAccount == "2" && sumAccount2 != 0 && reciverAccount == "3")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 4], sumAccount2,
                                        users[userNumber, 6], sumAccount3);

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
                                sumAccount3 = sumAccount3 + transferAmount;

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
                else if (transferAccount == "3" && sumAccount2 != 0 && reciverAccount == "1")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 6], sumAccount3,
                                        users[userNumber, 2], sumAccount1);

                    bool validAmount = true;

                    while (validAmount)
                    {
                        Console.WriteLine("\n\n\t\tVilken summa vill du föra över?");

                        try
                        {
                            transferAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Clear();

                            if (sumAccount3 >= transferAmount)
                            {
                                sumAccount3 = sumAccount3 - transferAmount;
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
                else if (transferAccount == "3" && sumAccount2 != 0 && reciverAccount == "2")
                {
                    Console.WriteLine("\n\n\t\tDu kommer nu föra över pengar från: " +
                                        "\n\n\t\t{0}: {1}kr " +
                                        "\n\n\t\t\ttill \n\n\t\t{2}: {3}kr"
                                        , users[userNumber, 6], sumAccount3,
                                        users[userNumber, 4], sumAccount2);

                    bool validAmount = true;

                    while (validAmount)
                    {
                        Console.WriteLine("\n\n\t\tVilken summa vill du föra över?");

                        try
                        {
                            transferAmount = Convert.ToDecimal(Console.ReadLine());

                            Console.Clear();

                            if (sumAccount3 >= transferAmount)
                            {
                                sumAccount3 = sumAccount3 - transferAmount;
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
        static void MoneyTransfer(int userNumber, string[,] users, ref decimal sumAccount1, ref decimal sumAccount2)
        {
            /*Metoden har samma funktion som föregående, förutom att den endast har parametrar för två summor(sumAccount 1 och 2, anginva som referens) 
            och därför används metoden för användare som har två konton.*/

            bool isRunning = true;

            decimal transferAmount = 0;

            Console.WriteLine("\n\n\t\tVälj konto att föra över pengar ifrån: " +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr ",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2);

            string transferAccount = Console.ReadLine();

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

        static void MoneyWithdrawal(string[,] users, int userNumber, ref decimal sumAccount1, ref decimal sumAccount2, ref decimal sumAccount3)
        {
            /*Metod för att ta ut pengar från egna konton för de användare som har tre konton. Den har därför parametrar för tre summor
             (sumAccount 1, 2 och 3) som här satts som referens då de ändras i metoden, och ändringarna ska följa med ut i Main. Användaren måste
            ange korrekt lösenord för att uttaget ska genomföras. Vid fel lösenord skickas användaren tillbaka till Main. Felmeddelande om 
            pengar saknas på valda kontot, eller om vald summa överstiger tillgångarna på kontot*/
            bool isRunning = true;

            bool isDecimal = true;

            string tempStr = "";

            Console.WriteLine("\n\n\t\tVälj vilket konto du vill ta ut pengar ifrån." +
                                "\n\n\t\t1. {0}: {1}kr " +
                                "\n\n\t\t2. {2}: {3}kr" +
                                "\n\n\t\t3. {4}: {5}kr",
                                users[userNumber, 2], sumAccount1,
                                users[userNumber, 4], sumAccount2,
                                users[userNumber, 6], sumAccount3);

            Int32.TryParse(Console.ReadLine(), out int chosenAccount);

            Console.Clear();

            while (isRunning)
            {
                if (chosenAccount == 1 && sumAccount1 == 0 ||
                    chosenAccount == 2 && sumAccount2 == 0 ||
                    chosenAccount == 3 && sumAccount3 == 0)
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
                else if (chosenAccount == 3 && sumAccount3 != 0)
                {
                    Console.WriteLine("\n\n\t\tTillgänglig summa {0}: {1} kr",
                                    users[userNumber, 6], sumAccount3);

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

                                    sumAccount3 = sumAccount3 - transferAmount;

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
                            break;
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
        /*Samma funktion som ovanstående metod med samma namn, men här med endast två parametrar för summor (sumAccount 1 och 2,
        satta som referens). Används därför av de användare som har två konton.*/
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

                                Console.Clear();

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

                                Console.Clear();

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
        static void MoneyWithdrawal(string[,] users, int userNumber, ref decimal sumAccount1)
        /*Samma funktion som ovanstående metod med samma namn, men här med endast en parameter för summor (sumAccount 1, satt som referens).
         Används därför av användare med 1 konto.*/
        {
            bool isRunning = true;

            bool isDecimal = true;

            string tempStr = "";

            Console.WriteLine("\n\n\t\tVälj vilket konto du vill ta ut pengar ifrån." +
                            "\n\n\t\t1. {0}: {1}kr ",
                            users[userNumber, 2], sumAccount1);

            Int32.TryParse(Console.ReadLine(), out int chosenAccount);

            Console.Clear();

            while (isRunning)
            {
                if (chosenAccount == 1 && sumAccount1 == 0)
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

                                Console.Clear();

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
                            break;
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

