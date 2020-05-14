using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenMovie.Models;

namespace VenMovie.ViewModel
{
    public class MovieCustomer
    {
        public Movie movie { get; set; }
       public List<Customer> customers { get; set; }
    }
}