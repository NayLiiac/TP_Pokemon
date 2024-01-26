using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonList : MonoBehaviour
{
    public List<PokemonScriptableObject> ObjectPokemonList = new List<PokemonScriptableObject>();

    public int GetPokemonCount() {
        return ObjectPokemonList.Count;
    }
}
