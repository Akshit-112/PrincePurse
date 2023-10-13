using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PrincePurse.Models
{
    public class PurseStyleViewModel
    {
        public List<Purse> Purses { get; set; }
        public SelectList Styles { get; set; }
        public string PurseStyle { get; set; }
        public string SearchString { get; set; }
    }
}
