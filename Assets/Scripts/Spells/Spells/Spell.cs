using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public delegate void SpellStateHandler();
    public SpellStateHandler OnDeactivate;
    public abstract byte SpellRecipe { get; }
    public abstract string SpellMessage();

    public abstract void Activate(SpellObject spellObject);
    public abstract void Update();
    public abstract void DeActivate();
}

