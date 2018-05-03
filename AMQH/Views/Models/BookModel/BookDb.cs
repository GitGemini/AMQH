namespace AMQH.Views.Models.BookModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AMQH.Models.BookModel;

    public partial class BookDb : DbContext
    {
        public BookDb()
            : base("name=BookDb")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderHeaders> OrderHeaders { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                 .HasMany(e => e.Order)
                 .WithRequired(e => e.Book)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookCategory>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.BookCategory)
                .HasForeignKey(e => e.BCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderHeaders>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.OrderHeaders)
                .HasForeignKey(e => e.OHeaderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.OrderHeaders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
