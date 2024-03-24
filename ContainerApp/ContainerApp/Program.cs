using System;
using System.Collections.Generic;

namespace ContainerApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var coolingContainer = new CoolingContainer(200, 1000, 150, SerialNumberGenerator.GenerateSerialNumber(ContainerType.Cooling), 6000, 14);
            var liquidContainer = new LiquidContainer(180, 800, 120, SerialNumberGenerator.GenerateSerialNumber(ContainerType.Liquid), 4500, false);
            var gasContainer = new GasContainer(150, 700, 100, SerialNumberGenerator.GenerateSerialNumber(ContainerType.Gas), 2800);

            var bananas = new Product("Banany", 13.3);
            var fish = new Product("Ryby", 2);

            var containerShip1 = new ContainerShip(50, 3, 10);
            var containerShip2 = new ContainerShip(46, 2, 20);

            
            // Wyświetlanie informacji o kontenerach
            Console.WriteLine("Informacje o kontenerach:");
            Console.WriteLine($"Kontener chłodniczy: Masa ładunku - {coolingContainer.CargoWeight} kg, Wysokość - {coolingContainer.Height} cm, Numer seryjny - {coolingContainer.SerialNumber}");
            Console.WriteLine($"Kontener na płyny: Masa ładunku - {liquidContainer.CargoWeight} kg, Wysokość - {liquidContainer.Height} cm, Numer seryjny - {liquidContainer.SerialNumber}");
            Console.WriteLine($"Kontener na gaz: Masa ładunku - {gasContainer.CargoWeight} kg, Wysokość - {gasContainer.Height} cm, Numer seryjny - {gasContainer.SerialNumber}");
            
            Console.WriteLine($"Konteneroweic 1 przewozi kontenery: {containerShip1.StoredContainers()}");
            Console.WriteLine($"Konteneroweic 2 przewozi kontenery: {containerShip2.StoredContainers()}");
            
            try
            {
                coolingContainer.LoadCargo(100, bananas);
                coolingContainer.LoadCargo(1000, bananas);
                // coolingContainer.LoadCargo(500, fish);
                liquidContainer.LoadCargo(3000);
                gasContainer.LoadCargo(2800);

                List<Container> containers = new List<Container>();
                containers.Add(liquidContainer);
                containers.Add(gasContainer);
                
                containerShip1.LoadContainerShip(coolingContainer);
                // containerShip.LoadContainerShip(liquidContainer);
                // containerShip.LoadContainerShip(gasContainer);
                
                // containerShip1.RemoveContainer(coolingContainer);
                containerShip1.LoadContainerShip(containers);
                
                containerShip1.MoveContainer(coolingContainer, containerShip2);
                containerShip1.MoveContainer(liquidContainer, containerShip2);
            }
            catch (InvalidOperationException ex)
            {
                gasContainer.NotifyDanger(gasContainer.SerialNumber);
                liquidContainer.NotifyDanger(liquidContainer.SerialNumber);
                Console.WriteLine(ex.Message);
            }
            liquidContainer.EmptyContainer();                
            gasContainer.EmptyContainer();
            Console.WriteLine("\nInformacje o kontenerach:");
            Console.WriteLine($"Kontener chłodniczy: Masa ładunku - {coolingContainer.CargoWeight} kg, Wysokość - {coolingContainer.Height} cm, Numer seryjny - {coolingContainer.SerialNumber}");
            Console.WriteLine($"Kontener na płyny: Masa ładunku - {liquidContainer.CargoWeight} kg, Wysokość - {liquidContainer.Height} cm, Numer seryjny - {liquidContainer.SerialNumber}");
            Console.WriteLine($"Kontener na gaz: Masa ładunku - {gasContainer.CargoWeight} kg, Wysokość - {gasContainer.Height} cm, Numer seryjny - {gasContainer.SerialNumber}");        
            
            Console.WriteLine($"Kontenerowiec 1 przewozi kontenery: {containerShip1.StoredContainers()}");
            Console.WriteLine($"Konteneroweic 2 przewozi kontenery: {containerShip2.StoredContainers()}");
            
            Console.WriteLine($"\nKontenerowiec 1 może płynąć z maksymalną prędkością {containerShip1.MaxSpeed} węzłów, jest w stanie pomieśćić {containerShip1.MaxContainersNumber} kontenery/ów o łącznej masie {containerShip1.MaxContainersWeight * 1000} kg.");
        }
    }
}