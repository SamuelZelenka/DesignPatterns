using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Flags]
public enum SpellElements
{
    Water = 0b0001,
    Earth = 0b0010,
    Fire = 0b0100,
    Air = 0b1000
}

public class SpellFactory : MonoBehaviour
{
    private readonly Dictionary<byte, Spell> _spells = new Dictionary<byte, Spell>();
    private bool IsInitialized => _spells.Count > 0;

    private Dictionary<byte, Spell> Spells
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

    public void InitializeFactory()
    {
        Assembly typeAssembly = Assembly.GetAssembly(typeof(Spell));
        IEnumerable spellTypes = typeAssembly.GetTypes().Where(IsDerivedType<Spell>);

        foreach (Type type in spellTypes)
        {
            Spell spell = Activator.CreateInstance(type) as Spell;
            _spells.Add(spell.SpellRecipe, spell);
        }
    }

    private bool IsDerivedType<T>(Type type)
    {
        return type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T));
    }

    public Spell GetSpell(SpellElements spell)
    {
        return Spells.ContainsKey((byte) spell) ? Spells[(byte) spell] : new GenericSpell();
    }

    //public static GameObject CreateSpellObject()
    //{

    //}
}
