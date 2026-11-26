using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class Personnage : MonoBehaviour
{

    private Animator personnageAnim;
    private Vector2 controleDeplacement;
    private float controleRotation;
    [SerializeField, Tooltip("la vitesse de rotation du personnage")]
    private float vitesseRotation;
    [SerializeField, Tooltip("la vitesse de déplacement du personnage")]
    private float vitesse;

    public bool AttaqueEnCours {  get; private set; }

    private bool enMarche;
    private bool enRotation;
    public bool EnDeplacement => enMarche || enRotation;

    public bool InteractionEnCours { get; private set; }

    private EtatPersonnage etatPrecedent;
    private EtatPersonnage etatSuivant;

    private void Awake()
    {
        etatSuivant = new EtatAttente();
        personnageAnim = GetComponent<Animator>();
    }
    /// <summary>
    /// code provenant du projet Demo-rpg de Automne 2025
    /// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
    /// </summary>
    public void OnDeplacement(InputAction.CallbackContext context)
    {
        controleDeplacement = context.ReadValue<Vector2>();
        
        enMarche = controleDeplacement.sqrMagnitude > 0.01f;

    }
    public void DemarrerDeplacement()
    {
        personnageAnim.SetBool("Marcher", true);
    }
    public void ArreterDeplacement()
    {
        personnageAnim.SetBool("Marcher", false);
    }
    /// <summary>
    /// code provenant du projet Demo-rpg de Automne 2025
    /// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
    /// </summary>
    public void OnRotation(InputAction.CallbackContext context)
    {
        controleRotation = context.ReadValue<float>();

        enRotation = !Mathf.Approximately(controleRotation, 0.0f);
    }
    void Update()
    {
        if (etatPrecedent != etatSuivant)
        {
            etatSuivant.EntrerEtat(this);
        }
        etatPrecedent = etatSuivant;
        etatSuivant = etatSuivant.ExecuterEtat(this);

        if (etatPrecedent != etatSuivant)
        {
            etatPrecedent.SortirEtat(this);
        }
    }
    /// <summary>
    /// code provenant du projet Demo-rpg de Automne 2025
    /// https://github.com/Cours-Alexandre-Ouellet/demo-rpg
    /// </summary>
    public void Deplacer()
    {
        Vector3 deplacement = controleDeplacement.y * transform.forward +
            controleDeplacement.x * transform.right;

      
        deplacement = vitesse * Time.deltaTime * deplacement.normalized;
        Debug.Log($"ctrl={controleDeplacement} | dep={deplacement}");
        transform.position += deplacement;

      

        Quaternion rotation = Quaternion.Euler(0.0f, controleRotation * Time.deltaTime * vitesseRotation, 0.0f);
        transform.rotation *= rotation;
    }
}
