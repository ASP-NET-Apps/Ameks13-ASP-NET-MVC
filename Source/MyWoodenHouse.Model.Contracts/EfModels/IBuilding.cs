//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyWoodenHouse.Contracts.EfModels
//{
//    public interface IBuilding
//    {
//        int Id { get; set; }
//        Nullable<float> UsableArea { get; set; }
//        Nullable<float> BuiltUpArea { get; set; }
//        Nullable<int> FloorsCount { get; set; }
//        Nullable<int> RoomsCount { get; set; }
//        Nullable<int> BathroomsCount { get; set; }

//        int ProductId { get; set; }
//        int CategoryId { get; set; }

//        Category Category { get; set; }
//        Product Product { get; set; }
//        ICollection<Material> Materials { get; set; }
//        ICollection<Picture> Pictures { get; set; }
//    }
//}
