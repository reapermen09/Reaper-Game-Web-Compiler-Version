using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        private static void PlaySound(string filepath)
        {

        }

        static int taxAmount = 0;
        static int csAmount = 0;
        static bool inPrison = false;
        static bool secretOneFound = false;
        static bool secretTwoFound = false;
        static bool begging = false;
        static bool beatRati = false;
        static bool mratiBeat = false;
        static int money = 10;
        static int points = 0;

        static int GetValidInt()
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a number: ");
                }
            }
        }

        static bool money100 = false;
        static bool money1000 = false;
        static bool money10000 = false;
        static bool money100000 = false;
        static bool money1000000 = false;

        static bool firstTransaction = false;

        static bool foundReaper = false;
        static bool insultReaper = false;
        static bool begReaper = false;

        static bool wentToPrison = false;
        static bool escapedPrison = false;

        static bool points100 = false;
        static bool points1000 = false;
        static bool points10000 = false;
        static bool points100000 = false;
        static bool points1000000 = false;

        static void DisplayAchievements()
        {
            Console.WriteLine("Achievements:");
            if (money100) Console.WriteLine("Novice: 100+ money");
            if (money1000) Console.WriteLine("Grinder Type Guy: 1000+ money");
            if (money10000) Console.WriteLine("Commander: 10000+ money");
            if (money100000) Console.WriteLine("Destroyer Type Guy: 100000+ money");
            if (money1000000) Console.WriteLine("Rich Sigma: 1000000+ money");

            if (firstTransaction) Console.WriteLine("First Transaction: Completed your first transaction");
            if (foundReaper) Console.WriteLine("Finding the Reaper: You found Reaper who gave you 100 money");
            if (insultReaper) Console.WriteLine("Insulting the Reaper: You insulted Reaper, how dare you");
            if (begReaper) Console.WriteLine("Begging: Stop begging Reaper for money, please");

            if (points100) Console.WriteLine("Point Grinder: 100+ points");
            if (points1000) Console.WriteLine("Pointer: 1000+ points");
            if (points10000) Console.WriteLine("Amazing Player: 10000+ points");
            if (points100000) Console.WriteLine("Super Player: 100000+ points");
            if (points1000000) Console.WriteLine("Sigma Player: 1000000+ points");

            if (escapedPrison) Console.WriteLine("Criminal Crime: You escaped prison");
            if (wentToPrison) Console.WriteLine("Law Breaker: You went to prison");

            if (wentToPrison) Console.WriteLine("Rati's Defeat: You defeated Rati");
        }

        static void AchievementReachedCheck(int money, int points)
        {
            if (money >= 100 && !money100)
            {
                Console.WriteLine("You got the Novice achievement! (100+ money)");
                money100 = true;
            }
            if (money >= 1000 && !money1000)
            {
                Console.WriteLine("You got the Grinder Type Guy achievement! (1000+ money)");
                money1000 = true;
            }
            if (money >= 10000 && !money10000)
            {
                Console.WriteLine("You got the Commander achievement! (10000+ money)");
                money10000 = true;
            }
            if (money >= 100000 && !money100000)
            {
                Console.WriteLine("You got the Destroyer Type Guy achievement! (100000+ money)");
                money100000 = true;
            }
            if (money >= 1000000 && !money1000000)
            {
                Console.WriteLine("You got the Rich Sigma achievement! (1000000+ money)");
                money1000000 = true;
            }
            if (points > 0 && !firstTransaction)
            {
                Console.WriteLine("You got the First Transaction achievement! (You did your first transaction)");
                firstTransaction = true;
            }
            if (secretOneFound && !foundReaper)
            {
                Console.WriteLine("Finding the Reaper (You found Reaper who gave you 100 money)");
                foundReaper = true;
            }
            if (secretTwoFound && !insultReaper)
            {
                Console.WriteLine("Insulting the Reaper (You insulted Reaper, how dare you)");
                insultReaper = true;
            }

            if (beatRati && !mratiBeat)
            {
                Console.WriteLine("You got the Boss Defeater achievement! (You beat Rati)\n");
                mratiBeat = true;
            }

            if (begging && !begReaper)
            {
                Console.WriteLine("You got the Begging achievement! (Stop begging Reaper for money, please)");
                begReaper = true;
            }
            if (points >= 100 && !points100)
            {
                Console.WriteLine("You got the Point Grinder achievement! (100+ points)");
                points100 = true;
            }
            if (points >= 1000 && !points1000)
            {
                Console.WriteLine("You got the Pointer achievement! (1000+ points)");
                points1000 = true;
            }
            if (points >= 10000 && !points10000)
            {
                Console.WriteLine("You got the Amazing Player achievement! (10000+ points)");
                points10000 = true;
            }
            if (points >= 100000 && !points100000)
            {
                Console.WriteLine("You got the Super Player achievement! (100000+ points)");
                points100000 = true;
            }
            if (points >= 1000000 && !points1000000)
            {
                Console.WriteLine("You got the Sigma Player achievement! (1000000+ points)");
                points1000000 = true;
            }
        }

        static void DisplayCommands()
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("/help - Show this help message");
            Console.WriteLine("/achievements - Shows your gained achievements");
            Console.WriteLine("/transaction - Convert your money into points (Includes tax)");
            Console.WriteLine("/playagame - Play a math game (Includes tax)");
            Console.WriteLine("/money - Show your money balance");
            Console.WriteLine("/points - Show your points");
            Console.WriteLine("/support - Check support");
            Console.WriteLine("/gamble - Gamble your money for a chance to win (Includes tax)");
            Console.WriteLine("/taxes - Pay your taxes");
            Console.WriteLine("/childsupport - Pay your child support");
            Console.WriteLine("/exit - Exit game");
        }

        static void HandleSupport()
        {
            Console.WriteLine("Game by Reapermen, contact zxteam27@gmail.com for any support or suggestions...");
        }

        static void HandleTransaction(ref int money, ref int points)
        {
            while (true)
            {
                Console.Write($"How much money would you like to convert into points? (Current money: {money}): ");
                int convertAmount = GetValidInt();

                if (convertAmount <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
                else if (convertAmount > money)
                {
                    Console.WriteLine($"You do not have enough money. You only have {money}.");
                    Console.Write("Would you like to try again (y/n)? ");
                    string response = Console.ReadLine();
                    if (response.ToLower() != "y") break;
                }
                else
                {
                    points += convertAmount;
                    money -= convertAmount;
                    Console.WriteLine($"Your points increased by {convertAmount}, and your money decreased by {convertAmount}.");
                    double tax = Math.Ceiling(convertAmount / 4.0);
                    taxAmount += (int)tax;
                    AchievementReachedCheck(money, points);
                    break;
                }
            }
        }

        static void HandlePlayAGame(ref int money, ref int points)
        {
            Random random = new Random();

            while (true)
            {
                int randomNum1 = random.Next(1, 102);
                int randomNum2 = random.Next(1, 102);
                int correctAnswer;
                string operation;

                Console.Write("Choose operation (add/subtract). Adding gives 3 points/money, subtracting gives 5 points/money: ");
                operation = Console.ReadLine();

                if (operation == "add")
                {
                    Console.WriteLine($"What is {randomNum1} + {randomNum2}?");
                    correctAnswer = randomNum1 + randomNum2;
                }
                else if (operation == "subtract")
                {
                    Console.WriteLine($"What is {randomNum1} - {randomNum2}?");
                    correctAnswer = randomNum1 - randomNum2;
                }
                else
                {
                    Console.WriteLine("Invalid operation. Please choose 'add' or 'subtract'.");
                    continue;
                }

                int playerAnswer = GetValidInt();
                if (playerAnswer == correctAnswer)
                {
                    int reward = (operation == "add") ? 3 : 5;
                    money += reward;
                    points += reward;
                    Console.WriteLine($"Correct! Your money and points increased by {reward}.");
                    double tax = Math.Ceiling(reward / 3.0);
                    taxAmount += (int)tax;
                    csAmount += 1;
                    AchievementReachedCheck(money, points);
                    break;
                }
                else
                {
                    Console.Write("Wrong answer! Would you like to try again (y/n)? ");
                    string retry = Console.ReadLine();
                    if (retry.ToLower() != "y") break;
                }
            }
        }

        static void HandleExit()
        {
            DateTime now = DateTime.Now;
            string message = (now.Hour >= 6 && now.Hour < 18) ? "Have a good day!" : "Have a good night!";
            Console.WriteLine($"Exiting game! {message}");
            AchievementReachedCheck(money, points);
        }

        static void HandlePoints(int points)
        {
            Console.WriteLine($"Current points: {points}");
            AchievementReachedCheck(money, points);
        }

        static void HandleMoney(int money)
        {
            Console.WriteLine($"Current money: {money}");
            AchievementReachedCheck(money, points);
        }

        static void HandleGamble(ref int money)
        {
            if (money <= 0)
            {
                Console.WriteLine("You don't have enough money to gamble.");
                return;
            }
        Gamble:
            Console.Write($"How much money would you like to gamble? (Current money: {money}): ");
            int gambleAmount = GetValidInt();

            if (gambleAmount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
                goto Gamble;
            }
            else if (gambleAmount > money)
            {
                Console.WriteLine("You don't have enough money to gamble that amount.");
                return;
            }

            Random random = new Random();
            int chance = new Random().Next(1, 102);
            double chance2 = (random.Next(0, 201) / 100.0) + 1.25;

            if (chance <= 66)
            {
                int winnings = (int)Math.Ceiling(gambleAmount * chance2);
                money += winnings;
                Console.WriteLine($"You won! You gained {winnings} money.");

                int tax = (int)Math.Ceiling(winnings / 3.0);
                taxAmount += tax;
                csAmount += 1;

                AchievementReachedCheck(money, points);
            }
            else
            {
                money -= gambleAmount;
                Console.WriteLine($"You lost! You lost {gambleAmount} money.");

            }
        }

        static void Prison()
        {
            inPrison = true;
            csAmount = 0;

            Console.Clear();
            HandleSupport();
            string options;
            Console.WriteLine("\nYou are in prison for not paying your child support");
            wentToPrison = true;
            AchievementReachedCheck(money, points);

            while (true)
            {
                Console.WriteLine("\nYour options are:");
                Console.WriteLine("1. Math (Medium but free)");
                Console.WriteLine("2. Bribery (Easy but costs money)");
                Console.WriteLine("3. Prisonbreak (Hard but free)");

                options = Console.ReadLine();

                if (options.Equals("Bribery", StringComparison.OrdinalIgnoreCase))
                {
                    if (money <= 0)
                    {
                        Console.WriteLine("You don't have enough money to bribe.");
                        return;
                    }

                    Console.Write($"How much money would you like to bribe? (Current money: {money}) the higher the better chance: ");
                    int bribeAmount = GetValidInt();

                    if (bribeAmount <= 0)
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                        return;
                    }
                    else if (bribeAmount > money)
                    {
                        Console.WriteLine("You don't have enough money to bribe that amount.");
                        return;
                    }

                    int chance = new Random().Next(1, 102);
                    if (chance <= Math.Pow(bribeAmount, 0.75))
                    {
                        Console.WriteLine($"You lost {bribeAmount} money.");
                        Console.WriteLine("YOU ARE OUT OF PRISON!!!");
                        inPrison = false;
                        escapedPrison = true;
                        AchievementReachedCheck(money, points);
                        Thread.Sleep(1000);
                        Game();
                    }
                    else
                    {
                        Console.WriteLine("Your bribe was declined...");
                    }
                }
                else if (options.Equals("Prisonbreak", StringComparison.OrdinalIgnoreCase))
                {
                    int chance = new Random().Next(1, 102);
                    if (chance <= 10)
                    {
                        Console.WriteLine("YOU ARE OUT OF PRISON!!!");
                        inPrison = false;
                        escapedPrison = true;
                        AchievementReachedCheck(money, points);
                        Thread.Sleep(1000);
                        Game();
                    }
                    else
                    {
                        Console.WriteLine("You failed to escape...");
                    }
                }
                else if (options.Equals("Math", StringComparison.OrdinalIgnoreCase))
                {
                    while (true)
                    {
                        int randomNum1 = new Random().Next(100, 1001);
                        int randomNum2 = new Random().Next(100, 1001);
                        int correctAnswer;
                        string operation;

                        Console.Write("Choose operation (add/subtract) numbers are generated randomly from 100 to 1000: ");
                        operation = Console.ReadLine();

                        if (operation == "add")
                        {
                            Console.WriteLine($"What is {randomNum1} + {randomNum2}?");
                            correctAnswer = randomNum1 + randomNum2;
                        }
                        else if (operation == "subtract")
                        {
                            Console.WriteLine($"What is {randomNum1} - {randomNum2}?");
                            correctAnswer = randomNum1 - randomNum2;
                        }
                        else
                        {
                            Console.WriteLine("Invalid operation. Please choose 'add' or 'subtract'.");
                            continue;
                        }

                        int playerAnswer = GetValidInt();
                        if (playerAnswer == correctAnswer)
                        {
                            Console.WriteLine("YOU ARE OUT OF PRISON!!!");
                            inPrison = false;
                            escapedPrison = true;
                            AchievementReachedCheck(money, points);
                            Thread.Sleep(1000);
                            Game();
                            break;
                        }
                        else
                        {
                            Console.Write("Wrong answer! Would you like to try again (y/n)? ");
                            string retry = Console.ReadLine();
                            if (retry.ToLower() != "y") break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid response");
                }
            }
        }

        static void HandleTaxes(ref int money, ref int taxAmount)
        {
            if (taxAmount <= 0)
            {
                Console.WriteLine("You don't owe any taxes right now.");
                return;
            }

            string response;
            do
            {
                Console.WriteLine($"You owe: {taxAmount} in taxes.");
                Console.Write("Would you like to pay the taxes (y/n)? ");
                response = Console.ReadLine();

                if (response.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    while (taxAmount > 0)
                    {
                        Console.Write($"How much money would you like to pay for your taxes? (Current money: {money}, Remaining taxes: {taxAmount}): ");
                        int payment = GetValidInt();

                        if (payment > money)
                        {
                            Console.WriteLine($"You do not have enough money to pay this amount. You only have {money}.");
                        }
                        else if (payment > taxAmount)
                        {
                            Console.WriteLine($"You only owe {taxAmount} in taxes. Enter a smaller amount.");
                        }
                        else if (payment <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a positive number.");
                        }
                        else
                        {
                            money -= payment;
                            taxAmount -= payment;
                            Console.WriteLine($"You paid {payment} in taxes. Your remaining balance is {money}.");
                            if (taxAmount <= 0)
                            {
                                Console.WriteLine("You have fully paid your taxes.");
                                return;
                            }

                            Console.WriteLine($"Remaining taxes: {taxAmount}. Would you like to continue paying? (y/n): ");
                            response = Console.ReadLine();

                            if (!response.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"You chose not to pay any more taxes. Remaining taxes: {taxAmount}.");
                                return;
                            }
                        }
                    }
                }
                else if (!response.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input. Please respond with 'y' or 'n'.");
                }

            } while (!response.Equals("n", StringComparison.OrdinalIgnoreCase));

            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"You chose not to pay taxes. The tax amount remains the same: {taxAmount}.");
            }
        }

        static void ChildSupport(ref int money, ref int childSupportAmount)
        {
            if (childSupportAmount <= 0)
            {
                Console.WriteLine("You don't owe child support.");
                return;
            }

            string response;
            do
            {
                Console.WriteLine($"You owe: {childSupportAmount} in child support.");
                Console.Write("Would you like to pay child support (y/n)? ");
                response = Console.ReadLine();

                if (response.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    if (money >= childSupportAmount)
                    {
                        money -= childSupportAmount;
                        childSupportAmount = 0;
                        Console.WriteLine($"Child support fully paid. Remaining money: {money}");
                        AchievementReachedCheck(money, points);
                    }
                    else
                    {
                        Console.WriteLine($"You do not have enough money to pay the full child support. Paying what you can: {money}");
                        childSupportAmount -= money;
                        money = 0;
                        Console.WriteLine($"Remaining child support amount: {childSupportAmount}");
                    }
                }
                else if (!response.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input. Please respond with 'y' or 'n'.");
                }

            } while (!response.Equals("n", StringComparison.OrdinalIgnoreCase) && childSupportAmount > 0);

            if (childSupportAmount > 0)
            {
                Console.WriteLine($"You still owe {childSupportAmount} in child support. Please pay soon.");
            }
            else
            {
                Console.WriteLine("Child support is fully paid. Thank you!");
            }
        }

        static void TypeEffect(string text, int delayMs)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        static void Mrati()
        {
            int ratiHP = 70;
            int playerHP = 50;
            int playerPotions = 5;
            int money = 0;

            TypeEffect("MRATI: YOUR OPINION DOESN'T MATTER TO A MAN LIKE ME!@#$%\n", 40);
            Thread.Sleep(800);
            TypeEffect("MRATI: I'll make you pay...\n", 40);
            Thread.Sleep(2200);

            while (ratiHP > 0 && playerHP > 0)
            {
                Console.WriteLine("PLAYER'S TURN!!!\n");
                Console.WriteLine($"RATI Health: {ratiHP}");
                Console.WriteLine($"Player Health: {playerHP}\n");

                Console.WriteLine("Attack Options");
                Console.WriteLine("Emotional Damage");
                Console.WriteLine("Tax Forms");
                Console.WriteLine("Child Support");
                if (playerPotions > 0)
                {
                    Console.WriteLine($"Heal ({playerPotions} potions left)");
                }
                Console.WriteLine();

                string input = Console.ReadLine();
                int damageToRat = new Random().Next(1, 12);
                int chance = new Random().Next(1, 102);

                if (input == "Emotional Damage" || input == "emotional damage")
                {
                    TypeEffect("Rolling Dice...\n", 60);
                    Thread.Sleep(400);
                    TypeEffect($"Dice came out as... {damageToRat} damage!\n", 60);

                    if (chance <= 10)
                    {
                        TypeEffect("BUT WAIT... You have missed and caused no emotional damage...\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                    }
                    else
                    {
                        ratiHP -= damageToRat;
                        TypeEffect($"{damageToRat} emotional damage done to rati...\n", 60);
                        TypeEffect($"Rati has: {ratiHP} HP left. Cry...\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                        Thread.Sleep(2000);
                    }
                }
                else if (input == "Tax Forms" || input == "tax forms")
                {
                    TypeEffect("Rolling Dice...\n", 60);
                    Thread.Sleep(400);
                    TypeEffect($"Dice came out as... {damageToRat} damage!\n", 60);

                    if (chance <= 10)
                    {
                        TypeEffect("BUT WAIT... You have missed...\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                    }
                    else
                    {
                        ratiHP -= damageToRat;
                        TypeEffect($"{damageToRat} Tax Forms given to rati...\n", 60);
                        TypeEffect($"Rati has: {ratiHP} HP left. I HATE TAXES!!!\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                        Thread.Sleep(2000);
                    }
                }
                else if (input == "Child Support" || input == "child support")
                {
                    TypeEffect("Rolling Dice...\n", 60);
                    Thread.Sleep(400);
                    TypeEffect($"Dice came out as... {damageToRat} damage!\n", 60);

                    if (chance <= 10)
                    {
                        TypeEffect("BUT WAIT... Rati doesn't have a child currently...\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                    }
                    else
                    {
                        ratiHP -= damageToRat;
                        TypeEffect($"{damageToRat} Child Support money taken from rati...\n", 60);
                        TypeEffect($"Rati has: {ratiHP} HP left. I HATE PAYING CHILD SUPPORT!!!\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                        Thread.Sleep(2000);
                    }
                }

                else if (input == "Attack Options" || input == "attack options")
                {
                    TypeEffect("Rolling Special Dice...\n", 60);
                    Thread.Sleep(400);

                    TypeEffect($"Special Dice came out as... {damageToRat * 2} damage!\n", 60);

                    if (chance <= 10)
                    {
                        TypeEffect("BUT WAIT... Rati is sigma and you missed...\n", 60);

                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                    }
                    else
                    {
                        ratiHP -= damageToRat * 2;

                        TypeEffect($"{damageToRat * 2} damage done to rati...\n", 60);

                        TypeEffect($"Rati has: {ratiHP} HP left.\n", 60);

                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                        Thread.Sleep(2000);
                    }

                }

                else if (input == "Heal" || input == "heal")
                {
                    if (playerPotions > 0)
                    {
                        playerHP += 20;
                        playerPotions--;
                        TypeEffect($"You used a healing potion! +20 HP.\n", 60);
                        TypeEffect($"You have {playerPotions} healing potions left.\n", 60);
                        TypeEffect("RATI'S TURN!!!\n\n", 30);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        TypeEffect("No potions left! Try a different option...\n", 60);
                        continue;
                    }
                }
                else
                {
                    TypeEffect("Invalid option! Try again.\n", 60);
                    continue;
                }

                // Rati's turn
                if (ratiHP > 0)
                {
                    Console.WriteLine("RATI'S TURN!!!\n");
                    Console.WriteLine($"RATI Health: {ratiHP}");
                    Console.WriteLine($"Player Health: {playerHP}\n");

                    int ratiDamage = new Random().Next(1, 12);
                    playerHP -= ratiDamage;
                    TypeEffect($"Rati dealt {ratiDamage} damage to you.\n", 60);
                    TypeEffect($"You have: {playerHP} HP left.\n", 60);
                    TypeEffect("PLAYER'S TURN!!!\n\n", 30);
                    Thread.Sleep(2000);
                }
            }

            if (ratiHP <= 0)
            {
                TypeEffect("Rati has been defeated! You win!\n", 60);
                TypeEffect("You won 5,000 money\n", 60);
                money += 5000;
                beatRati = true;
                AchievementReachedCheck(money, points);
                Thread.Sleep(1000);
            }
            else if (playerHP <= 0)
            {
                TypeEffect("You have been defeated by Rati... Game Over!\n", 60);
                Thread.Sleep(1000);
            }
        }

        static void Game()
        {
            HandleSupport();
            Console.WriteLine("You are using C# Edition");
            AchievementReachedCheck(money, points);
            DisplayCommands();

            while (true)
            {
                if (!inPrison)
                {
                    if (csAmount == 15)
                    {
                        Prison();
                    }

                    // Commands
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "/help":
                            DisplayCommands();
                            break;
                        case "/achievements":
                            DisplayAchievements();
                            break;
                        case "/support":
                            HandleSupport();
                            break;
                        case "/transaction":
                            HandleTransaction(ref money, ref points);
                            break;
                        case "/playagame":
                            HandlePlayAGame(ref money, ref points);
                            break;
                        case "/gamble":
                            HandleGamble(ref money);
                            break;
                        case "/taxes":
                            HandleTaxes(ref money, ref taxAmount);
                            break;
                        case "/childsupport":
                            ChildSupport(ref money, ref csAmount);
                            break;
                        case "/exit":
                            HandleExit();
                            Console.Write("Confirm (y/n)? ");
                            string response = Console.ReadLine();
                            if (response.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case "/points":
                            HandlePoints(points);
                            break;
                        case "/money":
                            HandleMoney(money);
                            break;
                        case "/reaper":
                            if (!secretOneFound)
                            {
                                Console.WriteLine("Guh, I guess you have found me\nI will give you 1000 money, I paid the taxes for you btw and np.");
                                money += 1000;
                                secretOneFound = true;
                                AchievementReachedCheck(money, points);
                            }
                            else
                            {
                                Console.WriteLine("Bro STOP BEGGING ME FOR MONEY PLEASE BRUH...");
                                begging = true;
                                AchievementReachedCheck(money, points);
                            }
                            break;
                        case "/kys":
                            if (!secretTwoFound)
                            {
                                Console.WriteLine("Did you just tell me to keep myself safe??? I am stealing your money");
                                double moneyStolen = Math.Ceiling(money / 3.0);
                                money -= (int)moneyStolen;
                                Console.WriteLine($"Reaper just stole {moneyStolen} money from you");
                                secretTwoFound = true;
                                AchievementReachedCheck(money, points);
                            }
                            else
                            {
                                Console.WriteLine("Odd specimen");
                            }
                            break;
                        case "/therat":
                            string input;
                            TypeEffect("MRATI: LET ME TELL YOU A STORY...\n", 70);
                            Console.Write("(y/n)? ");
                            input = Console.ReadLine();
                            if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                TypeEffect("MRATI: Why thank you actually! :D\n", 70);
                                goto Story;
                            }
                            else if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                TypeEffect("MRATI: (Ignoring your input)\n", 70);
                                goto Story;
                            }
                            else
                            {
                                TypeEffect("MRATI: Learn how to respond you!!!", 70);
                                goto Story;
                            }

                        Story:
                            TypeEffect("MRATI: Anyways... I was a crocodile once bit by an evil rat!\n", 70);
                            TypeEffect("MRATI: This is why I love joe biden he is so awesome! :3\n", 70);
                            TypeEffect("MRATI: This is why I am a rat...\n", 70);
                            TypeEffect("MRATI: Cool story?\n", 70);
                            Console.Write("(y/n)? ");
                            string input2 = Console.ReadLine();
                            if (input2.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                TypeEffect("MRATI: Thank you I am proud to be your guest :D\n", 70);
                            }
                            else if (input2.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                TypeEffect("MRATI: KYS\n", 70);
                                TypeEffect("......... Boss encounter!!!\n", 70);
                                Thread.Sleep(250);
                                Mrati();
                            }
                            else
                            {
                                TypeEffect("MRATI: Learn how to respond you!!!", 70);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid command. Type /help for available commands.");
                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Game();
        }
    }
}
