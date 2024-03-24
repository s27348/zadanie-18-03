using System;

namespace ContainerApp
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private const double MAX_CAPACITY_NORMAL_LOAD = 0.9;
        private const double MAX_CAPACITY_HAZARDOUS_LOAD = 0.5;
        
        private bool IsHazardousLoad;
        
        public LiquidContainer(double height, double tareWeight, double depth, string serialNumber, double maxWeight, bool isHazardousLoad)
            : base(height, tareWeight, depth, serialNumber, maxWeight)
        {
            IsHazardousLoad = isHazardousLoad;
        }
        
        public void LoadCargo(double cargoWeight)
        {
            double maxLoad = IsHazardousLoad ? MAX_CAPACITY_HAZARDOUS_LOAD * MaxWeight : MAX_CAPACITY_NORMAL_LOAD * MaxWeight;

            if (cargoWeight > maxLoad)
            {
                throw new OverfillException("Masa ładunku przekracza pojemność kontenera.");
            }

            CargoWeight = cargoWeight;
        }

        public void EmptyContainer()
        {
            CargoWeight = 0;
        }

        public void NotifyDanger(string containerNumber)
        {
            if (IsHazardousLoad && CargoWeight > MaxWeight * 0.5 || !IsHazardousLoad && CargoWeight > MaxWeight * 0.9)
            {
                Console.WriteLine($"Wykryto niebezpieczną sytuację w kontenerze {containerNumber}");
            }
        }
    }
}