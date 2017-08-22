﻿using System;
using System.Linq;
using CustomerAppBLL;
using CustomerAppBLL.Services;
using CustomerAppEntity;

namespace CustomerAppUI
{
    static class CustomerProgram
    {
        private static readonly BLLFacade BLLFacade = BLLFacade.Instance;
        private static bool _userIsDone;

        static void Main(string[] args)
        {
            var customer1 = new Customer()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 202"
            };
            BLLFacade.CustomerService.CreateCustomer(customer1);

            var customer2 = new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Address = "Ostestrasse 202"
            };
            BLLFacade.CustomerService.CreateCustomer(customer2);

            string[] menuItems =
            {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };

            Console.WriteLine();

            while (!_userIsDone)
            {
                ShowMenu(menuItems);

                var userSelection = GetInputFromUser();

                ReactToUserInput(userSelection);
            }

            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        /// <summary>
        /// React to the user input
        /// </summary>
        /// <param name="selection"></param>
        private static void ReactToUserInput(int selection)
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
                case 5:
                    _userIsDone = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Propmt user for id to edit a customer
        /// </summary>
        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if (customer != null)
            {
                Console.Write("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.Write("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();

                BLLFacade.CustomerService.UpdateCustomer(customer);
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
        }

        /// <summary>
        /// Prompt user for id to find customer
        /// </summary>
        /// <returns>Customer with parsed id</returns>
        private static Customer FindCustomerById()
        {
            Console.Write("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return BLLFacade.CustomerService.GetCustomerById(id);
        }

        /// <summary>
        /// Prompt user for id for customer to delete
        /// </summary>
        private static void DeleteCustomer()
        {
            Console.WriteLine("Please write id of customer to delete");
            var customerFound = FindCustomerById();
            if (customerFound != null)
            {
                BLLFacade.CustomerService.DeleteCustomer(customerFound.Id);
            }

            var response = customerFound == null ? "Customer not found" : "Customer was deleted";
            Console.WriteLine(response);
        }

        /// <summary>
        /// Prompt user for information to add new customer
        /// </summary>
        private static void AddCustomers()
        {
            Console.Write("Firstname: ");
            var firstName = Console.ReadLine();

            Console.Write("Lastname: ");
            var lastName = Console.ReadLine();

            Console.Write("Address: ");
            var address = Console.ReadLine();

            var createdCustomer = BLLFacade.CustomerService.CreateCustomer(new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            });
            Console.WriteLine("\nCustomer created:");
            DisplayCustomer(createdCustomer);
        }

        /// <summary>
        /// List all customers
        /// </summary>
        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");
            foreach (var customer in BLLFacade.CustomerService.GetAllCustomers())
            {
                DisplayCustomer(customer);
            }
        }

        private static void DisplayCustomer(Customer customerToDispaly)
        {
            Console.WriteLine($"Id: {customerToDispaly.Id} Name: {customerToDispaly.GetFullName()} Adress: {customerToDispaly.Address}");
        }


        private static void ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }
        }

        /// <summary>
        /// Get input from user
        /// </summary>
        /// <returns></returns>
        private static int GetInputFromUser()
        {
            Console.Write("Your input: ");
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