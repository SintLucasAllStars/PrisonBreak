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
