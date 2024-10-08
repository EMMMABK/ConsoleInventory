
using System;
using System.Data;

namespace InventoryManager
{
    class Program
    {
        static DataTable inventory = new DataTable();

        static void Main(string[] args)
        {
            InitializeInventory();
            string command;

            do
            {
                Console.Clear();
                Console.WriteLine("Inventory");
                Console.WriteLine("1. Put item");
                Console.WriteLine("2. Show all items");
                Console.WriteLine("3. Take item");
                Console.WriteLine("4. Exit");
                Console.Write("Choose the number: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        DisplayInventory();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                }
            } while (command != "4");
        }

        static void InitializeInventory()
        {
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Quantity", typeof(int));
        }

        static void AddNewItem()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            string quantityInput = Console.ReadLine();

    
            if (int.TryParse(quantityInput, out int quantity))
            {
                inventory.Rows.Add(name, quantity);
                Console.WriteLine("Item added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid number.");
            }

            Console.ReadKey();
        }

        static void DisplayInventory()
        {
            Console.WriteLine("\nList of items:");
            foreach (DataRow row in inventory.Rows)
            {
                Console.WriteLine($"Name: {row["Name"]}, Quantity: {row["Quantity"]}");
            }
            Console.WriteLine("Press ENTER...");
            Console.ReadKey();
        }

        static void DeleteItem()
        {
            Console.Write("Enter the name of the item to take: ");
            string nameToDelete = Console.ReadLine();
            DataRow rowToDelete = null;

            foreach (DataRow row in inventory.Rows)
            {
                if (row["Name"].ToString().Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
                {
                    rowToDelete = row;
                    break;
                }
            }

            if (rowToDelete != null)
            {
                inventory.Rows.Remove(rowToDelete);
                Console.WriteLine("You successfully take an item! Press ENTER...");
            }
            else
            {
                Console.WriteLine("Item not found! Press ENTER...");
            }
            Console.ReadKey();
        }
    }
}
