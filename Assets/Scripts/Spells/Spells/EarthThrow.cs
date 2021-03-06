using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthThrow : DefaultSpell
{
    private const SpellElements EARTHTHROW_RECIPE = SpellElements.Earth;
    private readonly Color32 _spellColor = new Color32(0x4f, 0x38, 0x15, 0xFF);

    public override SpellElements SpellRecipe => EARTHTHROW_RECIPE;
    public override string SpellMessage()
    {
        return "Cast EarthThrow";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
    }

}
