using System.Threading.Tasks;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    private Task updateCourotine;
    private Spell _activeSpell;
    private bool _isActive;

    public void Activate()
    {
        _isActive = true;
        _activeSpell.Activate(this);
        _activeSpell.OnDeactivate += () => _isActive = false;
        UpdateSpell();
    }

    private async void UpdateSpell()
    {
        while (Application.isPlaying && _isActive)
        {
            _activeSpell.Update();
        }
    }
}
