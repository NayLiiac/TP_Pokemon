using JetBrains.Annotations;
using UnityEngine;

public class PokemonAttack : MonoBehaviour
{
    public float DamageInflicted;

    public void Attack(PokemonMain user, PokemonMain pokemontarget, PokemonAbilitiesScriptableObject[] abilityused, int indexabilitytab) {
        // On check si la capacité sert à attaquer l'ennemi :
        if (!abilityused[indexabilitytab].HealAbility) {
            // Série de check pour éviter les malentendus dans les paramètres rentrés dans la méthode
            if (pokemontarget == null || pokemontarget.Pkmn.IsKnockOut || !pokemontarget.Pkmn.IsSentOut) {
                Debug.LogError("Il n'y a pas de cible");
            }
            else if (pokemontarget == this) {
                Debug.LogError("Vous ne pouvez pas être la cible de vos attaques");
            }
            else if (user == null || user.Pkmn.IsKnockOut || !user.Pkmn.IsSentOut) {
                Debug.LogError("Vous ne pouvez pas utiliser de capacité");
            }
            else if (abilityused == null || indexabilitytab > abilityused.Length) {
                Debug.LogError("Vous n'avez pas utilisé de capacité / tenté d'utiliser une capacité inexistante");
            }
            else {
                Debug.Log($"{user.Pkmn.PokemonName} utilise {abilityused[indexabilitytab]}");
                // Check Faiblesses et Résistances lors de l'attaque
                PokemonType checkType = abilityused[indexabilitytab].abilityType;
                if (pokemontarget.Pkmn.PokemonImmunityTypes.Contains(checkType)) {
                    Debug.Log($"{abilityused[indexabilitytab]} de {user.Pkmn.PokemonName} n'a aucun effet contre {pokemontarget.Pkmn.PokemonName}");
                }

                else if (pokemontarget.Pkmn.PokemonResistancesTypes.Contains(checkType)) {
                    Debug.Log($"{abilityused[indexabilitytab]} de {user.Pkmn.PokemonName} n'est pas très efficace contre {pokemontarget.Pkmn.PokemonName}");
                    DamageInflicted = (user.Pkmn.PokemonAtk * (abilityused[indexabilitytab].AtkBasePower / 100)) / 2;
                }
                else if (pokemontarget.Pkmn.PokemonWeaknessesTypes.Contains(checkType)){
                    Debug.Log($"{abilityused[indexabilitytab]} de {user.Pkmn.PokemonName} est très efficace contre {pokemontarget.Pkmn.PokemonName}");
                    DamageInflicted = (user.Pkmn.PokemonAtk * (abilityused[indexabilitytab].AtkBasePower / 100)) * 2;
                }
                else {
                    Debug.Log($"{user.Pkmn.PokemonName} utilise {abilityused[indexabilitytab]} sur {pokemontarget.Pkmn.PokemonName}");
                    DamageInflicted = user.Pkmn.PokemonAtk * (abilityused[indexabilitytab].AtkBasePower / 100);
                }

                pokemontarget.Pkmn.DamageTaken(DamageInflicted);

                Debug.Log($"Dégâts Infligés : {DamageInflicted}");
            }
        }
        // La capacité sert à se soigner :
        else {
            CastHealAbility(user, abilityused[indexabilitytab]);
        }
        
    }

    public void CastHealAbility(PokemonMain user, PokemonAbilitiesScriptableObject abilityUsed) {
        if (!user.Pkmn.IsKnockOut) {

            Debug.Log($"{user.Pkmn.PokemonName} utilise {abilityUsed.abilityName}");
            user.Pkmn.PokemonPv += abilityUsed.HealBasePower;

            if (user.Pkmn.PokemonPv > user.Pkmn.PokemonMaxPv)
            {
                user.Pkmn.PokemonPv = user.Pkmn.PokemonMaxPv;
            }

            Debug.Log($"{user.Pkmn.PokemonName} a récupéré {abilityUsed.HealBasePower}");
        }
        else
        {
            Debug.LogError("Vous essayez de soigner un pokémon KO, veuillez choisir un pokémon vivant");
        }
    }

}
