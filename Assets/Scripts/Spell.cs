using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    public abstract byte SpellRecipe { get; }
    private SpellModule[] _spellModules;
    
}

public class FireBall : Spell
{
    private const byte FIREBALL_RECIPE = (byte)(SpellElements.Fire | SpellElements.Wind);
    public override byte SpellRecipe => FIREBALL_RECIPE;

    public FireBall()
    {

    }
}