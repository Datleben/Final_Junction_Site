﻿using Final_Junction_Site.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SportsStore.Models;

namespace Final_Junction_Site.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<Site> Sites { get; set; }
        public DbSet<TestDBClass> TestDBClass { get; set; } // remove when done testing, and add Sites (above line). Will need to add other tables too
        public DbSet<Site> Site { get; internal set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Customer> Customer { get; internal set; }
    }
}