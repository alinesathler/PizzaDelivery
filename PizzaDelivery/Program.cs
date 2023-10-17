using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery {
    class Program {
        //Method to read a integer between two predefined values, if isShowValue is true enable the show the range to the user
        static int ReadInt(string prompt, int minimun, int maximun, bool isShowValue = true) {
            string valueString;
            int valueInt;
            bool isValueOk = false;

            do {
                if (isShowValue) {
                    Console.Write($"{prompt} (between {minimun} and {maximun}): ");
                } else {
                    Console.Write(prompt);
                }
                valueString = Console.ReadLine();

                //Check if the input is a integer between minimun and maximun
                if (int.TryParse(valueString, out valueInt) && (minimun <= valueInt) && (maximun >= valueInt)) {
                    isValueOk = true;
                } else {
                    Console.Write("Invalid input. Try again.\n");
                }
            } while (isValueOk != true);

            return valueInt;
        }

        //Method to calculate the price of each order
        static double OrderPrice (int pizzaSize, int numberToppings, int coke) {
            double orderPrice = 0;

            if (pizzaSize == 1) {
                orderPrice += 15.00;
            } else if (pizzaSize == 2) {
                orderPrice += 10.00;
            } else if (pizzaSize == 3) {
                orderPrice += 5.00;
            }

            orderPrice += 0.5 * numberToppings;

            if (coke == 1) {
                orderPrice += 2.00;
            }

            return orderPrice;
        }

        //Method to free delivery
        static void TotalPrice(double totalOrders) {
            double totalPrice = totalOrders;
            Console.WriteLine($"Total price including delivery fee is {totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-CA"))}.");
        }

        //Method to paid delivery
        static void TotalPrice(double totalOrders, double deliveryFee) {
            double totalPrice = totalOrders + deliveryFee;
            Console.WriteLine($"Total price including delivery fee is {totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("en-CA"))}.");
        }

        static void Main(string[] args) {
            int order, pizzaSize, numberToppings, coke;
            double orderPrice, totalOrders = 0, deliveryFee = 0;
            string deliveryOption;

            Console.WriteLine("--Welcome to Pizza Delivery--");

            do {
                pizzaSize = ReadInt("Please enter the size of the pizza:\n1 - Pizza Large\n2 - Pizza Medium\n3 - Pizza Small\nEnter your choice: ", 1, 3, false);
                numberToppings = ReadInt("Please enter the number of toppings: ", 0, 999999999, false);
                coke = ReadInt("Do you want a coke (1: Yes, 0: No)? ", 0, 1, false);

                //Price for each order
                orderPrice = OrderPrice(pizzaSize, numberToppings, coke);

                //Total price of all orders
                totalOrders += orderPrice;

                order = ReadInt("Would you like to enter another order (1: Yes, 0: No)? ", 0, 1, false);

            } while (order == 1);

            //Showing the total value
            switch (totalOrders) {
                case double n when (n > 25):
                    Console.WriteLine("Congratulations you qualify for free delivery.");
                    TotalPrice(totalOrders);
                    break;
                case double n when (n > 0 && n <= 25):
                    Console.WriteLine("A delivery fee of $10 required.");
                    deliveryFee = 10;
                    TotalPrice(totalOrders, deliveryFee);
                    break;
                default:
                    Console.WriteLine("Error with order, please try again.");
                    break;
            }            
        }
    }
}
