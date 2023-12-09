﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ZapishiSe.Data.Models
{
    public enum AppointmentStatus
    {
        Accepted,
        Canceled,
        RefusedService,
    }

    public class BookedAppointment
    {
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public virtual Business Business { get; set; }

        public bool IsAttended { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}