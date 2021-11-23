using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCreator
{
    public ParticleSystem CreateSpell()
    {
        GameObject particleObject = new GameObject();
        ;
        ParticleSystem particleSystem = particleObject.AddComponent<ParticleSystem>();


        return particleSystem;
    }
}
