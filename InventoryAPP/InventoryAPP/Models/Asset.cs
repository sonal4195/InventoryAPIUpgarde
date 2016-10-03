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
    
    public partial class Asset
    {
        public Asset()
        {
            this.Tickets = new HashSet<Ticket>();
            this.UserAssets = new HashSet<UserAsset>();
            this.AssetLogs = new HashSet<AssetLog>();
            this.TicketLogs = new HashSet<TicketLog>();
            this.UserAssetLogs = new HashSet<UserAssetLog>();
        }
    
        public int AssetID { get; set; }
        public int AssetTypeID { get; set; }
        public int BUID { get; set; }
        public string SerialNo { get; set; }
        public string Model { get; set; }
        public string Warranty { get; set; }
        public string Ram { get; set; }
        public string Processor { get; set; }
        public string OS { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string ServiceTag { get; set; }
        public string Brand { get; set; }
    
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual ICollection<UserAsset> UserAssets { get; set; }
        public virtual ICollection<AssetLog> AssetLogs { get; set; }
        public virtual ICollection<TicketLog> TicketLogs { get; set; }
        public virtual ICollection<UserAssetLog> UserAssetLogs { get; set; }
    }
}
