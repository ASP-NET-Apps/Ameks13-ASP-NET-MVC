namespace MyWoodenHouse.Models.Contracts
{
    public interface IMaterialBuilding
    {
        int BuildingId { get; set; }

        int MaterialId { get; set; }

        Building Building { get; set; }

        Material Material { get; set; }
    }
}
