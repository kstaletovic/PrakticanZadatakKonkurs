using PrakticanZadatakKonkurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrakticanZadatakKonkurs.ViewModels
{
    public class ProizvodiViewModel
    {
        public List<Proizvod> ProizvodiJSON { get; set; }

        public List<Proizvod> ProizvodiBaza { get; set; }
    }
}