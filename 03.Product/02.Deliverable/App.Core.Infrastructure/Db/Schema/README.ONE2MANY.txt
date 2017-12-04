
## ONE TO MANY
One to many's can come in one of several 
If you want to reference 

    modelBuilder.Entity<School>()
            .HasRequired(x => x.Tenant)
            .WithMany()
            .HasForeignKey(x => x.TenantFK) 
            .WillCascadeOnDelete(false);



THs works with a model that looks like:

public class School {
  public Guid Id {get;set;}
  ...
  public Guid TenantFK {get;set;}
  public Tenant {get;set;}
}

If the Tenant was Optional, you make the Guid optional (Guid?) and update the  Link to reflect that:


    modelBuilder.Entity<School>()
            .HasOptional(x => x.Tenant)
            .WithMany()
            .HasForeignKey(x => x.TenantFK) 
            .WillCascadeOnDelete(false);


public class School {
  public Guid Id {get;set;}
  ...
  public Guid? TenantFK {get;set;}
  public Tenant {get;set;}
}



