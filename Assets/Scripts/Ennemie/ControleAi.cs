using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAi : MonoBehaviour
{
    // Temps avant de lancer l'animation attaque
    public float delayTimeAttaque = 2f;
    // Référence à l'Animator
    private Animator animator;
    public Rigidbody rigidbodyPerso;
    public float vitesseDeplacement = 100f;
    private float vDeplacement;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Lancement de la coroutine pour jouer l'animation après un certain temps
        StartCoroutine(PlayAttaqueAfterDelay());

        vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
        rigidbodyPerso.velocity = transform.forward * vDeplacement;
    }

    IEnumerator PlayAttaqueAfterDelay()
    {
        // Attente du délai
        yield return new WaitForSeconds(delayTimeAttaque);
        // Lancement de l'animation
        animator.SetTrigger("Attaque");
    }

}


