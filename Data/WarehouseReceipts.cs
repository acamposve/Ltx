
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Data
{

using System;
    using System.Collections.Generic;
    
public partial class WarehouseReceipts
{

    public int codeWR { get; set; }

    public string GUID { get; set; }

    public Nullable<System.DateTime> CreatedOn { get; set; }

    public string Number { get; set; }

    public string CreatedByName { get; set; }

    public Nullable<int> ModeOfTransportCode { get; set; }

    public string IssuedBy { get; set; }

    public string Shipper { get; set; }

    public string Consignee { get; set; }

    public string DestinationAgent { get; set; }

    public Nullable<int> CreatorNetworkID { get; set; }

    public Nullable<int> TotalPieces { get; set; }

    public string TotalWeight { get; set; }

    public string TotalVolume { get; set; }

    public string TotalVolumeWeight { get; set; }

    public string ChargeableWeight { get; set; }

    public Nullable<double> TotalValue { get; set; }

    public string Status { get; set; }

    public Nullable<bool> HasAttachments { get; set; }

    public string BillingClient { get; set; }

    public Nullable<bool> IsOnline { get; set; }

    public Nullable<bool> IsLiquidated { get; set; }

    public string TrackingNumber { get; set; }

    public string PackageName { get; set; }

    public Nullable<int> WHRItemID { get; set; }

    public string Length { get; set; }

    public string Height { get; set; }

    public string Width { get; set; }

    public string Weight { get; set; }

    public Nullable<bool> ContainedPiecesWeightIncluded { get; set; }

    public string Volume { get; set; }

    public string VolumeWeight { get; set; }

    public string PieceWeight { get; set; }

    public string PieceVolume { get; set; }

    public int Version { get; set; }

    public string LastItemID { get; set; }

}

}
