namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IBuildingMaterialEf
    {
        int BuildingId { get; set; }

        int MaterialId { get; set; }
    }
}
