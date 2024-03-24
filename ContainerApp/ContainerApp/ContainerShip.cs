using System;
using System.Collections.Generic;

namespace ContainerApp;

public class ContainerShip
{
    private List<Container> Containers { get; set; } = new List<Container>();
    public  double MaxSpeed { get; private set; }
    public  int MaxContainersNumber { get; private set; }
    public double MaxContainersWeight { get; private set; }

    public ContainerShip(double maxSpeed, int maxContainersNumber, double maxContainersWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainersNumber = maxContainersNumber;
        MaxContainersWeight = maxContainersWeight;
    }

    public void LoadContainerShip(Container container)
    {
        if (TotalCargoWeight() + container.CargoWeight > MaxContainersWeight * 1000)
        {
            throw new InvalidOperationException("Nie można dodać kontenera. Osiągnięto maksymalną masę ładunku.");
        }
        
        if (Containers != null && Containers.Count >= MaxContainersNumber)
        {
            throw new InvalidOperationException("Nie można dodać więcej kontenerów. Osiągnięto maksymalną ilość kontenerów.");
        }
        
        Containers.Add(container);
    }
    
    public void LoadContainerShip(List<Container> containers)
    {
        double containersWeight = 0;
        
        foreach (var container in containers)
        {
            containersWeight += container.CargoWeight + container.TareWeight;
        }

        if (containersWeight + TotalCargoWeight() > MaxContainersWeight * 1000)
        {
            throw new InvalidOperationException("Nie można dodać kontenerów. Osiągnięto maksymalną masę ładunku.");
        }
        
        if (Containers != null && Containers.Count + containers.Count > MaxContainersNumber)
        {
            throw new InvalidOperationException("Nie można dodać więcej kontenerów. Osiągnięto maksymalną ilość kontenerów.");
        }

        foreach (var container in containers)
        {
            Containers.Add(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void MoveContainer(Container container, ContainerShip containerShip)
    {
        if (containerShip.TotalCargoWeight() + container.CargoWeight + container.TareWeight > containerShip.MaxContainersWeight * 1000)
        {
            throw new OverfillException("Nie można dodać kontenerów. Osiągnięto maksymalną masę ładunku.");
        }

        if (containerShip.Containers != null && containerShip.Containers.Count >= containerShip.MaxContainersNumber)
        {
            throw new InvalidOperationException("Nie można dodać więcej kontenerów. Osiągnięto maksymalną ilość kontenerów.");
        }
        
        Containers.Remove(container);
        containerShip.Containers.Add(container);        
    }


    public double TotalCargoWeight()
    {
        double totalWeight = 0;

        if (Containers == null)
        {
            return 0;
        }
        
        foreach (var container in Containers)
        {
            totalWeight += container.CargoWeight + container.TareWeight;
        }

        return totalWeight;
    }

    public string StoredContainers()
    {
        if (Containers == null)
        {
            return "Brak kontenerów";
        }
        
        string containerNames = "";
        foreach (var container in Containers)
        {
            containerNames += container.SerialNumber + " ; ";
        }

        return containerNames;
    }
}