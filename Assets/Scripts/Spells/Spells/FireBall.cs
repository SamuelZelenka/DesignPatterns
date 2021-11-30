using System.Collections;
using UnityEngine;

public class FireBall : Spell
{
    private const byte FIREBALL_RECIPE = (byte)(SpellElements.Fire);
    public override byte SpellRecipe => FIREBALL_RECIPE;
    public override string SpellMessage()
    {
        return "Cast Fireball";
    }

    public override void Activate(SpellObject spellObject)
    {
        throw new System.NotImplementedException();
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