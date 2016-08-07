#Readme
==

##About
This is a game shop application where the user can add new publishers, who will be displayed in a sorted list. When viewing a publisher, the application also shows all of the games which are available from that publisher.

This is similar for games, where again the user is able to add new games, and associate them with a publisher. When viewing a game, the user is able to see any add-ons that are available, and if there are any accessories that can be used with that game. Games are also able to have a picture added to it.

The above is the same for both the addons and accessories, expect showing the game, and the games publisher that is associated with it. Both publishers and games offer the ability to search their respective list for any column/row value.

Data validation on the front-end done using AngularJS. All items have add new, edit and delete functionality to them. The login/register functionality is being implemented.

This project is created using C# to offer a web API, and utilises AngularJS for its front end. This is using code-first methodologies with Entity Framework. Using AngularJS allows this to be a single page application where the C# back-end API returns JSON which is then used by AngularJS to dynamically build the pages.

This uses the MVVM architecture, and is also backed using LINQ.

##Known Issues:
> not allowing login CORS, and login not currently fully implemented
> Foreign key relationship is not selected automatically when editing an item.
