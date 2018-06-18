# MVC6.Grid.REST
Call the right API using MVC6.Grid query string

### The problem
We got a lot of table to sort, filter and we had less time to spent.

### The solution
Just a rapid search on Google and a library arised like an angel: http://mvc6-grid.azurewebsites.net

### The problem (again)
This found library fits well in case of small quantity of rows and very well if it can interface directly with entity framework. But not in our case.
Our web application didn't interface directly with EF, because of webapi layer, and we couldn't pass whole data (1k of rows minimum) per request.

### The solution
In order to avoid any performance issue we created a wrapper class wich handles all types of filter requests, and then, thanks to `System.Linq.Dynamic.Core`, we 
created dynamic Where conditions.

### Ok, read enough give me the example

First of all, get the IQueryable from EF:
```
var products = db.Products();
```

Create your object using the class `new TableFilterBuilder()`, you have 3 overloads. 
You can directly pass the collection `IQueryCollection` from your httpContext.

If you want to filter the products IQueryable just put the previous instanced as following:

```
var tableFilter = new TableFilterBuilder(...);


var filteredProducts = tableFilter.FilterWithCondition(filteredProducts);
// New output is the same IQueryable with a Where condition applied.

```

This give you a lot of flexibility because you can, inside a for loop as example, attach multiple filter.

If you like my little help, leave a star!

Find Issues:  
  - WIP
