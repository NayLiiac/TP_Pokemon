using System.Collections.Generic;
using UnityEngine;
public class Ondine : Humains, IHumans
{
    public HumansType HumanType = HumansType.Trainer;
    public override HumansType GetHumansType() {
        return HumanType;
    }

    [field: SerializeField] public override PokemonMain FirstPokemon { get; set; }
    [field: SerializeField] public override PokemonMain SecondPokemon { get; set; }
    public override bool TrainerDefeated { get; set; }

    private void Start() {
        TrainerDefeated = false;
    }
    public override void GetPokemon1(PokemonMain pokemon) {
        FirstPokemon = pokemon;
        Debug.Log($"Ondine obtient {pokemon.Pkmn.PokemonName}");
        FirstPokemon.Pkmn.PokemonPvChanged += Notify;
    }

    public override void GetPokemon2(PokemonMain pokemon) {
        SecondPokemon = pokemon;
        Debug.Log($"Ondine obtient {pokemon.Pkmn.PokemonName}");
    }
    public override void SentOutPokemon(PokemonMain pokemon) {
        pokemon.Pkmn.IsSentOut = true;
        Debug.Log($"Ondine envoie {pokemon.Pkmn.PokemonName} au combat o7");
        SecondPokemon.Pkmn.PokemonPvChanged += Notify;
    }

    public override void RetrievePokemon(PokemonMain pokemon) {
        if (pokemon.Pkmn.IsPokemonKnockOut(pokemon) && !SecondPokemon.Pkmn.IsKnockOut) {
            pokemon.Pkmn.IsKnockOut = true;
            pokemon.Pkmn.IsSentOut = false;
            Debug.Log($"Ondine retire {pokemon.Pkmn.PokemonName} du combat, raison : Pokemon Ko");
            SentOutPokemon(SecondPokemon);
        }
        else {
            DefeatedTrainer();
        }
    }


    public override void DefeatedTrainer() {
        TrainerDefeated = true;
        Debug.Log("Ondine est vaincue !");
    }

    public void Notify(float damageTaken) {
        if (FirstPokemon.Pkmn.PokemonPv <= 0 && !FirstPokemon.Pkmn.IsKnockOut) {
            RetrievePokemon(FirstPokemon);
        }
        else if (SecondPokemon.Pkmn.PokemonPv <= 0 && FirstPokemon.Pkmn.IsKnockOut) {
            RetrievePokemon(SecondPokemon);
        }
    }
}
