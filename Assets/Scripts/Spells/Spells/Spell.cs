using System.Collections;
using UnityEngine;

public abstract class Spell
{
    public delegate void SpellStateHandler();

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

    public virtual IEnumerator Update()
    {
        while (_castTime + _duration > Time.time)
        {
            Transform spellTransform = _spellObject.transform;
            spellTransform.position += spellTransform.forward * _speed * Time.deltaTime;
            yield return null;
        }
        Disband();
    }

    protected virtual void Disband()
    {
        SpellPool.ReleaseSpellObject(_spellObject);
    }
}
