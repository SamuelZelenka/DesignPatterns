using System.Collections;
using UnityEngine;

public class FireBall : DefaultSpell
{
    private const byte FIREBALL_RECIPE = (byte)(SpellElements.Fire);
    private readonly Color32 _spellColor = Color.red;

    public override byte SpellRecipe => FIREBALL_RECIPE;
    public override string SpellMessage()
    {
        return "Cast Fireball";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
    }

}