
/1-1:
       modelBuilder.Entity<User>()
           .HasRequired(i => i.BillingAddress)
           .WithMany(); //1-0: as it can be shared with User, don't bind Invoice and Address, so avoid .WithRequired


//////1-0..1:
     modelBuilder.Entity<Invoice>()
         .HasRequired(i => i.ShippingAddress)
         .WithMany()
         .WillCascadeOnDelete(false); //1-0: as it can be shared with User, don't bind Invoice and Address, so avoid .WithRequired

