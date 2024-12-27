
using Quiz2.Entity;
using Quiz2.Servise;

CardServise cardServise = new CardServise();
TransactionServise transaction = new TransactionServise();
UserServise userServise = new UserServise();
bool isRun = true;
bool isRun2 = true;
bool isRun3 = true;
bool isRunUser = true;
var onUser = Online.user;
string userCard = "";
string passwordCard = "";
do
{
    Console.WriteLine(" 1 - Register ");
    Console.WriteLine(" 2 - Login ");
    Console.WriteLine(" 3 - Logout ");
    Console.WriteLine(" 4 - Exit ");
    var log = Console.ReadLine();
    switch (log)
    {
        case "1":
            {
                Console.Clear();
                Console.WriteLine("enter your name: ");
                var name = Console.ReadLine();
                Console.WriteLine("enter your famely: ");
                var famely = Console.ReadLine();
                Console.WriteLine("enter your username: ");
                var username = Console.ReadLine();
                Console.WriteLine("enter your password: ");
                var password = Console.ReadLine();
                User user = new User()
                {
                    FirstName = name,
                    LastName = famely,
                    Username = username,
                    Password = password
                };
                userServise.Register(user);
                Console.WriteLine("Register is complete");
                Console.ReadKey();
                break;
            }
        case "2":
            {
                Console.Clear();
                Console.WriteLine("enter your username: ");
                var username = Console.ReadLine();
                Console.WriteLine("enter your password: ");
                var password = Console.ReadLine();
                if (userServise.Login(username, password) != null)
                {
                    onUser = userServise.Login(username, password);

                    do
                    {
                        do
                        {
                            Console.WriteLine("1-add card");
                            Console.WriteLine("2-login card");
                            Console.WriteLine("3-Exit");
                            var inp = Console.ReadLine();
                            switch (inp)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.Write("enter card number: ");
                                    var cardNo = Console.ReadLine();
                                    Console.Write("enter your balans: ");
                                    var cardBalans = float.Parse(Console.ReadLine());
                                    Console.Write("enter card password: ");
                                    var cardPassword = Console.ReadLine();

                                    Card card1 = new Card()
                                    {
                                        CardNumber = cardNo,
                                        Balance = cardBalans,
                                        Password = cardPassword,
                                        UserId = onUser.Id,
                                        User = onUser
                                    };
                                    cardServise.Add(card1);
                                    Console.WriteLine("complete");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    {
                                        Console.Clear();
                                        Console.Write("enter your card code: ");
                                        userCard = Console.ReadLine();
                                        Console.Write("enter your card password: ");
                                        passwordCard = Console.ReadLine();
                                        var card = cardServise.Login(onUser.Username, userCard, passwordCard);
                                        if (card != null)
                                        {
                                            do
                                            {
                                                var onCard = Online.card;
                                                onCard = card;
                                                Console.Clear();
                                                Console.WriteLine(" 1- Card to Card");
                                                Console.WriteLine(" 2- history");
                                                Console.WriteLine(" 3- Show Balans");
                                                Console.WriteLine(" 4- Cheng Password");
                                                Console.WriteLine(" 5- Exit");
                                                Console.Write("enter option : ");
                                                var op = Console.ReadLine();
                                                isRun2 = true;
                                                switch (op)
                                                {
                                                    case "1":
                                                        Console.Clear();
                                                        Console.Write("enter destination Card: ");
                                                        var destinationCard = Console.ReadLine();
                                                        Console.Write("enter Amount: ");
                                                        var Amount = float.Parse(Console.ReadLine());
                                                        var send = cardServise.Get(destinationCard);
                                                        Console.WriteLine("The name of the destination account holder: "
                                                                      + send.User.FirstName + " " + send.User.LastName);
                                                        cardServise.SendCode(onCard.CardNumber);
                                                        Console.Write("enter Verification code: ");
                                                        var check = Console.ReadLine();
                                                        if (cardServise.CheckCode(check, onCard.CardNumber) == true)
                                                        {
                                                            var Transfer = transaction.Transfer(onCard.CardNumber, destinationCard, Amount);
                                                            if (Transfer == true)
                                                            {
                                                                Console.WriteLine("The operation was done");
                                                                Console.ReadKey();
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("The operation was not performed");
                                                                Console.ReadKey();
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("error");
                                                            break;
                                                        }
                                                    case "2":
                                                        Console.Clear();
                                                        foreach (var item in transaction.GetTransactions(onCard.CardNumber))
                                                        {
                                                            Console.WriteLine(item);
                                                        }
                                                        Console.ReadKey();
                                                        break;
                                                    case "3":
                                                        Console.Clear();
                                                        var showBslsns = cardServise.ShowCardBalans(onCard.CardNumber);
                                                        Console.WriteLine($"Balans: {showBslsns}");
                                                        Console.ReadKey();
                                                        break;
                                                    case "4":
                                                        Console.Clear();
                                                        Console.Write("enter your old password: ");
                                                        var pass = Console.ReadLine();
                                                        Console.Write("enter new password: ");
                                                        var newPass = Console.ReadLine();
                                                        if (cardServise.ChengPassword(onUser.Username, pass, newPass) == true)
                                                        {
                                                            Console.WriteLine("cheng password is complite");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("username or password is not true");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                    case "5":
                                                        Console.Clear();
                                                        onCard = null;
                                                        isRun2 = false;
                                                        Console.WriteLine();
                                                        isRun2 = false;
                                                        break;
                                                }
                                            } while (isRun2 == true);
                                        }
                                        else
                                        {
                                            Console.WriteLine("username or password not true");
                                        }
                                        break;
                                    }
                                case "3":
                                    isRun3 = false;
                                    onUser = null;
                                    isRun = false;
                                    break;
                            }
                        } while (isRun3);

                    } while (isRun);

                }
                else
                {
                    Console.WriteLine("username or password is not true");
                }
                Console.ReadKey();
            }
            break;
        case "3":
            Console.Clear();
            onUser = null;
            break;
        case "4":
            Console.Clear();
            onUser = null;
            isRunUser = false;
            Console.ReadKey();
            break;
    }
} while (isRunUser == true);

