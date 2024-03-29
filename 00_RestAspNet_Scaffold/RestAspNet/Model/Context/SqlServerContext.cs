﻿using Microsoft.EntityFrameworkCore;

namespace RestAspNet.Model.Context
{
    public class SqlServerContext : DbContext
    {
        public  SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
