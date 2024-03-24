namespace ContainerApp;

public class Product
{
    public string Name { get; set; }
    public double Temperature { get; set; }

    public Product(string name, double temperature)
    {
        Name = name;
        Temperature = temperature;
    }
}