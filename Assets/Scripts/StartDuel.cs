using UnityEngine;

public class StartDuel : MonoBehaviour
{
    [SerializeField] GenerateTerrain _generateTerrain;
    [SerializeField] Sacha _trainer1;
    [SerializeField] Ondine _trainer2;
    [SerializeField] Pierre _healer;
    public void InitDuel() {

        _generateTerrain.CreateTerrain();

        _trainer1.SentOutPokemon(_trainer1.FirstPokemon);
        _trainer2.SentOutPokemon(_trainer2.FirstPokemon);

        // Message : Cela a pour effet d'envoyer le même pokemon, alors que les pokémon attribués sont différents
        // et j'ai beau chercher, je trouve pas de moyen de les différencier à cause de manque de temps
        // Je sais que ça a un lien avec mes GameObject PokemonMain et PokemonMain2 qui sont dans ma hiérarchie
        // et ma classe abstraite Humains, mais du coup cela ne fonctionne pas bien

        _trainer1.FirstPokemon.PkmnAtk.Attack(_trainer1.FirstPokemon, _trainer2.FirstPokemon, _trainer1.FirstPokemon.Pkmn.PokemonAbilitiesTab, 1);
        _trainer1.FirstPokemon.PkmnAtk.Attack(_trainer1.FirstPokemon, _trainer2.FirstPokemon, _trainer1.FirstPokemon.Pkmn.PokemonAbilitiesTab, 1);

        _trainer1.SecondPokemon.PkmnAtk.Attack(_trainer1.SecondPokemon, _trainer2.SecondPokemon, _trainer1.SecondPokemon.Pkmn.PokemonAbilitiesTab, 1);

//        _healer.Cook(_trainer1.SecondPokemon, _trainer2.SecondPokemon, 30);

        _trainer1.SecondPokemon.PkmnAtk.Attack(_trainer1.SecondPokemon, _trainer2.SecondPokemon, _trainer1.SecondPokemon.Pkmn.PokemonAbilitiesTab, 3);


    }
}
