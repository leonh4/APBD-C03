namespace C03;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazard { get; set; }

    public LiquidContainer(double height, double selfWeight, double depth, double maxWeight, bool isHazard) : base(height, selfWeight, depth, maxWeight, "L")
    {
        IsHazard = isHazard;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Danger in container: {SerialNumber}. {message}");
    }

    public override void LoadContainer(double mass)
    {
        var limit = IsHazard ? MaxWeight * 0.5 : MaxWeight * 0.9;
        if (ContentMass + mass > limit)
        {
            Notify("Possible overloads are not supported.");
            return;
        }
        base.LoadContainer(mass);
    }

    public override void UnloadContainer()
    {
        IsHazard = false;
        base.UnloadContainer();
    }

    public override string ToString()
    {
        if (IsHazard)
        {
            return base.ToString() + ". THIS CONTAINER IS HAZARDOUS!";
        } 
        return base.ToString();
    }
}