using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpellTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spell spell = SpellFactory.GetSpell(SpellElements.Fire);
            Debug.Log(spell.SpellMessage());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Spell spell = SpellFactory.GetSpell(SpellElements.Water);
            Debug.Log(spell.SpellMessage());
        }
    }
}
