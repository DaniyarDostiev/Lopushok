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
    
    public partial class ProductMaterial
    {
        public int productMaterialId { get; set; }
        public string productArtcile { get; set; }
        public Nullable<int> materialId { get; set; }
        public Nullable<int> quantityOfMaterial { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
    }
}
