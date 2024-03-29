﻿using System.Collections.Generic;
using Bookinist.DAL.Entities.Base;

namespace Bookinist.DAL.Entities
{
    public class Category : NamedEntity
    {
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();

        public override string ToString() => $"Category {Name}";
    }
}
