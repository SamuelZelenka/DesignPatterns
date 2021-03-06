using UnityEngine;

public class WindGust : DefaultSpell
{
    private const SpellElements WIND_GUST_RECIPE = SpellElements.Air;
    private readonly Color32 _spellColor = new Color32(0xff, 0xff, 0xff, 0xFF);

    public override SpellElements SpellRecipe => WIND_GUST_RECIPE;
    public override string SpellMessage()
    {
        return "Cast WindGust";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
    }
}
