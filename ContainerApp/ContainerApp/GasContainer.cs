using System;

namespace ContainerApp
{
    public class GasContainer : Container, IHazardNotifier
    {
        
        public GasContainer(double height, double tareWeight, double depth, string serialNumber, double maxWeight)
            : base(height, tareWeight, depth, serialNumber, maxWeight)
        {
        }
        
        public void LoadCargo(double cargoWeight)
        {
            if (cargoWeight > MaxWeight)
            {
                throw new OverfillException("Masa ładunku przekracza pojemność kontenera.");
            }
            
            CargoWeight = cargoWeight;
        }

        public void EmptyContainer()
        {
            CargoWeight = CargoWeight * 0.05;
        }

        public void NotifyDanger(string containerNumber)
        {
            // Console.WriteLine($"Wykryto niebezpieczną sytuację w kontenerze {containerNumber}");
        }
    }
}