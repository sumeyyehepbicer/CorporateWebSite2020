using CorporateWebSite.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<CustomInfo> CustomInfos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ServiceSetting> ServiceSettings { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AboutContent> AboutContents { get; set; }
        public DbSet<ProjectGallery> ProjectGalleries { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }
        public DbSet<HomePageVisibilty> HomePageVisibilties { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
