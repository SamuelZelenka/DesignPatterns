using System.Threading.Tasks;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    private Spell _activeSpell;
    private bool _isActive;

    public void SetActiveSpell(Spell spell)
    {
        _activeSpell = spell;
    }
    private void Initiate(Vector3 position, Spell spell)
    {
        transform.position = position;
        _activeSpell = spell;
        Activate();
    }
    public void Activate()
    {
        _isActive = true;
        _activeSpell.Activate(this);
        _activeSpell.OnDeactivate += () => _isActive = false;
        print(_activeSpell.SpellMessage());
        UpdateSpell();
    }

    private async void UpdateSpell()
    {
        while (Application.isPlaying && _isActive)
        {
            _activeSpell.Update();
        }
        print("Ended");
    }
}
