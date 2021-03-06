﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.UI.Models
{
    public class PagingInfo
    {
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
    }
}