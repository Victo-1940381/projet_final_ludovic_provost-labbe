using UnityEngine;
/// <summary>
/// code provenant du projet Demo-rpg de Automne 2025
/// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
/// </summary>

public class EtatAttente : EtatPersonnage
{
    
    public override EtatPersonnage ExecuterEtat(Personnage personnage)
    {
        if (personnage.EnDeplacement)
        {
            return new EtatDeplacement();
        }
        if (personnage.AttaqueEnCours)
        {
            return new EtatAttaque();
        }
        return this;
    }
}
