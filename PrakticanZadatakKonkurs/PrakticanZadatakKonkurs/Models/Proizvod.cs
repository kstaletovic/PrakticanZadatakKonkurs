using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrakticanZadatakKonkurs.Models
{
    [Table("Proizvod")]
    public class Proizvod
    {
        [Key]
        public int ProizvodId { get; set; }

        [Required(ErrorMessage = "Unesite naziv")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Unesite opis")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Unesite kategoriju")]
        public string Kategorija { get; set; }

        [Display(Name = "Proizvođač")]
        [Required(ErrorMessage = "Unesite proizvođača")]
        public string Proizvodjac { get; set; }

        [Display(Name = "Dobavljač")]
        [Required(ErrorMessage = "Unesite dobavljača")]
        public string Dobavljac { get; set; }

        [Required(ErrorMessage = "Unesite cenu")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Cena sadrži samo brojeve")]
        public float Cena { get; set; }
    }
}