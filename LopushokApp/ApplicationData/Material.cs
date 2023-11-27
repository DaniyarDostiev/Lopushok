//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LopushokApp.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.ProductMaterial = new HashSet<ProductMaterial>();
        }
    
        public int materialId { get; set; }
        public Nullable<int> materialTypeId { get; set; }
        public Nullable<int> measurementId { get; set; }
        public string name { get; set; }
        public Nullable<int> quantityInPackage { get; set; }
        public Nullable<int> quantityInStock { get; set; }
        public Nullable<int> MinAvaliableOstatok { get; set; }
        public Nullable<int> price { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        public virtual Measurement Measurement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterial> ProductMaterial { get; set; }
    }
}