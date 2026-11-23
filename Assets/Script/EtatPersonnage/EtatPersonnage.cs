using UnityEngine;

/// <summary>
/// code provenant du projet Demo-rpg de Automne 2025
/// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
/// </summary>
public abstract class EtatPersonnage 
{
    public virtual void EntrerEtat(Personnage personnage)
    {
        Debug.Log($"Personnage entre dans l'état {this.GetType().Name}");
    }
    public abstract EtatPersonnage ExecuterEtat(Personnage personnage);

    public virtual void SortirEtat(Personnage personnage)
    {
        Debug.Log($"Personnage sort de l'état {this.GetType().Name}");
    }
}
