﻿namespace Instagram.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = default!;
    }
}
