using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpellAction : InputAction
{
    private ElementSelection _elementSelection;
    private Func<bool> _onClicked;
    protected override bool IsPressed => _onClicked.Invoke();

    public CastSpellAction(ElementSelection elementSelection, Func<bool> onClicked)
    {
        _elementSelection = elementSelection;
        _onClicked = onClicked;
}

    protected override void Execute()
    {
        SpellElements selectedElements = (SpellElements)_elementSelection.SelectedElements;
        SpellObject spellObject = SpellFactory.CreateSpellObject(selectedElements);
        spellObject.Activate();
    }
}
