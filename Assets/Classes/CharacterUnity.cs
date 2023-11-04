using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using hrdina_a_drak.Postavy;
using System;

[Serializable]
public class CharacterUnity : Postava, ISerializationCallbackReceiver
{
    [SerializeField]
    int health = 100;

    [SerializeField]
    int maxDamage = 10;

    [SerializeField]
    int maxDefence = 5;

    public CharacterUnity(string jmeno, int zdravi, int maxPoskozeni, int maxObrana)
        : base(jmeno, zdravi, maxPoskozeni, maxObrana)
    {
    }

    public CharacterUnity() : base(default, default, default, default)
    {
    }

    public void OnBeforeSerialize()
    {
        health = Zdravi;
        maxDamage = MaxPoskozeni;
        maxDefence = MaxObrana;
    }

    public void OnAfterDeserialize()
    {
        Zdravi = health;
        MaxZdravi = health;
        MaxPoskozeni = maxDamage;
        MaxObrana = maxDefence;
    }
}
