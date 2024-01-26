using UnityEngine;

public class Pierre : Humains, IHumans
{
    public HumansType HumanType;
    public override HumansType GetHumansType() {
        return HumanType;
    }
    public override void Cook(PokemonMain pokemon1, PokemonMain pokemon2, int healNumber) {
        if(!pokemon1.Pkmn.IsKnockOut || !pokemon2.Pkmn.IsKnockOut) {
            pokemon1.Pkmn.PokemonPv += healNumber;
            pokemon2.Pkmn.PokemonPv += healNumber;

            if (pokemon1.Pkmn.PokemonPv > pokemon1.Pkmn.PokemonMaxPv) {
                pokemon1.Pkmn.PokemonPv = pokemon1.Pkmn.PokemonMaxPv;
            }
            else if (pokemon2.Pkmn.PokemonPv > pokemon2.Pkmn.PokemonMaxPv) {
                pokemon1.Pkmn.PokemonPv = pokemon1.Pkmn.PokemonMaxPv;
            }
            Debug.Log($"{pokemon1.Pkmn.PokemonName} a récupéré {healNumber}, il est à présent à {pokemon1.Pkmn.PokemonPv}/{pokemon1.Pkmn.PokemonMaxPv}");
            Debug.Log($"{pokemon2.Pkmn.PokemonName} a récupéré {healNumber}, il est à présent à {pokemon2.Pkmn.PokemonPv}/{pokemon2.Pkmn.PokemonMaxPv}");
    
        }
        else {
            Debug.LogError("Vous essayez de soigner un pokémon KO, veuillez choisir un pokémon vivant");
        }
    }

    public override void GetHealing(PokemonMain pokemon, int healNumber) {
        if (!pokemon.Pkmn.IsKnockOut) {
            pokemon.Pkmn.PokemonPv += healNumber;

            if (pokemon.Pkmn.PokemonPv > pokemon.Pkmn.PokemonMaxPv) {
                pokemon.Pkmn.PokemonPv = pokemon.Pkmn.PokemonMaxPv;
            }

            Debug.Log($"{pokemon.Pkmn.PokemonName} a récupéré {healNumber}, il est à présent à {pokemon.Pkmn.PokemonPv}/{pokemon.Pkmn.PokemonMaxPv}");
        }
        else {
            Debug.LogError("Vous essayez de soigner un pokémon KO, veuillez choisir un pokémon vivant");
        }
    }
}
