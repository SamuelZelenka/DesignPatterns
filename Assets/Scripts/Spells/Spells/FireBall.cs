using System.Collections;
using UnityEngine;

public class FireBall : Spell
{
    private const byte FIREBALL_RECIPE = (byte)(SpellElements.Fire);
    private float _castTime;
    private float _duration = 40;
    private SpellObject _spellObject;
    private Vector3 _travelDirection;

    public override byte SpellRecipe => FIREBALL_RECIPE;
    public override string SpellMessage()
    {
        return "Cast Fireball";
    }

    public override void Activate(SpellObject spellObject)
    {
        Vector3 spellPosition = spellObject.transform.position;
        _spellObject = spellObject;
        _travelDirection = spellPosition - PlayerInput.MouseClickPos();
        _castTime = Time.time;
        spellObject.transform.rotation = Quaternion.LookRotation(_travelDirection, Vector3.up);
    }

    public override void Update()
    {
        _spellObject.transform.position += _travelDirection * Time.deltaTime;
        if (_castTime + _duration > Time.deltaTime)
        {
            DeActivate();
        }
    }

    public override void DeActivate()
    {
        OnDeactivate?.Invoke();
    }
}