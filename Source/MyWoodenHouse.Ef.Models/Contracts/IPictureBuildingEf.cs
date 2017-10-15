namespace MyWoodenHouse.Ef.Models.Contracts
{
    public interface IPictureBuildingEf
    {
        int BuildingId { get; set; }

        int PictureId { get; set; }

        Building Building { get; set; }

        Picture Picture { get; set; }
    }
}
