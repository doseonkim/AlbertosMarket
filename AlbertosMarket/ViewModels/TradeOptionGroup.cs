using AlbertosMarket.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlbertosMarket.ViewModels
{
    public class TradeOptionGroup
    {
        public TradeOption? Option { get; set; }

        public int TradeCount { get; set; }
    }
}