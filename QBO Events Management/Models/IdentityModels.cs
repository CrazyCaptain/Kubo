﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace QBO_Events_Management.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

		public string FullName { get; set; }
		//public string Email { get; set; }
		public bool Gender { get; set; }

		////public bool EmailConfirmed { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }


		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

		//public static implicit operator ApplicationUser(ApplicationUser v)
		//{
		//	throw new NotImplementedException();
		//}
	}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
		//, throwIfV1Schema: false
		{
		}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
		
		public DbSet<Event> Events { get; set; }
		

	}
}