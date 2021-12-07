using UnityEngine;

public class SpellObject : MonoBehaviour, IPoolable
{
    private Spell _activeSpell;
    
    public void Initiate(Spell spell)
    {
        _activeSpell = spell;
        if (_activeSpell != null)
        {
            _activeSpell.Initiate(this);

            print(_activeSpell.SpellMessage());
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
