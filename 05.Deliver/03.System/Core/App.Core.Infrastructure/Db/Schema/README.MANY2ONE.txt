
## MANY 2 ONE

Use Cases: A Category, Type, etc. 


Specs:
* The entity has a FK (int or Guid) property, and an Object Navigation property
* The referenced entity does not have a navigation property back to the first object
  (eg: You would not want a Category Object to have a Collection property that returns all Entities who have that Category...)

modelBuilder.Entity<WF03>()
            .HasRequired(wi => wi.LoanMaintenanceType)
            .WithMany()
            .HasForeignKey(wi => wi.LoanMaintenanceTypeFK);

The entity (WF03) would look like this:
public class WF03 {
  ...
  public LoanMaintenanceTypeFK {get;set;}
  public LoanMaintenanceType {get;set;}
  ...
}

And the other side would have the following:

public class LoanMaintenanceType {
  ...
  public Guid Id {get;set;}
}



