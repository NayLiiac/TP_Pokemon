using UnityEngine;

public class PokemonMain : MonoBehaviour
{
    public Pokemon Pkmn;
    public PokemonList PkmnList;
    public PokemonAttack PkmnAtk;
    [field : SerializeField] public int _pokemonNumber { get; private set; }

    void Start() {
        _pokemonNumber = PkmnList.GetPokemonCount();
    }

}
