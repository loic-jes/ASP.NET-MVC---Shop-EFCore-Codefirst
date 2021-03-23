using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_EFCore_Codefirst.Models
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {

        }


        public DbSet<Models.Command> Commands { get; set; }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.CommandProduct> CommandProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.Command>()
                .HasOne(command => command.Customer)
                .WithMany(Customer => Customer.Commands)
                .HasForeignKey(Command => Command.CustomerId);

            builder.Entity<Models.CommandProduct>()
                .HasKey(CommandProduct => new { CommandProduct.CommandId, CommandProduct.ProductId });

            builder.Entity<Models.CommandProduct>()
                .HasOne(CommandProduct => CommandProduct.Command)
                .WithMany(Command => Command.CommandProducts)
                .HasForeignKey(CommandProduct => CommandProduct.CommandId);

            builder.Entity<Models.CommandProduct>()
                .HasOne(CommandProduct => CommandProduct.Product)
                .WithMany(Product => Product.CommandProducts)
                .HasForeignKey(CommandProduct => CommandProduct.ProductId);

        }














    }
}
