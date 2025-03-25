namespace C03;

public class Ship
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxWeight { get; set; }
    public int MaxContainerCount { get; set; }

    public Ship(double maxSpeed, int maxWeight, int maxContainerCount)
    {
        MaxSpeed = maxSpeed;
        MaxWeight = maxWeight;
        MaxContainerCount = maxContainerCount;
    }

    public void LoadContainer(Container container)
    {
        double loadedWeight = GetTotalWeightOfContainers(Containers);

        if (loadedWeight + container.SelfWeight + container.ContentMass > MaxWeight)
        {
            Console.WriteLine($"Can't load container {container.SerialNumber}." +
                              $"This operation would overload the ship");
            return;
        }
        if (Containers.Count + 1 > MaxContainerCount)
        {
            Console.WriteLine($"Can't load container {container.SerialNumber}." +
                              $"This operation would exceed maximum number of containers ({MaxContainerCount})");
            return;
        }
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containersToLoad)
    {
        double loadedWeight = GetTotalWeightOfContainers(Containers);

        double weightToLoad = GetTotalWeightOfContainers(containersToLoad);

        if (loadedWeight + weightToLoad > MaxWeight)
        {
            Console.WriteLine("Can't load these containers. This operation would overload the ship");
            return;
        }

        if (Containers.Count + containersToLoad.Count > MaxContainerCount)
        {
            Console.WriteLine($"Can't load these containers. " +
                              $"This operation would exceed maximum number of containers {MaxContainerCount}");
            return;
        }
        
        Containers.AddRange(containersToLoad);
    }

    private double GetTotalWeightOfContainers(List<Container> containers)
    {
        double total = 0;
        foreach (var c in containers)
        {
            total += c.GetTotalWeight();
        }
        return total;
    }

    public void RemoveContainer(string serialNumber)
    {
        Containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void ReplaceContainer(string serialNumber, Container container)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        Containers[index] = container;
    }

    public void MoveContainerToShip(string serialNumber, Ship ship)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        ship.Containers.Add(Containers[index]);
        Containers.RemoveAt(index);
    }

    public override string ToString()
    {
        return $"Ship" +
               $"\n\tMax Speed: {MaxSpeed}" +
               $"\n\tMax Weight: {MaxWeight}" +
               $"\n\tMax Container Count: {MaxContainerCount}" +
               $"\n\tContainers: {String.Join(", ", Containers)}";
    }
}