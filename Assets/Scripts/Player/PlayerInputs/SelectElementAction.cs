using UnityEngine;

public class SelectElementAction : InputAction
{

    private int _elementID;
    private ElementSelection _selectionUI;
    private KeyCode _keyCode;

    public SelectElementAction(int elementID, KeyCode keycode, ElementSelection selectionUI)
    {
        _selectionUI = selectionUI;
        _elementID = elementID;

        _keyCode = keycode;
    }

    protected override bool IsPressed => Input.GetKeyDown(_keyCode);

    protected override void Execute()
    {
        _selectionUI.SetElementActiveState(_elementID, true);
    }

    public override void RebindKey(KeyCode keycode)
    {
        _keyCode = keycode;
    }
}
