﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZapishiSe.Data.Models.Enums;

namespace ZapishiSe.Data.Models
{
    public class Business
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public Pricing Pricing { get; set; }

        public Address Address { get; set; }

        public int BusinessCategoryId { get; set; }

        public virtual BusinessCategory BusinessCategory { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<BusinessImage> BusinessImages { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<OpenHours> OpenHours { get; set; }

        public virtual ICollection<Holiday> Holidays { get; set; }

        public virtual ICollection<BookedAppointment> BookedAppintments { get; set; }

        public virtual ICollection<ApplicationUser> Favoriters { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BusinessReport> BusinessReports { get; set; }

        public virtual ICollection<BusinessPromotion> BusinessPromotions { get; set; }

        public virtual ICollection<VisitsEachMonth> VisitsEachMonth { get; set; }

        [NotMapped]
        public int TotalFavoriters => Favoriters.Count();

        [NotMapped]
        public int VisitsThisMonth => this.VisitsEachMonth?.Where(x => x.Year == DateTime.Now.Year && x.Month == DateTime.Now.Month).Single().Visits ?? 0;

        [NotMapped]
        public bool IsPromotionActive => this.BusinessPromotions?.Any(x => x.EndDateTime > DateTime.Now && x.StartDateTime <= DateTime.Now) ?? false;

        [NotMapped]
        public int TrustScore { get; set; }

        [NotMapped]
        public double ReviewsAverage => Reviews?.Average(x => x.Rating) ?? 0;
    }
}
