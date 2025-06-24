﻿using HirefyAI.Domain.Common;

namespace HirefyAI.Domain.Entities
{
    public class Book : Auditable
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }
    }

    public enum BookType
    {
        Paperback,
        Ebook,
        Audiobook
    }
}
