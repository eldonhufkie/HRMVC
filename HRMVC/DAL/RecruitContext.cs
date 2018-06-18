using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HRMVC.Models;

namespace HRMVC.DAL
{
    public class RecruitContext : DbContext
    {
        public RecruitContext():base("name=recruiteCString")
        {
            
        }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<CV> Cvs { get; set; }
    }
}