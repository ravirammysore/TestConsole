using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7089/pizzas");

        // Fetch the list of pizzas
        List<Pizza> pizzas = client.GetFromJsonAsync<List<Pizza>>("api/pizzas").Result;
        
        Console.WriteLine("Pizzas available:");
        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"Id: {pizza.Id}, Name: {pizza.Name}, Price: {pizza.Price}");
        }

       /*  // Add a new pizza
        var newPizza = new Pizza { Name = "Veggie Deluxe", Price = 13.99M };
        var response = client.PostAsJsonAsync("api/pizzas", newPizza).Result;

        if (response.IsSuccessStatusCode)
        {
            var createdPizza = response.Content.ReadFromJsonAsync<Pizza>().Result;
            Console.WriteLine("New pizza added:");
            Console.WriteLine($"Id: {createdPizza.Id}, Name: {createdPizza.Name}, Price: {createdPizza.Price}");
        }
        else
        {
            Console.WriteLine("Error adding new pizza");
        }

        // Fetch the updated list of pizzas
        pizzas = client.GetFromJsonAsync<List<Pizza>>("api/pizzas").Result;
        Console.WriteLine("Updated list of pizzas:");
        foreach (var pizza in pizzas)
        {
            Console.WriteLine($"Id: {pizza.Id}, Name: {pizza.Name}, Price: {pizza.Price}");
        }       */
    }
}
