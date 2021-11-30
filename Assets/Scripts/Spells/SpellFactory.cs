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

public class SpellFactory : MonoBehaviour
{
    [SerializeField] private SpellObject spellObjectPrefab;
    private static SpellFactory _instance;
   
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

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
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

    private static Spell GetSpell(SpellElements spell)
    {
        return Spells.ContainsKey((byte) spell) ? Spells[(byte) spell] : new GenericSpell();
    }

    public static SpellObject CreateSpellObject(SpellElements spell)
    {
        SpellObject newSpellObject = Instantiate(_instance.spellObjectPrefab);
        newSpellObject.SetActiveSpell(GetSpell(spell));
        return newSpellObject;
    }
}
