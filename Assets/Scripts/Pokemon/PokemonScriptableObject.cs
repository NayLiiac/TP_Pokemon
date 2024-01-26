using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CreatePokemon", order = 1)]
public class PokemonScriptableObject : ScriptableObject
{
    [Header("Stats")]
    public float Pv;
    public int Atk;
    public uint Def;
    public uint Vit;
    public string Name;

    [Header("Weakness & Resistances")]
    public PokemonType PokemonType;
    public List<PokemonType> WeaknessTypes;
    public List<PokemonType> ResistanceTypes;
    public List<PokemonType> ImmunityTypes;

    [Header("Pokemon State")]
    public bool isSentOut;
    public bool isKnockOut;

    [Header("Abilities")]
    public PokemonAbilitiesScriptableObject[] Abilities = new PokemonAbilitiesScriptableObject[4];
}
public enum PokemonType
{
    Normal,
    Grass,
    Fire,
    Water,
    Electrik,
    Ground,
    Rock,
    Steel,
    Fighting,
    Flying,
    Ice,
    Dragon,
    Fairy,
    Dark,
    Psy,
    Spectre,
    Poison,
    Bug,
}
