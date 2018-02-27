# PrisonBreak
Information about the PrisonBreak project for the 3rd years at SintLucas

## Module 1 (2 weeks / one week instruction, one week assignment)
### OOP - How unity works under the hood.

#### Learning goals:
Objects / classes / inheritance / Polimorphism

#### Assignment:
Development of a simple game based on a data model built in class.
Prison break, Get items to escape a building.

#### Description & requirements:
* Create a abstract class Item with a name and a weight
* Create two types of items:
  * AccessItem: keeps an extra int that has the id of the door it opens.
  * BonusItem: keeps the amount of points you get for this item.
* Create a MonoBehaviour derived class Inventory that keeps a List<Item> and caches the total weight.
* The Inventory should only allow to add items if the total weight does not pass the MaximumWeight.
* Create a level where you need to find a key and optionally some hidden objects to get points.
* Do not create a way to open the last door. That's for the next assignment.

## Module 2  (2 weeks / one week instruction, one week assignment)
### Data models, working with data. (reiteration of Classes that do not inherit from MonoBehaviour) and Collections

#### Learning goals:
Arrays, Lists, Dictionaries, Generic classes
Writing/reading files/data to and from online sources.
Using the [SimpleJSON library](http://wiki.unity3d.com/index.php/SimpleJSON) for C#.

#### Assignment:
Create a data visualization within the prison. Use the data as a code for a door.

* Create a room on the prison where there is a projector displaying data from:
  * http://api.icndb.com/jokes/random?limitTo=[nerdy]
  *  ?? other simple ones without oAuth??
