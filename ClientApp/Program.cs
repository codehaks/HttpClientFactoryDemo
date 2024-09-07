// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//for (int i = 0; i < 100; i++)
//{
//    using var client = new HttpClient(); // Creates new HttpClient each time
//    await client.GetAsync("https://codehaks.com");
//    await Task.Delay(1000);
//    Console.WriteLine($"{i} - Connection established");
//}

for (int i = 0; i < 100; i++)
{
    var client = new HttpClient(); // Creates new HttpClient each time
    await client.GetAsync("https://codehaks.com");
    await Task.Delay(1000);
    Console.WriteLine($"{i} - Connection established");
}

