﻿using System;
using System.Collections.Generic;

namespace third
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public int PhoneId { get; set; }

        public virtual Phones Phone { get; set; }
    }
}
