﻿using CSLabs.Api.Models.ModuleModels;
using CSLabs.Api.Models.UserModels;
using CSLabs.Api.Util;
using Microsoft.EntityFrameworkCore;

namespace CSLabs.Api.Models
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        { }

        public DbSet<Badge> Badges { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Module> Modules { get; set; }
        
        public DbSet<Lab> Labs { get; set; }
        
        public DbSet<LabVm> LabVms { get; set; }
        public DbSet<UserModule> UserModules { get; set; }
        
        public DbSet<UserLab> UserLabs { get; set; }
        
        public DbSet<UserLabVm> UserLabVms { get; set; }
        
        public DbSet<Hypervisor> Hypervisors { get; set; }
        public DbSet<HypervisorNode> HypervisorNodes { get; set; }
        
        public DbSet<ContactEmail> ContactEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
       {
           base.OnModelCreating(builder);
           
           Badge.OnModelCreating(builder);
           User.OnModelCreating(builder);
           
           // module section
           Module.OnModelCreating(builder);
           Lab.OnModelCreating(builder);
           LabVm.OnModelCreating(builder);
           UserModule.OnModelCreating(builder);
           // user module section
           UserModule.OnModelCreating(builder);
           UserLab.OnModelCreating(builder);
           UserLabVm.OnModelCreating(builder);
           // hypervisor
           Hypervisor.OnModelCreating(builder);
           HypervisorNode.OnModelCreating(builder);
           // configure many to many relationship
           UserUserModule.OnModelCreating(builder);
           ContactEmail.OnModelCreating(builder);
           builder.SnakeCaseDatabase();
           
       }
       
       public override int SaveChanges(bool acceptAllChangesOnSuccess)
       {
           ContextUtil.UpdateTimeStamps(ChangeTracker);
           return base.SaveChanges(acceptAllChangesOnSuccess);
       }

    }
}
