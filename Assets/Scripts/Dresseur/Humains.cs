using System.Collections.Generic;
using UnityEngine;

public abstract class Humains : MonoBehaviour, IHumans
{
    public abstract HumansType GetHumansType();

    public virtual PokemonMain FirstPokemon { get; set; }
    public virtual PokemonMain SecondPokemon { get; set; }
    public virtual bool TrainerDefeated { get; set; }

    /// <summary>
    /// Permet de placer un pokémon dans son équipe en première position lorsque la méthode est appelée.
    /// </summary>
    /// <param name="pokemon"></param>
    public virtual void GetPokemon1(PokemonMain pokemon) {
    }
    /// <summary>
    /// Permet de placer un pokémon dans son équipe en seconde position lorsque la méthode est appelée.
    /// </summary>
    /// <param name="pokemon"></param>
    public virtual void GetPokemon2(PokemonMain pokemon) {
    }
    /// <summary>
    /// Permet d'envoyer son pokemon au combat.
    /// </summary>
    /// <param name="pokemon"></param>
    public virtual void SentOutPokemon(PokemonMain pokemon) {
    }

    /// <summary>
    /// Permet de faire rentrer son pokémon dans la pokéball.
    /// </summary>
    /// <param name="pokemon"></param>
    public virtual void RetrievePokemon(PokemonMain pokemon) {
    }
    /// <summary>
    /// Permet de soigner le pokémon de son choix
    /// </summary>
    /// <param name="pokemon"></param>
    public virtual void GetHealing(PokemonMain pokemon, int healNumber) {
    }

    /// <summary>
    /// Permet de soigner tous les pokémon sur le terrain
    /// </summary>
    /// <param name="pokemon1"></param>
    /// <param name="pokemon2"></param>
    public virtual void Cook(PokemonMain pokemon1, PokemonMain pokemon2, int healNumber) {
    }

    /// <summary>
    /// Appelé lorsqu'un dresseur est battu.
    /// </summary>
    public virtual void DefeatedTrainer() {
    }
}

