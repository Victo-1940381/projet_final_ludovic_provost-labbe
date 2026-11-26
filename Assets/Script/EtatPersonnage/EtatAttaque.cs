using UnityEditor;
using UnityEngine;

public class EtatAttaque : EtatPersonnage
{
    public override void EntrerEtat(Personnage personnage)
    {
        //Debug.Log("entrer dans l'etat attaque entrer etat");
        base.EntrerEtat(personnage);
        personnage.Attaquer();
    }
    public override EtatPersonnage ExecuterEtat(Personnage personnage)
    {
        if (personnage.AttaqueEnCours)
        {
            return this;
        }
        return new EtatAttente();
    }
}
