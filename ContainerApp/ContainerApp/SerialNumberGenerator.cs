using System;

namespace ContainerApp
{
    public class SerialNumberGenerator
    {
        private static int _id = 1;

        public static string GenerateSerialNumber(ContainerType type)
        {
            string prefix = "KON-";
            string containerType = type switch
            {
                ContainerType.Cooling => "C",
                ContainerType.Liquid => "L",
                ContainerType.Gas => "G",
                _ => throw new ArgumentException("Niepoprawny typ kontenera"),
            };
            return $"{prefix}{containerType}-{_id++}";
        }
    }
}