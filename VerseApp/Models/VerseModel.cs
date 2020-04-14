using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace VerseApp.Models
{
    public class VerseModel
    {
        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Testament { get; set; }

        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Chapter { get; set; }

        [StringLength(40, MinimumLength = 3)]
        [Required]
        public string Verse { get; set; }

        [StringLength(1000, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }

        public VerseModel()
        {
            Testament = "";
            Book = "";
            Chapter = "";
            Verse = "";
            Text = "";
        }

        public VerseModel(string testament, string book, string chapter, string verse, string text)
        {
            Testament = testament;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
        }
    }
}