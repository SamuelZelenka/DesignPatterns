using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Flags]
public enum SpellElements
{
    Earth = 1 << 0,
    Wind = 1 << 1,
    Fire = 1 << 2,
    Water = 1 << 3
}

public class SpellFactory
{
    private static Dictionary<int, Spell> spells;
    private static bool isInitialized => spells != null;

    public static void InitializeFactory()
    {
        
    }

    public static Spell GetSpell(byte spell)
    {
        return spells[spell];
    }
}
