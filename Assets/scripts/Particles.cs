using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Particles", menuName = "ScriptableObjects/Particles", order = 2)]
public class Particles : ScriptableObject
{
    public ParticleSystem explosion;
    public ParticleSystem floating;
    public ParticleSystem destroy;
}
