Singleton:

SpellPool.cs
The object pool for spells is a singleton as only one instance of the pool is required to acquire spell objects and also neatly keep them under the same transform in the scene hierarchy.
This also allow the easy access to the prefab variable which can be assigned in the inspector.    

-------------------

Factory Pattern:

SpellFactory.cs:
	Creates a SpellObject from specific arguments.

-------------------

Strategy Pattern:

Spell.cs / EarthThrow.cs / FireBall.cs / DefaultSpell.cs / WaterSplash.cs / WindGust.cs:
	Spell contains a set of abstract and virtual properties and methods that are overriden in child classes
	to allow flexbility in the behaviour of each derived class.

(Also see PlayerInput.cs for initialization of the inputs)

-------------------

Command Pattern:

InputAction.cs / CastSpellAction.cs / MoveToPointAction.cs / ResetElementAction.cs / SelectElementAction.cs:
	InputAction encapsulate the needed methods to be able to perform certain Actions at runtime.
	in this case all calls happen within PlayerInput.cs Update method as the command is executed upon input in real time. 

-------------------


Object pool

GameObjectPool.cs / ObjectPool.cs / IPoolable.cs

The object pool is a generic object pool written to be able to use any kind of class.
To be able to create/destroy gameobjects in unity properly I've had to make a derived class called GameObjectPool.cs to utilize the instantiate() / Destroy() methods

I've introduced a capacity to allow the pool to max out on stored inactive objects to free up on memory after an eventual spike in the number of game objects.
I also allowed the option to prewarm the object pool if the game for some reason would halt mid game due to instantiation of too many new objects.
	

