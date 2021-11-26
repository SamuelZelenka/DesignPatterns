using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public abstract byte SpellRecipe { get; }
    public abstract string SpellMessage();
}

