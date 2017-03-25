using MyWoodenHouse.Contracts;
using MyWoodenHouse.Contracts.PureModels;
using MyWoodenHouse.Ef.Models;

namespace MyWoodenHouse.Pure.Models
{
    public class CategoryModel : ICategoryModel, IHasIntId
    {
        public CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
