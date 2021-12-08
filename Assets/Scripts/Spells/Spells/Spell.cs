using System.Collections;
using UnityEngine;

public abstract class Spell
{
    protected float _castTime;
    protected float _duration = 5;
    protected float _speed = 15;
    protected SpellObject _spellObject;

    public abstract byte SpellRecipe { get; }
    public abstract string SpellMessage();

    public virtual void Initiate(SpellObject spellObject)
    {
        spellObject.name = ToString();
        _spellObject = spellObject;
        _castTime = Time.time;
    }

    public IEnumerator Update()
    {
        while (_castTime + _duration > Time.time)
        {
            ExecuteSpell();
            yield return null;
        }
        Disband();
    }

    protected virtual void ExecuteSpell() 
    {
        Transform spellTransform = _spellObject.transform;
        spellTransform.position += spellTransform.forward * _speed * Time.deltaTime;
    }
    protected virtual void Disband()
    {
        SpellPool.ReleaseSpellObject(_spellObject);
    }
}
