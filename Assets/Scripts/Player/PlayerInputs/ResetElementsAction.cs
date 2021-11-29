using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetElementsAction : InputAction
{
    private ElementSelection _selectionUI;
    public ResetElementsAction(ElementSelection selectionUI)
    {
        _selectionUI = selectionUI;
    }
    protected override bool IsPressed => Input.GetKeyDown(KeyCode.Space);

    protected override void Execute()
    {
        _selectionUI.DeselectAll();
    }
}
