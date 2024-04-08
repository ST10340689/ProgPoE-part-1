using System;
using System.Collections.Generic;

class Recipe
{
    public int NumberOfIngredients { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public int NumberOfSteps { get; set; }
    public List<string> Steps { get; set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }
}

class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}

class Program
{
    static Recipe recipe = new Recipe();
    static Dictionary<string, double> originalQuantities = new Dictionary<string, double>(); //Stores the original quantities 
    static void AddRecipe() //Add recipe function
    {
        Console.WriteLine("Enter details for the recipe:");

        // Input for number of ingredients
        Console.Write("Enter the number of ingredients: ");
        recipe.NumberOfIngredients = Convert.ToInt32(Console.ReadLine());

        // Input for each ingredient
        for (int i = 0; i < recipe.NumberOfIngredients; i++)
        {
            Ingredient ingredient = new Ingredient();

            Console.WriteLine($"\nEnter details for ingredient #{i + 1}:");

            Console.Write("Name: ");
            ingredient.Name = Console.ReadLine();

            Console.Write("Quantity: ");
            ingredient.Quantity = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unit of measurement (tablespoon, teaspoon, cup): ");
            ingredient.Unit = Console.ReadLine();

            recipe.Ingredients.Add(ingredient);

            // Store original quantity
            originalQuantities[ingredient.Name] = ingredient.Quantity;
        }

        // Asks for number of steps and will repeat this line the amount entered
        Console.Write("\nEnter the number of steps: ");
        recipe.NumberOfSteps = Convert.ToInt32(Console.ReadLine());


        for (int i = 0; i < recipe.NumberOfSteps; i++)
        {
            Console.Write($"\nEnter description for step #{i + 1}: ");
            recipe.Steps.Add(Console.ReadLine());
        }

        Console.WriteLine("Recipe added successfully!");
    }

    static void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe Details:");

        Console.WriteLine("\nIngredients:");
        foreach (var ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.NumberOfSteps; i++)
        {
            Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
        }
    }

    static void ScaleRecipe()
    {
        {
            Console.WriteLine("Enter the scaling factor (0.5, 2, or 3): ");
            double scale = Convert.ToDouble(Console.ReadLine());

            if (scale == 0.5 || scale == 2 || scale == 3)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= scale;
                }

                Console.WriteLine($"Recipe scaled by a factor of {scale} successfully!");
            }
            else
            {
                Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
            }
        }
    }

    static void ResetRecipe()
    {
        foreach (var ingredient in recipe.Ingredients)
        {
            // Reset each ingredient's quantity to its original value
            ingredient.Quantity = originalQuantities[ingredient.Name];
        }

        Console.WriteLine("Recipe quantities reset to original values successfully!");
    }

    static void ClearRecipe()
    {
        recipe = new Recipe();
        Console.WriteLine("Recipe data cleared successfully!");
    }

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a recipe");
            Console.WriteLine("2. Display the full recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Clear the data");
            Console.WriteLine("5. Reset the quantities of recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            // Parse user input
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayRecipe();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ClearRecipe();
                        break;
                    case 5:
                        ResetRecipe();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 6);
    }
}
