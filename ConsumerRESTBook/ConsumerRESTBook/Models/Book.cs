﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumerRESTBook.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
    }
}