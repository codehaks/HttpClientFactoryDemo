Console.WriteLine("Hello, World!");

for (int i = 0; i < 10; i++)
{
    var client = new HttpClient();
    await client.GetAsync("https://codehaks.com");
    await Task.Delay(1000);
    Console.WriteLine($"{i} - Connection established");
}