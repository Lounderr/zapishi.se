﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ZapishiSe.Data.Models
{
    public class BusinessPromotion
    {
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }
    }
}
