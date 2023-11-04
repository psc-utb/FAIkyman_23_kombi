using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{

    [SerializeField]
    CharacterUnity character;

    HealthSystem _healthSystem;
    // Start is called before the first frame update
    void Awake()
    {
        _healthSystem = new HealthSystem(character.MaxZdravi);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("");
    }

    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }
}
