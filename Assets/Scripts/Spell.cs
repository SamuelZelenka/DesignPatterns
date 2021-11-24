using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    private SpellModule[] _spellModules;

    public void SetSpellModules(SpellModule[] modules)
    {
        _spellModules = modules;
    }
}