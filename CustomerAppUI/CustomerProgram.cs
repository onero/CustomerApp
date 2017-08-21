using System;
using System.Linq;
using CustomerAppBLL;
using CustomerAppBLL.Services;
using CustomerAppEntity;

namespace CustomerAppUI
{
    static class CustomerProgram
    {
        private static readonly BllFacade BllFacade = new BllFacade();

        static void Main(string[] args)
        {
            var customer1 = new Customer()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            BllFacade.CustomerService.CreateCustomer(customer1);

            var customer2 = new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            BllFacade.CustomerService.CreateCustomer(customer2);

            string[] menuItems =
            {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        ListCustomers();
                        DeleteCustomer();
                        break;
                    case 4:
                        ListCustomers();
                        EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if (customer != null)
            {
                Console.WriteLine("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();

                BllFacade.CustomerService.UpdateCustomer(customer);
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>kdjfjkdf</returns>
        private static Customer FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return BllFacade.CustomerService.GetCustomerById(id);
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                BllFacade.CustomerService.DeleteCustomer(customerFound.Id);
            }
            else
            {
                Console.WriteLine("Customer not Found");
            }
        }

        private static void AddCustomers()
        {
            Console.WriteLine("Firstname: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Lastname: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            BllFacade.CustomerService.CreateCustomer(new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in BllFacade.CustomerService.GetAllCustomers())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.GetFullName()} Adress: {customer.Address}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}