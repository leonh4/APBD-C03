namespace C03;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(double height, double selfWeight, double depth, double maxWeight, double pressure) : base(height, selfWeight, depth, maxWeight, "G")
    {
        Pressure = pressure;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Danger in container: {SerialNumber}. + {message}");
    }
    

    public override void UnloadContainer()
    {
        ContentMass -= ContentMass * 0.95;
    }

    public override string ToString()
    {
        return base.ToString() + $", pressure {Pressure}";
    }
}