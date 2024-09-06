// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

for (int i = 0; i < 10; i++)
{
    var client=new HttpClient();
    await client.GetAsync("https://codehaks.com");

    Console.WriteLine($"{i} - Connection established");
}