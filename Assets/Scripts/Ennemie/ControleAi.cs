using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAi : MonoBehaviour
{
    // Variable publique pour la distance d'attaque
    public float attackRange = 2f;
    // Variable priv�e pour la cible du joueur
    private Transform target;
    // Variable priv�e pour l'animation d'attaque
    private Animator animator;
    void Start()
    {
        // R�cup�ration de la cible du joueur et de l'animation
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // Calcul de la distance entre l'ennemi et la cible
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // Si la cible est � port�e d'attaque, d�clencher l'animation d'attaque
        if (distanceToTarget <= attackRange)
        {
            animator.SetTrigger("Attaque");
        }
    }
}
