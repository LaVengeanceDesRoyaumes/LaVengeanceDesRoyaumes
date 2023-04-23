using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPerso : MonoBehaviour
{
    [Header("Zone sons personnage")]
    private AudioSource audioSource;
    public AudioClip sonSwoosh;
    public AudioClip sonAttaque;
    public AudioClip sonBloque;
    public AudioClip[] sonBlesser;
    public AudioClip sonMort;

    [Header("Zone animatiom personnage")]
    public Animator animatorPerso;
    //public GameObject Baton;

    [Header("Vitesse et rigidbody personnage")]
    public Rigidbody rigidbodyPerso;
    public float vitesseDeplacement = 100f;
    private float vDeplacement;

  

    private void Awake()
    {
        // Récupèrer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

    }


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
            audioSource.clip = sonSwoosh;
            audioSource.Play();
            
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Invoke("Botte", 0);
            audioSource.clip = sonAttaque;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Invoke("Bloque", 0);
            audioSource.clip = sonBloque;
            audioSource.Play();
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
           // animatorPerso.SetTrigger("Attaque");
        }
    }

    /*void batonRetour()
    {
        Baton.SetActive(true);
    }*/


    /*/////////////////////////////////ZONE COLLISION//////////////////////////////*/
    void OnTriggerEnter(Collider other)
    {
        //si je rentre en collision avec l'arme de mon ennemi...
        if (other.gameObject.tag == "ArmeEnnemi")
        {
         //Jouer aléatoirement le son de mon personnage lorsqu'il est blessé   
            int randomIndex = Random.Range(0, sonBlesser.Length);
            GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
        }
    }
    /*// /////////////////////////////////////////////////////////////////////////////////*/



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

