namespace C03;

class Program
{
    static void Main(string[] args)
    {
        var l1 = new LiquidContainer(1111, 200, 1000, 2000, false);
        l1.LoadContainer(500);
        l1.LoadContainer(1500);
        Console.WriteLine(l1.ToString());
        Console.WriteLine();
        
        var l2 = new LiquidContainer(500, 150, 450, 2000, true);
        l2.LoadContainer(500);
        Console.WriteLine(l2.ToString());
        l2.LoadContainer(1500);
        l2.UnloadContainer();
        Console.WriteLine(l2.ToString());
        Console.WriteLine();
        
        var g1 = new GasContainer(500, 150, 450, 2000, 500);
        g1.LoadContainer(500);
        g1.LoadContainer(331);
        g1.UnloadContainer();
        Console.WriteLine(g1.ToString());
        g1.LoadContainer(500);
        Console.WriteLine(g1.ToString());
        Console.WriteLine();
        
        var g2 = new GasContainer(500, 150, 450, 2000, 400);
        g2.LoadContainer(500);
        //g2.LoadContainer(1351);
        Console.WriteLine();
        
        var c1 = new CooledContainer(500, 150, 450, 2000, 2, "Fish");
        c1.LoadContainer(500);
        Console.WriteLine(c1.ToString());
        Console.WriteLine();
        
        var c2 = new CooledContainer(500, 150, 450, 2000, 11, "Apple");
        c2.LoadContainer(1600);
        Console.WriteLine(c2.ToString());
        Console.WriteLine();
        
        var c3 = new CooledContainer(500, 150, 450, 2000, -1, "Chocolate");
        c3.LoadContainer(500);
        Console.WriteLine(c3.ToString());
        c3.LoadContainer(100, "Apple");
        c3.UnloadContainer();
        c3.LoadContainer(100, "Apple");
        Console.WriteLine(c3.ToString());
        Console.WriteLine();
        
        List<Container> containers = new List<Container>();
        containers.Add(l1);
        containers.Add(l2);
        containers.Add(g1);
        containers.Add(g2);
        containers.Add(c3);
        Console.WriteLine(String.Join(", ", containers));
        Console.WriteLine();
        
        Ship ship = new Ship(1519, 6000, 7);
        ship.LoadContainer(c1);
        ship.LoadContainer(c2);
        Console.WriteLine(ship.ToString());
        ship.LoadContainers(containers);
        Console.WriteLine(ship.ToString());
        ship.LoadContainer(new LiquidContainer(1111, 200, 1000, 2000, false));
        Console.WriteLine();
        
        Ship ship2 = new Ship(1519, 500, 3);
        ship2.LoadContainer(new LiquidContainer(1111, 600, 1000, 2000, true));
        Console.WriteLine();
        
        ship.RemoveContainer("KON-C-5");
        Console.WriteLine(ship.ToString());
        Console.WriteLine();
        
        ship.MoveContainerToShip("KON-C-6", ship2);
        Console.WriteLine(ship.ToString());
        Console.WriteLine(ship2.ToString());
        Console.WriteLine();
        
        ship.ReplaceContainer("KON-L-1", new LiquidContainer(1111, 200, 1000, 2000, true));
        Console.WriteLine(ship.ToString());
        
    }
}