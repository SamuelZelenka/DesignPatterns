using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellEffect
{
    public abstract void AssignParticles(ref ParticleSystem particleSystem);
    public abstract void GetSpellModule();
}
