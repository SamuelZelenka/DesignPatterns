using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpell : Spell
{
    public override byte SpellRecipe { get; }
    public override string SpellMessage()
    {
       return "Cast Generic Spell";
    }
}
