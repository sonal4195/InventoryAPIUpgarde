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
    
    public partial class UserAssetLog
    {
        public int UserAssetLogID { get; set; }
        public string EmailID { get; set; }
        public int AssetID { get; set; }
        public string TriggerAction { get; set; }
        public System.DateTime Timestamp { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
