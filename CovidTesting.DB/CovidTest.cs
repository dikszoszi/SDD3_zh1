﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidTesting.DB
{
    [Table("covidtests")]
    public class CovidTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public System.DateTime Date { get; set; }

        [Required]
        public bool IsPositive { get; set; }

        [Required]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        [NotMapped]
        public virtual Player Player { get; set; }
    }
}
