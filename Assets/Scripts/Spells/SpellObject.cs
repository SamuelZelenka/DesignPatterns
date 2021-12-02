using UnityEngine;

public class SpellObject : MonoBehaviour, IPoolable
{
    private Spell _activeSpell;

    public void SetActiveSpell(Spell spell)
    {
        _activeSpell = spell;
    }
    public void Initiate()
    {
        if (_activeSpell != null)
        {
            _activeSpell.Initiate(this);

            print(_activeSpell.SpellMessage());

            StartCoroutine(_activeSpell.Update());
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
