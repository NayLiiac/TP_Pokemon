using System;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public PokemonScriptableObject PokemonScriptableObject;

    [field : SerializeField] public string PokemonName { get; private set; }

    [Header("Stats")]
    public float PokemonMaxPv;
    public float PokemonPv;
    public event Action<float> PokemonPvChanged;

    [field : SerializeField] public float PokemonAtk { get; private set; }
    [SerializeField] private uint _pokemonDef;
    [SerializeField] private uint _pokemonVit;

    [Header("Abilities")]
    public PokemonAbilitiesScriptableObject[] PokemonAbilitiesTab = new PokemonAbilitiesScriptableObject[4];

    public PokemonType PokemonType { get; private set; }
    public List<PokemonType> PokemonWeaknessesTypes { get; private set; }
    public List<PokemonType> PokemonResistancesTypes { get; private set; }
    public List<PokemonType> PokemonImmunityTypes { get; private set; }

    [Header("Pokemon State")]
    public bool IsSentOut;
    public bool IsKnockOut;

    public void InitPokemon() {
        if (PokemonAbilitiesTab == null || PokemonAbilitiesTab.Length == 0)
        {
            Debug.LogError("Le Pokemon n'a aucune capacité");
        }
        PokemonName = PokemonScriptableObject.Name;

        PokemonMaxPv = PokemonScriptableObject.Pv;
        PokemonPv = PokemonScriptableObject.Pv;
        PokemonAtk = PokemonScriptableObject.Atk;
        _pokemonDef = PokemonScriptableObject.Def;
        _pokemonVit = PokemonScriptableObject.Vit;
            
        PokemonType = PokemonScriptableObject.PokemonType;

        PokemonWeaknessesTypes = PokemonScriptableObject.WeaknessTypes;
        PokemonResistancesTypes = PokemonScriptableObject.ResistanceTypes;
        PokemonImmunityTypes = PokemonScriptableObject.ImmunityTypes;

        for(int i = 0; i < PokemonAbilitiesTab.Length; i++) {
            PokemonAbilitiesTab[i] = PokemonScriptableObject.Abilities[i];
        }
    }

    public void DamageTaken(float damageTaken) {
        
        PokemonPv -= damageTaken;
        Debug.Log($"{PokemonName} Pv Restants : {PokemonPv}");
        PokemonPvChanged?.Invoke(PokemonPv);
    }

    public bool IsPokemonKnockOut(PokemonMain pokemon) {
        if(pokemon.Pkmn.PokemonPv <= 0) {
            return true;
        }
        else {
            return false;
        }
    }
}
