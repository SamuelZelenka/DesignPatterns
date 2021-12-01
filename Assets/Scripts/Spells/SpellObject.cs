using UnityEngine;

public class SpellObject : MonoBehaviour, IPoolable
{
    private Spell _activeSpell;

    public void Initiate(Spell spell)
    {
        _activeSpell = spell;
        _activeSpell.Initiate(this);
        
        print(_activeSpell.SpellMessage());
        
        StartCoroutine(_activeSpell.Update());
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
