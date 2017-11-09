using System.Collections.Generic;

namespace MyWoodenHouse.Models.Contracts
{
    public interface IPage
    {
        string Name { get; set; }

        string Description { get; set; }

        string HtmlContent { get; set; }

        string LanguageCultureName { get; set; }
    }
}
