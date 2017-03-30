# MyWoodenHome Todo list #

Do not forget to update the ToDo list immer wieder :)!
----------
## Features Driven Development

### Categories Feature
- [x] Create and execute seed insert stored procedure;
    - [x] Insert Into-Categories.sql
- [x] Database maping;
- [x] Extract and use data model interface;
- [x] Create data model second partial class and inherit the respective Interface;
- [x] Define guard constants;
- [x] Set data model constraints in MSSQL;
- [x] Set data model guard attributes in MetaData file;
- [x] Create Service Data class and implement the basic CRUD (Create, Read, Update, Delete) operations;
- [x] Bind all in the used container-Ninject.
- [x] Raw view for Preview, Edit, Insert, Delete;
- [x] Views:
	- [x] Index View:
		- [x] Put some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Create View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Edit View:
		- [x] Put some basic UI styles;
		- [x] Validation, Html.ValidationMessage, Html.ValidationSummary, Validation.RequireField;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Delete Confirm View:
		- [x] Extraxt delete consifm in modal form;
		- [x] Put some basic UI styles;
		- [x] Test every single function from the service Preview, Edit, Insert, Delete;
	- [x] Test every single function from the service Preview, Edit, Insert, Delete;
- [x] Add View Model with validation attributes;	
- [ ] Routing and base Redirects/Rewrites;
- [ ] Add to the Sitemap file and navigation;
- [ ] Unit testing;
- [x] Local IIS Deployment and manual test.
	http://www.mywoodenhouse.com
- [x] Azure Deployment;
	http://mywoodenhouse.azurewebsites.net/
- [ ] Continuous integrationa and delivery with Jenkins;

### Jenkins Tasks
1. [x] Create Automatic job for the unint tests - AutomaticUnitTesting.
1. [x] Configure code coverage reports.
1. [ ] Create Manual job for the integration tests - ManualIntegrationTesting.
1. [ ] Create Manual job for SIT IIS deploy - ManualSitDeploy.
1. [ ] Create Manual job for Live Azure deploy - ManualLiveAzureDeploy.

### General Tasks
1. [ ] Separate the Identity in project .Identity, and make it work again :);
1. [x] Crate separate Ef Models, Pure Models and View Models and MyMapper;
	- https://lostechies.com/jimmybogard/2009/06/30/how-we-do-mvc-view-models/
1. [x] Change the favicon;
1. [ ] Create SiteMap file. 


1. [ ] Install and make bundle for jQuery UI;
	- http://stackoverflow.com/questions/20081328/how-to-add-jqueryui-library-in-mvc-5-project

1. [x] Validation, Forms, Models, Client Side and Server Side - research;
1. [x] Modal forms with Bootstrap - research;
	- https://www.codeproject.com/Tips/826002/Bootstrap-Modal-Dialog-Loading-Content-from-MVC-Pa
1. [x] Jenkins integration - research;
1. [ ] Resource files integration - research;
	- http://www.devcurry.com/2013/02/aspnet-mvc-using-resource-files-to.html
1. [x] Upload in the Cloud - research;

----------

## Cowboy Driven Development - Single Tasks

### Models ###
1. [ ] Model Interfaces;
1. [ ] Add [Key] and other attributes to models;
1. [ ] Constants;
	- [ ] Models validation constants.

### Database ###
1. [ ] Create databse and main tables relations;
1. [ ] IsDeleted field for all Models and Delete() Method change;
1. [ ] Extract the connnectionStrings in separate file and add the file as sourceFile in all projects;
1. [ ] Add Services project;

### General ###
1. [ ] Documentation:
	- [ ] General writings;
	- [ ] Simple models description;
1. [ ] Automantion Testing;
1. [ ] Sitemap file and navigation;

1. [ ] Local IIS Deployment;
1. [ ] Rewrite and Redirects;
1. [ ] AdminPanel.

### Identity
1. [ ] Separate in project .Identity


### Continuous Integration and Deployment
1. [ ] Start with Unit Testing
2. [ ] Jenkins integration
3. [ ] Upload in the Cloud




