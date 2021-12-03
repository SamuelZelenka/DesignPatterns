using System;
using UnityEngine;

public class CastSpellAction : InputAction
{
    private ElementSelection _elementSelection;
    private Func<bool> _onClicked;
    private Transform playerTransform;
    protected override bool IsPressed => _onClicked.Invoke();

    public CastSpellAction(ElementSelection elementSelection, Func<bool> onClicked, Transform player)
    {
        _elementSelection = elementSelection;
        _onClicked = onClicked;
        playerTransform = player.transform;
    }

    protected override void Execute()
    {
        SpellElements selectedElements = (SpellElements)_elementSelection.SelectedElements;
        Vector3 spellPosition = playerTransform.position;
        Vector3 spellDirection =  PlayerInput.MouseClickPos() - spellPosition;
        spellDirection = new Vector3(spellDirection.x, 0, spellDirection.z);
        Quaternion spellRotation = Quaternion.LookRotation(spellDirection, Vector3.up);
        
        SpellFactory.CreateSpellObject(selectedElements, spellPosition, spellRotation);
    }
}
