using System.Data.SqlClient;

namespace MagicStore {
    public class Program {

        public static void Main() {
            Console.WriteLine("Welcome to the Magic Store!");
            Console.WriteLine("Please Enter Your First Name");
            string firstName;
            string lastName;
            string password;
            decimal initialFunds;
            Customer person;
            try {
                firstName = Console.ReadLine().ToLower();
            } catch (NullReferenceException nre) {
                Console.WriteLine("You didn't enter proper input.");
                return;
            }
            Console.WriteLine("Please Enter Your Last Name");
            try {
                lastName = Console.ReadLine().ToLower();
            } catch (NullReferenceException nre) {
                Console.WriteLine("You didn't enter proper input.");
                return;
            }

            if (firstName == "megan" && lastName == "postlewait") {
                Owner owner = SqlLoader.LoadOwner(firstName, lastName);
                Console.WriteLine("Enter Your Password:");
                string passWord = Console.ReadLine();
                if (passWord != owner.Password) {
                    Console.WriteLine("Incorrect Password");
                    return;
                }
                owner.SetStores(SqlLoader.LoadOwnerStores(firstName.ToLower() + lastName.ToLower()));
                for (int i = 0; i < owner.Stores.Count; i++) {
                    owner.Stores[i].LoadOrderHistory();
                }
                return;
            }

            person = SqlLoader.LoadCustomer(firstName, lastName);
            
            if (person != null) {
                bool isValid = false;
                while (!isValid) {
                    Console.WriteLine("Please Enter Password");

                    try {
                        password = Console.ReadLine();
                    } catch (NullReferenceException nre) {
                        Console.WriteLine("You didn't enter proper input.");
                        return;
                    }

                    isValid = person.ValidatePassword(password);
                    if (!isValid) {
                        Console.WriteLine("Incorrect Password; Try Again.");
                    }
                }
                Console.WriteLine();
            } else {
                Console.WriteLine("Welcome New Shopper");
                Console.WriteLine("Let's Set up Your Account");
                Console.WriteLine("Please Enter The Password You'd Like for your account");
                
                try {
                    password = Console.ReadLine();
                } catch (NullReferenceException nre) {
                    Console.WriteLine("You didn't enter proper input.");
                    return;
                }
                
                Console.WriteLine("How much money do you have?");

                try {
                    bool num = Decimal.TryParse(Console.ReadLine(), out initialFunds);
                } catch (NullReferenceException nre) {
                    Console.WriteLine("You didn't enter proper input.");
                    return;
                }

                int storeID = SqlLoader.GetStoreID();

                SqlLoader.SaveNewPerson(firstName, lastName, password, initialFunds, storeID);
                person = SqlLoader.LoadCustomer(firstName, lastName);
                Console.WriteLine();
            }

            bool areShopping = true;

            while (areShopping) {
                
                Console.WriteLine("Here are the items availible at your store location...");
                Console.WriteLine("Enter the number of the item you want then enter the quantity.");
                person.Store.PrintInventory();
                Console.WriteLine("Enter 'check out' to Check Out");
                Console.WriteLine("Enter 'order history' to see your comprhensive order history");
                Console.WriteLine("Enter the Item Number you wish to add to you cart.");
                try {
                    string option = Console.ReadLine().ToLower();
                    if (option == "check out") {
                        bool success = person.MakePurchase();
                        if (success) {
                            Console.WriteLine("Purchase Successful, Come Again Soon. GoodBye.");
                            break;
                        } else {
                            Console.WriteLine("Purchase Unsuccessful, Come Again Soon. Goodbye.");
                            break;
                        }

                    } else if (option == "order history") {
                        Console.WriteLine();
                        person.LoadOrderHistory();
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Enter the number that you want of that product.");
                        int option2 = Convert.ToInt32(Console.ReadLine());
                        int items = person.AddToCart(person.Store.Inventory[Convert.ToInt32(option)], option2);
                        Console.WriteLine();
                        if (items > 0) {
                            person.PrintCart();
                        }
                        Console.WriteLine();
                    }
                } catch (NullReferenceException nre) {
                    Console.WriteLine("You entered faulty input.");
                    return;
                }


            }

            

            




        }
    }
}

    


