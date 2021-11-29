using UnityEngine;
public abstract class InputAction
{
    protected abstract bool IsPressed { get; }
    public virtual void CheckIfPressed()
    {
        if (IsPressed)
        {
            Execute();
        }
    }
    protected abstract void Execute();
    public virtual void RebindKey(KeyCode keycode) { }
}
