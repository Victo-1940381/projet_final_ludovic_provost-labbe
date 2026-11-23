using UnityEngine;
/// <summary>
/// code provenant du projet Demo-rpg de Automne 2025
/// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
/// </summary>

public class EtatDeplacement : EtatPersonnage
{
    public override void EntrerEtat(Personnage personnage)
    {
        base.EntrerEtat(personnage);

    }
    public override EtatPersonnage ExecuterEtat(Personnage personnage)
    {
        personnage.Deplacer();
        if (!personnage.EnDeplacement)
        {
            return new EtatAttente();
        }
        return this;
    }
    public override void SortirEtat(Personnage personnage)
    {
        base.SortirEtat(personnage);
    }
}
