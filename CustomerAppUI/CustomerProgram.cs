using System;
using System.Linq;
using CustomerAppBLL;
using CustomerAppBLL.Services;
using CustomerAppEntity;
using CustomerAppUI.Model;

namespace CustomerAppUI
{
    internal static class CustomerProgram
    {
        private static bool _userDone;
        private static readonly MenuModel MenuModel = new MenuModel();
        private static readonly CustomerModel CustomerModel = new CustomerModel();

        private static void Main(string[] args)
        {
            Console.WriteLine();
            while (!_userDone)
            {
                MenuService.DisplayMenu(MenuModel.MenuItems);

                var userSelection = MenuService.GetUserMenuSelection(MenuModel.MenuItems.Length);

                ReactToUserInput(userSelection);
            }
        }

        /// <summary>
        /// Carry out action related to user selection
        /// </summary>
        /// <param name="userSelection"></param>
        private static void ReactToUserInput(int userSelection)
        {
            switch (userSelection)
            {
                case 1:
                    Console.WriteLine("Exiting program, goodbye!");
                    _userDone = true;
                    break;
                case 2:
                    ListAllCustomers();
                    break;
                case 3:
                    DisplayAddCustomer();
                    break;
                case 4:
                    DisplayDeleteCustomer();
                    break;
                case 5:
                    DisplayEditCustomer();
                    break;
                case 6:
                    SearchForCustomer();
                    break;
                default:
                    throw new ArgumentException("Not a valid command!");
            }

            Console.WriteLine();
        }

        private static void SearchForCustomer()
        {
            Console.WriteLine($"Please enter a name to search for");
            var searchString = MenuService.GetValidString();
            var customerFromSearch = CustomerModel.SearchForCustomerName(searchString);
            DisplayCustomerInfo(customerFromSearch);
        }

        private static void DisplayCustomerInfo(Customer customerFromSearch)
        {
            Console.WriteLine($"Id: {customerFromSearch.Id} Name: {customerFromSearch.GetFullName()} Address: {customerFromSearch.Address}");
        }

        /// <summary>
        /// Give user option to edit a customer
        /// </summary>
        private static void DisplayEditCustomer()
        {
            ListAllCustomers();

            Console.WriteLine();

            if (CustomerModel.GetAllCustomers().Any())
            {
                var customerToEdit = PromptForCustomerId();

                Console.WriteLine("Please select one of following options:");
                Console.WriteLine("1: Change full name");
                Console.WriteLine("2: Change address");

                var selection = MenuService.GetUserMenuSelection(2);

                if (selection == 1)
                {
                    Console.Write("Please write first name: ");
                    customerToEdit.FirstName = MenuService.GetValidString();
                    Console.Write("Please write last name: ");
                    customerToEdit.LastName = MenuService.GetValidString();
                }
                else if (selection == 2)
                {
                    Console.Write("Please write address: ");
                    customerToEdit.Address = Console.ReadLine();
                }

                CustomerModel.UpdateCustomer(customerToEdit);

                Console.WriteLine("New customer info:");

                DisplayCustomerInfo(customerToEdit);
            }
        }

        /// <summary>
        /// Prompt the user for a customer id and validate existance
        /// </summary>
        /// <returns>Customer from parsed id</returns>
        private static Customer PromptForCustomerId()
        {
            Customer customerToEdit;
            bool validCustomerId = false;
            do
            {
                Console.WriteLine("Please write id of customer:");

                var customerIdInput = MenuService.GetValidInteger();

                customerToEdit = CustomerModel.GetCustomerById(customerIdInput);

                if (customerToEdit != null)
                {
                    validCustomerId = true;
                }
                else
                {
                    Console.WriteLine($"Sorry Id: {customerIdInput} is not a valid id");
                }
            } while (!validCustomerId);
            return customerToEdit;
        }

        /// <summary>
        /// Give user option to delete a customer
        /// </summary>
        private static void DisplayDeleteCustomer()
        {
            ListAllCustomers();

            Console.WriteLine();

            if (!CustomerModel.GetAllCustomers().Any()) return;

            var customerIdToDelete = PromptForCustomerId().Id;

            CustomerModel.DeleteCustomer(customerIdToDelete);
            Console.WriteLine("Customer deleted!");
        }

        /// <summary>
        /// Give user option to add a customer
        /// </summary>
        private static void DisplayAddCustomer()
        {
            Console.Write("Please Enter First Name: ");
            var firstName = MenuService.GetValidString();

            Console.Write("Please Enter Last Name: ");
            var lastName = MenuService.GetValidString();

            Console.Write("Please Enter Address: ");
            var address = MenuService.GetValidString();

            var newCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };

            var createdCustomer = CustomerModel.CreateCustomer(newCustomer);
            Console.WriteLine("Customer created!");
            DisplayCustomerInfo(createdCustomer);
        }

        /// <summary>
        /// List all customers in model
        /// </summary>
        private static void ListAllCustomers()
        {
            var customers = CustomerModel.GetAllCustomers();

            Console.WriteLine("Listing all customers:\n");

            if (customers.Any())
            {
                foreach (var customer in customers)
                {
                    DisplayCustomerInfo(customer);
                }
            }
            else
            {
                Console.WriteLine("Ain't got no customers...");
            }
        }
    }
}