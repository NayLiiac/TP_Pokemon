using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public int Seed;
    [SerializeField] PokemonMain _pokemonMain;
    [SerializeField] PokemonMain _pokemonMain2;
    [SerializeField] private Humains[] _trainerNumber = new Humains[2];
    public void CreateTerrain() {

        Random.InitState(Seed);
        Debug.Log($"Seed Terrain : {Seed}");

        for(int i = 0; i < _trainerNumber.Length; i++) {
            int randomFirstPkmn = Random.Range(0, _pokemonMain._pokemonNumber);
            _pokemonMain.Pkmn.PokemonScriptableObject = _pokemonMain.PkmnList.ObjectPokemonList[randomFirstPkmn];
            _pokemonMain.Pkmn.InitPokemon();

            _trainerNumber[i].GetPokemon1(_pokemonMain);

            int randomSecondPkmn = Random.Range(0, _pokemonMain2._pokemonNumber);
            _pokemonMain2.Pkmn.PokemonScriptableObject = _pokemonMain2.PkmnList.ObjectPokemonList[randomSecondPkmn];
            _pokemonMain2.Pkmn.InitPokemon();

            _trainerNumber[i].GetPokemon2(_pokemonMain2);
        }
    }
}
