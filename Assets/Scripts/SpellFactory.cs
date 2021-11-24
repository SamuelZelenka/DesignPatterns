using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class SpellFactory
{
    private static HashSet<Type> spellModules;
    private static bool isInitialized => spellModules != null;

    public static void InitializeFactory()
    {
        if (isInitialized)
        {
            return;
        }

        Type[] spellModuleTypes = Assembly.GetAssembly(typeof(SpellModule)).GetTypes();
        IEnumerable applicableSpellModules = spellModuleTypes.Where(IsModuleApplicable);
        
        foreach (Type module in applicableSpellModules)
        {
            spellModules.Add(module);
        }
    }

    private static bool IsModuleApplicable(Type module)
    {
        return module.IsClass && !module.IsAbstract && module.IsSubclassOf(typeof(SpellModule));
    }
    
    public static Spell GetSpell<SpellType>() where SpellType : Spell
    {
        
    }
}
