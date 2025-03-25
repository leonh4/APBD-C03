namespace C03;

public class CooledContainer : Container, IHazardNotifier
{
    public double Temperature { get; set; }
    public string ProductType { get; set; }

    public static Dictionary<string, double> AvailableProducts = new Dictionary<string, double>()
    {
        {"Banana", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public CooledContainer(double height, double selfWeight, double depth, double maxWeight, double temperature, string productType) 
        : base(height, selfWeight, depth, maxWeight, "C")
    {
        if (!AvailableProducts.ContainsKey(productType)) AvailableProducts.Add(productType, temperature);
        
        if (temperature < AvailableProducts[productType])
        {
            Console.WriteLine($"Temperature can't be lower than recommended for producut {productType}. " +
                              $"Adjusting the temperature to: {AvailableProducts[productType]}");
            Temperature = AvailableProducts[productType];
        } else
        {
            Temperature = temperature;
        }

        ProductType = productType;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Danger in container: {SerialNumber}. + {message}");
    }

    public void LoadContainer(double mass, string productType)
    {
        if (ProductType == string.Empty)
        {
            ProductType = productType;
            Temperature = AvailableProducts[productType];
        }
        if (productType != ProductType)
        {
            Console.WriteLine($"Can't load container with a different product type. " +
                              $"Current product type: {ProductType}, attempted product type: {productType}");
            return;
        }
        base.LoadContainer(mass);
    }

    public override void UnloadContainer()
    {
        ProductType = string.Empty;
        base.UnloadContainer();
    }

    public override string ToString()
    {
        return base.ToString() + $", temperature {Temperature}, proucts {ProductType}";
    }
}