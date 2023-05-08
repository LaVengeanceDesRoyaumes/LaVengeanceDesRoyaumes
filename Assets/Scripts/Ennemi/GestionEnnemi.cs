using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GestionEnnemi : MonoBehaviour
{
    [Header("Zone sons personnage")]
    private AudioSource audioSource;
    public AudioClip sonSwoosh;
    public AudioClip sonAttaque;
    //public AudioClip sonBloque;
    public AudioClip[] sonBlesser;
    public AudioClip sonMort;

    [Header("Zone detection des coups")]
    public float pointsDeVie = 100f; // points de vie du personnage
    public float degats0 = 10f; // les dégâts infligés aux ennemis
    public float degats2 = 10f; // les dégâts infligés aux ennemis
    public float degats1 = 10f; // les dégâts infligés aux ennemis
    public float degats3 = 10f; // les dégâts infligés aux ennemis
    public Image barreDeVie; // la barre de vie de l'ennemi
    public bool aiAttaque = false;

    [Header("Zone deplacement et animation")]
    public float tempsAttaque; // Délai avant de lancer l'animation d'attaque
    private Animator animator; // Référence à l'animator
    public Animator animatorJoueur; // Référence à l'animator du joueur
    public Rigidbody rigidbodyPerso; // Rigidbody de l'ennemi
    public Transform cible; // La cible à suivre
    public float vitesseDeplacement; // La vitesse de déplacement
    public float distanceArret; // La distance à laquelle l'ennemi s'arrête

    [Header("Zone gestion de partie")]
    public GameObject MenuDefaite;
    public static bool partiePerdue = false;

    public int numeroA=3;

    void Start()
    {
        GestionPerso.finPartie = false;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
        // Lancement de la coroutine pour jouer l'animation après un certain temps
        InvokeRepeating("PlayAttaqueAfterDelay", tempsAttaque, tempsAttaque);
    }

    private void Update()
    {
        if (!GestionPerso.finPartie)
        {
            // Vérifie si la cible est valide
            if (cible == null)
                return;
            // Calcule la distance entre l'AI et la cible
            float distance = Vector3.Distance(transform.position, cible.position);
            // Si la distance est supérieure à la distance d'arrêt, continue de se déplacer vers la cible
            if (distance > distanceArret)
            {
                // Calcule la direction vers la cible
                Vector3 direction = (cible.position - transform.position).normalized;
                // Déplace l'AI dans la direction de la cible à la vitesse donnée
                transform.position += direction * vitesseDeplacement * Time.deltaTime;
                // Animation de marche
                animator.SetBool("MouvementAvance", true);
            }

            else
            {
                animator.SetBool("MouvementAvance", false);
            }
        }

        if (pointsDeVie <= 0)
        {
            audioSource.PlayOneShot(sonMort);
            animatorJoueur.SetTrigger("Mort");
            GestionPerso.finPartie = true;
            Invoke("FinPartie", 4);
        }
    }

    /*/////////////////////////////////ZONE COLLISIONS//////////////////////////////*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attaque"))
            {
                int randomIndex = Random.Range(0, sonBlesser.Length);
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorJoueur.Play("Blesser");
                pointsDeVie -= degats0; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("l'ennemi vous a frappé  ! Il vous reste " + pointsDeVie + " points de vie.");
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Frappe"))
            {
                int randomIndex = Random.Range(0, sonBlesser.Length);
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorJoueur.Play("Blesser");
                pointsDeVie -= degats1; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("l'ennemi vous a frappé  ! Il vous reste " + pointsDeVie + " points de vie.");
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
            {
                int randomIndex = Random.Range(0, sonBlesser.Length);
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorJoueur.Play("Blesser");
                pointsDeVie -= degats2; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("l'ennemi vous a frappé  ! Il vous reste " + pointsDeVie + " points de vie.");
            }
            /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("KickHaut"))
            {
                int randomIndex = Random.Range(0, sonBlesser.Length);
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorJoueur.Play("Blesser");
                pointsDeVie -= degats3; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("l'ennemi vous a frappé  ! Il vous reste " + pointsDeVie + " points de vie.");
            }*/
        }
    }

    /*/////////////////////////////////ZONE FONCTIONS//////////////////////////////*/
    void PlayAttaqueAfterDelay()
    {
        if (!GestionPerso.finPartie)
        {
            // Lancement de l'animation
            numeroA = Random.Range(1, 4);
            Debug.Log("attaque choisis" + numeroA);
            animator.SetTrigger("Attaque_" + numeroA);
            // Rendre la variable attaque true
            aiAttaque = true;
            // Rendre la variable attaque false
            aiAttaque = false;
        }
    }
    /*void CoupAleatoire()
    {
        numeroA = Random.Range(1, 5);
        Debug.Log("attaque choisis" + numeroA);
    }*/
    void FinPartie()
    {
        MenuDefaite.SetActive(true);
        partiePerdue = true;
    }
}