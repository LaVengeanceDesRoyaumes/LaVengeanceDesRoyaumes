using System.Collections;
using System.Collections.Generic;
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


    [Header("Zone autres")]
    public float delayTimeAttaque = 2f; // Délai avant de lancer l'animation d'attaque

    private Animator animator; // Référence à l'animator
    public Rigidbody rigidbodyPerso; // Rigidbody de l'ennemi

    public Transform cible; // La cible à suivre

    public float vitesseDeplacement; // La vitesse de déplacement

    public float distanceArret; // La distance à laquelle l'ennemi s'arrête

    private void Awake()
    {
        // Récupèrer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    private void Update()
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

    IEnumerator PlayAttaqueAfterDelay()
    {
        // Attente du délai
        yield return new WaitForSeconds(delayTimeAttaque);

        //Activer l'arme (le rendre visible)

        // Lancement de l'animation
        animator.SetTrigger("Attaque");
        audioSource.clip = sonSwoosh;
        audioSource.Play();
    }
  

/*/////////////////////////////////ZONE COLLISION//////////////////////////////*/
void OnCollisionEnter (Collision other)
    {
        //si je rentre en collision avec l'arme de mon ennemi...
        if (other.gameObject.tag == "ArmeMonPerso")
        {
            //Jouer aléatoirement le son de mon personnage lorsqu'il est blessé   
            int randomIndex = Random.Range(0, sonBlesser.Length);
            GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
        }
    }
    /*// /////////////////////////////////////////////////////////////////////////////////*/
    
}