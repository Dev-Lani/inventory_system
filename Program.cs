using System;
using System.Collections.Generic;

class Product
{
    public string Name;
    public int Quantity;
    public double Price;

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Quantity: {Quantity}, Price: {Price:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> inventory = new List<Product>();

        while (true)
        {
            Console.WriteLine("\nSimple Inventory System:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Remove Product");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option[number]: ");
            string choice = Console.ReadLine();

            if (choice == "1") // Add Product
            {
                Product product = new Product();

                Console.Write("Enter product name: ");
                product.Name = Console.ReadLine();

                Console.Write("Enter product quantity: ");
                product.Quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter product price: ");
                product.Price = double.Parse(Console.ReadLine());

                inventory.Add(product);
                Console.WriteLine("Product added successfully!");
            }
            else if (choice == "2") // View Inventory
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("Inventory is empty.");
                }
                else
                {
                    Console.WriteLine("\nInventory:");
                    foreach (var product in inventory)
                    {
                        product.Display();
                    }
                }
            }
            else if (choice == "3") // Remove Product
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("No products to remove.");
                }
                else
                {
                    Console.WriteLine("\nInventory:");
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {inventory[i].Name}");
                    }

                    Console.Write("Enter the number of the product to remove: ");
                    int index = int.Parse(Console.ReadLine()) - 1;

                    if (index >= 0 && index < inventory.Count)
                    {
                        inventory.RemoveAt(index);
                        Console.WriteLine("Product removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");    
                    }
                }
            }
            else if (choice == "4") // Update Product
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("No products to update.");
                }
                else
                {
                    Console.WriteLine("\nInventory:");
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {inventory[i].Name}");
                    }

                    Console.Write("Enter the number of the product to update: ");
                    int index = int.Parse(Console.ReadLine()) - 1;

                    if (index >= 0 && index < inventory.Count)
                    {
                        Product productToUpdate = inventory[index];

                        Console.WriteLine("Leave fields blank to keep the current value.");

                        Console.Write($"Enter new name (current: {productToUpdate.Name}): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName))
                        {
                            productToUpdate.Name = newName;
                        }

                        Console.Write($"Enter new quantity (current: {productToUpdate.Quantity}): ");
                        string newQuantity = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newQuantity) && int.TryParse(newQuantity, out int parsedQuantity))
                        {
                            productToUpdate.Quantity = parsedQuantity;
                        }

                        Console.Write($"Enter new price (current: {productToUpdate.Price:C}): ");
                        string newPrice = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newPrice) && double.TryParse(newPrice, out double parsedPrice))
                        {
                            productToUpdate.Price = parsedPrice;
                        }

                        Console.WriteLine("Product updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
            }
            else if (choice == "5") // Exit
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}