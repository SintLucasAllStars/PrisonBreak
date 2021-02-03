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
Create a visualization for external data within the prison. Use the data as a way to open the door.

For example:
* Create a room on the prison where there is a projector displaying data from an API for example:
  * http://api.icndb.com/jokes/random?limitTo=[nerdy] => Chuck Norris Jokes.
  * [Any API with 500+ public API's of all types] (https://any-api.com/)
  * [Collective list of public API's for many things](https://github.com/toddmotto/public-apis)
  * [Awesome comic XKCD API to get all the comics](https://xkcd.com/json.html)

## Module 3  (2 weeks / one week instruction, one week assignment)
### Generative algorithms. Seed controlled generation. Generating terrains.

#### Learning goals:
Working with random seeds, generative techniques, working with terrains.

#### Assignment:
After getting out of jail escape the island. So generate an island.
* Generate the terrain
* Create a new inventory item RaftPart
* Spread RaftParts through the terrain (Randomly/generatively gives extra points but could also be manually).
* The player needs to collect all the raft parts and build a raft to escape the island.

## Module 4 (2 weeks assignment)

Polishing and finishing - These two weeks are to go throught the whole project and finish up all the details and make it into a fully playable, finished game.

## Deadline 2021
TBA

## Delivery
The delivery of this project consists of only a **github link to your repository**. So make sure Git is working for you from the start and be careful with commiting huge files.

Check out Git LFS for big files. 

Clean up your imported assets if you do not use them.
