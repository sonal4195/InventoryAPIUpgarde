//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetType
    {
        public AssetType()
        {
            this.Assets = new HashSet<Asset>();
        }
    
        public int AssetTypeID { get; set; }
        public string AssetTypeDesc { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
