﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AtmDataContext:DbContext
    {
        public AtmDataContext():base("DatabaseConnection")
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<BankInfo> BankInfos { get; set; }
        public DbSet<ATMInfo> ATMInfos { get; set; }
        public DbSet<ATMHistory> ATMHistories { get; set; }
        public DbSet<AccountCard> AccountCards { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }
        public DbSet<ATMTransaction> ATMTransactions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
