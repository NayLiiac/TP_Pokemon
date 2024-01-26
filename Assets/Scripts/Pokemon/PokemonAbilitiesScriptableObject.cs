using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreatePokemonAbilities", order = 2)]
public class PokemonAbilitiesScriptableObject : ScriptableObject
{
    public string abilityName;
    public float AtkBasePower;
    public PokemonType abilityType;
    public uint PP;

    /// <summary>
    /// Si oui ou non cette capacité sert à se soigner
    /// </summary>
    public bool HealAbility;
    public uint HealBasePower;
}
