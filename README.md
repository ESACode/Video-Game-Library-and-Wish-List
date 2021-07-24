# Video-Game-Library-and-Wish-

This app is a combination library and wish list app for video games.  The user can experiment with a sample library populated with content, or create any number of their own.  They can also use a recommendation feature that will suggest games to add to a wish list of their own based on the type of games they say they are interested in.  Any user created libraries can be both saved and edited.

5 Code Louisville Project requirements this webpage will satisfy are:

1.   Implement a master loop

The master loop begins on line 172 of the Program.CS file.

2. Create a class which inherits properties from its parent.

The WishListGame.CS class inherits several properties from the Game.CS class.

3. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program

A sample list of Games is created on line 16 of the Program.CS file.  It's values are used to populate a new instance of the Library class and that instance serves as a sample library that a user can work with.

4. Read data from an external file, such as text, JSON, CSV, etc and use that data in your application

RecommendGames.json is read into Program.CS on line 36, and it's contents are used to perform the game recommendation feature of the app.

5. Use a LINQ query to retrieve information from a data structure (such as a list or array) or file

LINQ queries are used in a few places throughout the app, for instance on line 20 of the WishList.CS file.