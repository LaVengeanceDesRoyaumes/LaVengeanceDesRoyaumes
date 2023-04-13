using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GestionEnnemi : MonoBehaviour
{
    public float delayTimeAttaque = 2f; // Délai avant de lancer l'animation d'attaque

    private Animator animator; // Référence à l'animator
    public Rigidbody rigidbodyPerso; // Rigidbody de l'ennemi

    public Transform target; // La cible à suivre

    public float speed = 5f; // La vitesse de déplacement

    public float stoppingDistance = 1f; // La distance à laquelle l'ennemi s'arrête

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        // Vérifie si la cible est valide

        if (target == null)

            return;


        // Calcule la distance entre l'AI et la cible

        float distance = Vector3.Distance(transform.position, target.position);


        // Si la distance est supérieure à la distance d'arrêt, continue de se déplacer vers la cible

        if (distance > stoppingDistance)
        {

            // Calcule la direction vers la cible

            Vector3 direction = (target.position - transform.position).normalized;

            // Déplace l'AI dans la direction de la cible à la vitesse donnée

            transform.position += direction * speed * Time.deltaTime;

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

        // Lancement de l'animation
        animator.SetTrigger("Attaque");
    }

}