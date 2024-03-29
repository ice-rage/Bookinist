﻿using System.ComponentModel.DataAnnotations.Schema;
using Bookinist.DAL.Entities.Base;

namespace Bookinist.DAL.Entities
{
    public class Deal : Entity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public int BuyerId { get; set; }

        public Buyer Buyer { get; set; }

        public override string ToString() => $"The deal for the book {Book} sale between {Seller} " +
                                             $"and {Buyer} at a price of {Price:C}";
    }
}
