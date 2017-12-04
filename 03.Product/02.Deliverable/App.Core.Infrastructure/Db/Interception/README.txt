The OnSaving method of DbContexts are overwritten 
to ensure that entities are passed through any 
Interceptor Strategies defined.

These fill in the blanks, removing the need
for Domain developers to have to worry about 
forgetting to fill in CreatedBy/When ModifiedBy/When
etc.


