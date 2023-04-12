using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAi : MonoBehaviour
{
    // Variable publique pour la distance d'attaque
    public float attackRange = 2f;
    // Variable privée pour la cible du joueur
    private Transform target;
    // Variable privée pour l'animation d'attaque
    private Animator animator;
    void Start()
    {
        // Récupération de la cible du joueur et de l'animation
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Calcul de la distance entre l'ennemi et la cible
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // Si la cible est à portée d'attaque, déclencher l'animation d'attaque
        if (distanceToTarget <= attackRange)
        {
            animator.SetTrigger("Attaque");
        }
    }
}
