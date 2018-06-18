using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMVC.Models
{
    public class CV
    {
        public int Id { get; set; }
        public byte[] PDFFile { get; set; }
        public Advert Adverts { get; set; }
    }
}