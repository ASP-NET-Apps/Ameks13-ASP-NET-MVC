//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWoodenHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Building
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Building()
        {
            this.Materials = new HashSet<Material>();
            this.Pictures = new HashSet<Picture>();
        }
    
        public int Id { get; set; }
        public Nullable<float> UsableArea { get; set; }
        public Nullable<float> BuiltUpArea { get; set; }
        public Nullable<int> FloorsCount { get; set; }
        public Nullable<int> RoomsCount { get; set; }
        public Nullable<int> BathroomsCount { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}