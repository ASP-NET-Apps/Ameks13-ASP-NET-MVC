namespace MyWoodenHouse.Models.Contracts
{
    public interface IPictureBuilding
    {
        int BuildingId { get; set; }

        int PictureId { get; set; }

        Building Building { get; set; }

        Picture Picture { get; set; }
    }
}
