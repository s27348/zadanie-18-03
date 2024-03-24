namespace ContainerApp
{
    public abstract class Container
    {
        public double CargoWeight { get; set; }
        public double Height { get; set; }
        public double TareWeight { get; set; }
        public double Depth { get; set; }
        public string SerialNumber { get; set; }
        public double MaxWeight { get; set; }

        public Container(double height, double tareWeight, double depth, string serialNumber, double maxWeight)
        {
            CargoWeight = 0;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            SerialNumber = serialNumber;
            MaxWeight = maxWeight;
        }
    }
}