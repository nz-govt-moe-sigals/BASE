# About #

## Key Design Points ##

* (Body) MUST have a Collection Navigation Property of (BodyProperty)s.
* (BodyProperty) MUST have an FK back to (Body)
* (BodyProperty) MAY have a Entity Navigation Property back to (Body) but that is uncommon.
  * Hence `.WithOptional()` has no arguments.
* When we Delete (Body) we want it delete its children so we leave in place the default cascade behaviour. 
  * CHECK: because we can't configure Cascade delete on Collection Navigation Properties, if we wanted to 
    we would have to flip it around to be a many to many definition, and work on the OwnerFK definition.


## Example ##

THe syntax is crappy, but '.WithOptional' makes the collection 0-*.

	modelBuilder.Entity<Body>()
		.HasMany(x => x.Properties)
		.WithOptional()
		.HasForeignKey(x => x.OwnerFK);

    public class Body 
    {
		...
        public virtual ICollection<BodyProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<BodyProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<BodyProperty> _properties;
		...
	}
    public class BodyProperty
    {
		public virtual Guid Id {get;set;}
        public virtual Guid OwnerFK { get; set; }
		...
    }
