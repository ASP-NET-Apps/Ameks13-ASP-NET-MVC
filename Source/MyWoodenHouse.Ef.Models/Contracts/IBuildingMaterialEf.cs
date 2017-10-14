namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IMaterialBuildingEf
    {
        int BuildingId { get; set; }

        int MaterialId { get; set; }

        Building Building { get; set; }

        Material Material { get; set; }
    }
}
