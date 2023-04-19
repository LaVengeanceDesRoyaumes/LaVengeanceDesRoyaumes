using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPerso : MonoBehaviour
{
    public Animator animatorPerso;
    //public GameObject Baton;
    public Rigidbody rigidbodyPerso;
    public float vitesseDeplacement = 100f;
    private float vDeplacement;


    // Start is called before the first frame update
    void Start()
    {
        animatorPerso = GetComponent<Animator>();
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Invoke("Attaque", 0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Invoke("Botte", 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Invoke("Bloque", 0);
        }

        vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
        rigidbodyPerso.velocity = transform.forward * vDeplacement;

        if (Input.GetKeyDown(KeyCode.D))
        {
            animatorPerso.SetBool("MouvementAvance", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animatorPerso.SetBool("MouvementAvance", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animatorPerso.SetBool("MouvementAvance", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animatorPerso.SetBool("MouvementAvance", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animatorPerso.SetBool("MouvementRecule", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))

        {
            animatorPerso.SetBool("MouvementRecule", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animatorPerso.SetBool("MouvementRecule", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))

        {
            animatorPerso.SetBool("MouvementRecule", false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animatorPerso.SetTrigger("Attaque");
        }
    }

    /*void batonRetour()
    {
        Baton.SetActive(true);
    }*/

    void Attaque()
    {
        animatorPerso.Play("Attaque");
    }

    void Botte()
    {
        animatorPerso.Play("Botte");
    }

    void Bloque()
    {
        animatorPerso.Play("Bloque");
    }

    /* oncollisitionenter (si on détecte un coup) 
    {
        animatorPerso.Play("Coup");
    }*/

    void DectionCoup()
    {

    }
}

