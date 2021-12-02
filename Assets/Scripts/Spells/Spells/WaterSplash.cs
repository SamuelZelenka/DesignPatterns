using UnityEngine;

public class WaterSplash : Spell
{
    private const byte WATERSPLASH_RECIPE = (byte)(SpellElements.Water);
    private readonly Color32 _spellColor = new Color32(0x00, 0xE4, 0xFF, 0xFF);

    public override byte SpellRecipe => WATERSPLASH_RECIPE;
    public override string SpellMessage()
    {
        return "Cast WaterSplash";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
    }

}
