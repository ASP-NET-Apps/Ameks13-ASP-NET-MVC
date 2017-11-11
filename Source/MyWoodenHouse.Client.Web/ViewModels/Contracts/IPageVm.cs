namespace MyWoodenHouse.ViewModels.Contracts
{
    public interface IPageVm
    {
        string Description { get; set; }
        string HtmlContent { get; set; }
        int Id { get; set; }
        string LanguageCultureName { get; set; }
        string ModelName { get; set; }
        string Name { get; set; }
    }
}