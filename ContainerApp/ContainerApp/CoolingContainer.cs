using System;

namespace ContainerApp
{
    public class CoolingContainer : Container
    {
        private Product Product { get; set; } = null;
        private double ContainerTemperature { get; set; }
        public CoolingContainer(double height, double tareWeight, double depth, string serialNumber, double maxWeight, double containerTemperature)
            : base(height, tareWeight, depth, serialNumber, maxWeight)
        {
            ContainerTemperature = containerTemperature;
        }
        
        public void LoadCargo(double cargoWeight, Product product)
        {
            if (Product != null && product.Name != Product.Name)
            {
                throw new ArgumentException("Nie możesz załadować tego typu ładunku do tego kontenera");
            }

            Product = product;

            if (product.Temperature > ContainerTemperature)
            {
                throw new ArgumentException("Temperatura w tym kontenerze jest zbyt niska");
            }
            
            if (cargoWeight > MaxWeight)
            {
                throw new OverfillException("Masa ładunku przekracza pojemność kontenera");
            }
            
            CargoWeight += cargoWeight;
        }

        public void EmptyContainer()
        {
            CargoWeight = 0;
            Product = null;
        }
    }
}