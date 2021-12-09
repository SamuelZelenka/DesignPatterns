# DesignPatterns
Samuel Zelenka af Rolén

A slimmed down version of the magicka spell system where you combine elements to create spells. 

Elements are selected using the number keys 1-4 and can be reset with space.
To cast a spell with the current configuration of elements use left-click

to move the capsule(player) around right click in the scene

The goal was to be able to implement a system that could easily make an object from a given configuration that is easily expandable. 

-------------------

## Singleton:

	SpellPool.cs
The object pool for spells is a singleton as only one instance of the pool is required to acquire spell objects and also neatly keep them under the same transform in the scene hierarchy.
This also allow the easy access to the prefab variable which can be assigned in the inspector.    

-------------------

## Factory Pattern:

	SpellFactory.cs:
The spellfactory takes in an enum called SpellElements that is using the [Flags] attribute representing the selected elements to determine what elements are selected. 
With the selected elements There's a pre-defined dictionary of spells and their recipes represented as a SpellElements value that is assigned to a SpellObject. 
then the SpellObject is returned as an instance from the object pool.

-------------------

## Strategy Pattern:

	Spell.cs / EarthThrow.cs / FireBall.cs / DefaultSpell.cs / WaterSplash.cs / WindGust.cs:

Using the strategy pattern for spells allows each spell to have unque behaviours by being able to override functionality in an abstract clas.
Spell has an initiate method which is called upon creaton that is overriden to create unique behaviours for each ability.


-------------------

## Command Pattern:

	InputAction.cs / CastSpellAction.cs / MoveToPointAction.cs / ResetElementAction.cs / SelectElementAction.cs / PlayerInput.cs:
InputAction is an abstract class that has an Execute() method that is called if the input is being pressed.

PlayerInput.cs handles all initialization of the wanted inputs as well as it checks the input on Update() by iterating through all the InputActions that has been initialized.

-------------------


## Object pool

	GameObjectPool.cs / ObjectPool.cs / IPoolable.cs

The object pool is a generic object pool written to be able to use any class.

GameObjectPool.cs is a derived class from ObjectPool to allow the usage of the instantiate() / Destroy() methods to properly handle Unity GameObjects.

The object pool has a capacity to allow the pool to max out on stored inactive objects to free up on memory after an eventual spike in the number of game objects.
There's also prewarm option for the object pool to create the capacity number of objects at start.
	
