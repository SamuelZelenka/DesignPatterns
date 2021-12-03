using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Flags]
public enum SpellElements
{
    Water = 1 << 0,
    Earth = 1 << 1,
    Fire = 1 << 2,
    Air = 1 << 3
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
    
    private static void InitializeFactory()
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

    private static Spell GetSpell(SpellElements spell)
    {
        Spell requestedSpell = null;
            
        if (Spells.ContainsKey((byte) spell))
        {
            Type spellType = Spells[(byte) spell].GetType();
            requestedSpell = Activator.CreateInstance(spellType) as Spell;
        }
        
        return requestedSpell ?? new DefaultSpell();
    }

    public static SpellObject CreateSpellObject(SpellElements elements, Vector3 position, Quaternion rotation)
    {
        Spell newSpell = GetSpell(elements);

        SpellObject newSpellObject = SpellPool.AcquireSpellObject();
        
        Transform newSpellTransform = newSpellObject.transform;
        newSpellTransform.position = position;
        newSpellTransform.rotation = rotation;
        
        newSpellObject.Initiate();
        
        return newSpellObject;
    }
}
