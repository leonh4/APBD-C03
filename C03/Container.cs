namespace C03;

public abstract class Container
{
    public double ContentMass { get; set; } 
    public double Height { get; set; }
    public double SelfWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxWeight { get; set; }
    private static int _number = 0;
    

    public Container(double height, double selfWeight, double depth, double maxWeight, string containerType)
    {
        ContentMass = 0;
        Height = height;
        SelfWeight = selfWeight;
        Depth = depth;
        MaxWeight = maxWeight;
        SerialNumber = $"KON-{containerType}-{++_number}";
    }

    public virtual void LoadContainer(double mass)
    {
        if (MaxWeight < ContentMass + mass + SelfWeight)
        {
            throw new OverfillException($"Mass cannot be greater than MaxWeight. " +
                                        $"Max weight={MaxWeight}, container weight after loading={ContentMass + mass + SelfWeight}.");
        }
        ContentMass += mass;
    }

    public virtual void UnloadContainer()
    {
        ContentMass = 0;
    }

    public double GetTotalWeight()
    {
        return SelfWeight + ContentMass;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber}, contents mass {ContentMass}, height {Height}, container's weight {SelfWeight}," +
               $" depth {Depth}, maximum weight {MaxWeight}";
    }
}