Singleton:

SpellFactory.cs:
	Uses a singleton to allow a gameobject in the scene to hold a reference to a spellObjectPrefab.
	could(should)

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

	

