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

public static class SpellFactory
{
    private static readonly Dictionary<byte, Spell> _spells = new Dictionary<byte, Spell>();
    private static bool IsInitialized => _spells.Count > 0;

    private static Dictionary<byte, Spell> Spells
    {
        get
        {
            if (!IsInitialized)
            {
                InitializeFactory(); 
            }
            return _spells;
        }
    }

    public static void InitializeFactory()
    {
        Assembly typeAssembly = Assembly.GetAssembly(typeof(Spell));
        IEnumerable spellTypes = typeAssembly.GetTypes().Where(IsDerivedType<Spell>);

        foreach (Type type in spellTypes)
        {
            Spell spell = Activator.CreateInstance(type) as Spell;
            _spells.Add(spell.SpellRecipe, spell);
        }
    }

    private static bool IsDerivedType<T>(Type type)
    {
        return type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T));
    }

    
    public static Spell GetSpell(SpellElements spell)
    {
        return Spells.ContainsKey((byte) spell) ? Spells[(byte) spell] : new GenericSpell(); 
    }
}
