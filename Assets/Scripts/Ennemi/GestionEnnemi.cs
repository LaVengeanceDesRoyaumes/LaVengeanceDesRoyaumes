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
    public float degats = 10f; // les dégâts infligés aux ennemis
    public Image barreDeVie; // la barre de vie de l'ennemi
    public bool aiAttaque = false;

    [Header("Zone deplacement et animation")]
    public float delayTimeAttaque = 1f; // Délai avant de lancer l'animation d'attaque
    private Animator animator; // Référence à l'animator
    public Rigidbody rigidbodyPerso; // Rigidbody de l'ennemi
    public Transform cible; // La cible à suivre
    public float vitesseDeplacement; // La vitesse de déplacement
    public float distanceArret; // La distance à laquelle l'ennemi s'arrête

    [Header("Zone gestion de partie")]
    public bool finPartie = false;
    public GameObject MenuDefaite;
    public static bool partiePerdue = false;

    private void Awake()
    {
        // Récupèrer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
        finPartie = false;
    }

    private void Update()
    {
        if (!finPartie)
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

            // Lancement de la coroutine pour jouer l'animation après un certain temps
            StartCoroutine(PlayAttaqueAfterDelay());
        }

        if (pointsDeVie <= 0)
        {
            finPartie = true;
            MenuDefaite.SetActive(true);
            partiePerdue = true;
            audioSource.clip = sonMort;
            audioSource.Play();
        }
    }

    /*/////////////////////////////////ZONE COLLISIONS//////////////////////////////*/
    /*void OnTriggerEnter(Collider other)
    {
        //si je rentre en collision avec l'arme de mon ennemi...
        if (other.gameObject.tag == "ArmeMonPerso")
        {
            //Jouer aléatoirement le son de mon personnage lorsqu'il est blessé   

        }
    }*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("joueur"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attaque"))
            {
                pointsDeVie -= degats; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("l'ennemi vous a frappé  ! Il vous reste " + pointsDeVie + " points de vie.");
                int randomIndex = Random.Range(0, sonBlesser.Length);
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
            }

        }
    }

    /*/////////////////////////////////ZONE FONCTIONS//////////////////////////////*/
    IEnumerator PlayAttaqueAfterDelay()
    {
        // Attente du délai
        yield return new WaitForSeconds(delayTimeAttaque);

        // Lancement de l'animation
        animator.SetTrigger("Attaque");
        // Rendre la variable attaque true
        aiAttaque = true;
        // Jouer les sons
        audioSource.clip = sonSwoosh;
        audioSource.Play();
        // Rendre la variable attaque false
        aiAttaque = false;
    }
    /*IEnumerator PlaKickAfterDelay()
    {
        // Attente du délai
        yield return new WaitForSeconds(delayTimeKick);

        // Lancement de l'animation
        int randomNumber = Random.Range(1, 4);
        animator.SetTrigger("Kick");

        // Rendre la variable attaque true
        aiAttaque = true;
        // Jouer les sons
        audioSource.clip = sonSwoosh;
        audioSource.Play();
        // Rendre la variable attaque false
        aiAttaque = false;
    }*/
    /*void DonnerCoup()
    {
    degats = 10f;
    }*/
}