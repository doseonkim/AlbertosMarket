Group:

Alberto Garcia Salas (beto1994@uw.edu)

Doseon Kim (doseon@uw.edu)


Groupwork: 
We worked on initializing the project together in class and created the models for the Market and Comments. 
Created the MarketController using the Entity Framework and setup the initial database using MarketContext as a connection string.

Alberto:
Implemented the Basic CRUD Functionality that allows user to create a new Market post and delete them. 
Basics of sorting and filtering added to the Market index to allow more customization for the users.
Added the paging system that shows only lists three posts per page.
Implemented the resilency and command interception.

Doseon:
Adjusted the details page to add the comments into individual Market posts that had comments within them created by the MarketInitializer.
Added more sorting features that allowed sort by title, price and the trading options available on the platform.
Implemented the Trading Option statistics inside the about page that shows the number of total posts within their categor.
Changed the database to migration that uses the seed method inside configuration to create it's new database.
Created the basic seed method to allow testing upon "update-database" is ran within the Package Manager Console.

The database transaction is clear when adding/creating/editing Market posts and save within the MarketDB2 databse.
We got through the 5 tutorials using our own model ideas that reflect our future project. We use migrations within this project as of the latest update and have made a change to one of the models since we are not using the Contoso University example. The project runs from the seed method upon "update-database".
