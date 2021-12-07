using UnityEngine;

public class DefaultSpell : Spell
{
    private readonly Color32 _spellColor = Color.gray;
    private Vector3 _clickedPos;

    public override byte SpellRecipe { get; }
    public override string SpellMessage()
    {
       return "Cast Generic Spell";
    }

    public override void Initiate(SpellObject spellObject)
    {
        base.Initiate(spellObject);
        _spellObject.GetComponent<MeshRenderer>().material.color = _spellColor;
        spellObject.StartCoroutine(Update());
    }
}
