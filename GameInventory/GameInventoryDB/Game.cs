//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameInventoryDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameType { get; set; }
        public string GamePlatform { get; set; }
        public int GameQuantity { get; set; }
        public decimal GameCostPerUnit { get; set; }
        public decimal GameTotalCost { get; set; }
        public decimal GameRetailPerUnit { get; set; }
        public decimal GameTotalRetail { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
