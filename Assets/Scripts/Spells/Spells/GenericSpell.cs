using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenericSpell : Spell
{

    private Vector3 _clickedPos;
    
    public override byte SpellRecipe { get; }
    public override string SpellMessage()
    {
       return "Cast Generic Spell";
    }

    public override void Activate(SpellObject spellObject)
    {
        _clickedPos = ;
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void DeActivate()
    {
        throw new System.NotImplementedException();
    }
}
