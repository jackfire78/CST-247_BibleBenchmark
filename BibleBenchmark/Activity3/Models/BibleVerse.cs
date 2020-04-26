using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Activity3.Models{
    [DataContract]
    public class BibleVerse{

        [Required]
        [DisplayName("TestamentSelection")]
        [StringLength(3, MinimumLength = 3)]
        [DefaultValue("")]
        [DataMember] 
        public String TestamentSelection { get; set; }

        [Required]
        [DisplayName("BookSelection")]
        [StringLength(50, MinimumLength = 1)]
        [DefaultValue("")]
        [DataMember]
        public String BookSelection { get; set; }

        [Required]
        [DisplayName("ChapterNumber")]
        [StringLength(3, MinimumLength = 1)]
        [DefaultValue("")]
        [DataMember]
        public String ChapterNumber { get; set; }

        [Required]
        [DisplayName("VerseNumber")]
        [StringLength(3, MinimumLength = 1)]
        [DefaultValue("")]
        [DataMember]
        public String VerseNumber { get; set; }

        [Required]
        [DisplayName("VerseText")]
        [StringLength(1000, MinimumLength = 1)]
        [DefaultValue("")]
        [DataMember]
        public String VerseText { get; set; }

        public BibleVerse() {
            this.TestamentSelection = "";
            this.BookSelection = "";
            this.ChapterNumber = "";
            this.VerseNumber = "";
            this.VerseText = "";
        }

        public BibleVerse(String testamentSelection, String bookSelection, String chapterNumber, String verseNumber, String verseText) {
            TestamentSelection = testamentSelection;
            BookSelection = bookSelection;
            ChapterNumber = chapterNumber;
            VerseNumber = verseNumber;
            VerseText = verseText;
        }


    }
}