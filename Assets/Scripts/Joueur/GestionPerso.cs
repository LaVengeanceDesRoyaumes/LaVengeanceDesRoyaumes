using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GestionPerso : MonoBehaviour
{
    [Header("Zone effets spéciaux")]
    public GameObject effetSang; // le prefab du système de particules
    public GameObject[] effetAttaque; // le prefab du système de particules
    public float particleDuration; // la durée de vie du système de particules en secondes

    [Header("Zone sons personnage")]
    private AudioSource audioSource;
    public AudioClip sonSwoosh;
    public AudioClip sonAttaque;
    public AudioClip[] sonBlesser;
    public AudioClip sonMort;

    [Header("Zone animation personnage")]
    public Animator animatorPerso;
    public Animator animatorEnnemi;
    //public GameObject Baton;

    [Header("Vitesse et rigidbody personnage")]
    public Rigidbody rigidbodyPerso;
    public float vitesseDeplacement = 100f;
    private float vDeplacement;
    public float hauteurSaut;

    [Header("Zone detection des coups")]
    public float pointsDeVie = 100f; // points de vie de l'ennemie
    public float degats = 3f; // les dégâts infligés aux ennemis
    public float degatsFrappe = 4f; // les dégâts avec le kick 2
    public float degatsBotte = 5f; // les dégâts infligés aux ennemis avec kick
    public Image barreDeVie; // la barre de vie de l'ennemi

    [Header("Zone gestion de partie")]
    public static bool finPartie = false;
    public GameObject MenuVictoire;
    public static bool partieGagnee;

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
        finPartie = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finPartie)
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
                Invoke("Frappe", 0);
                audioSource.clip = sonAttaque;
                audioSource.Play();
            }
            /*if (Input.GetKeyDown(KeyCode.W))
            {
                Invoke("Saute", 0);
                //rigidbodyPerso.AddForce(Vector3.up * hauteurSaut);
                rigidbodyPerso.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            }*/

            vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
            //rigidbodyPerso.velocity = transform.forward * vDeplacement;
            rigidbodyPerso.velocity = new Vector2(vDeplacement, 0);

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
        }

        if (pointsDeVie <= 0)
        {
            animatorEnnemi.SetTrigger("Mort");
            Invoke("FinPartie", 4);
            //audioSource.clip = sonMort;
            // audioSource.Play();
            GetComponent<AudioSource>().PlayOneShot(sonMort);

            finPartie = true;
        }
    }


    /*/////////////////////////////////ZONE COLLISION//////////////////////////////*/
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ennemi"))
        {
            if (Input.GetKey(KeyCode.J))
            {

                // Pour créer un nouveau GameObject à partir du prefab du système de particules
                GameObject newParticles = Instantiate(effetSang, other.contacts[0].point, Quaternion.identity);

                // Détruire le GameObject des particules après un certain temps(particleDuration)
                Destroy(newParticles, particleDuration);

                /*vie*/
                pointsDeVie -= degats; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("Vous avez frappé l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");
                /*sons*/
                int randomIndex = Random.Range(0, sonBlesser.Length);//Jouer aléatoirement le son de mon personnage lorsqu'il est blessé 
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorEnnemi.Play("Blesser");
            }
            if (Input.GetKey(KeyCode.K))
            {
                // Instancier un objet au hasard depuis le tableau de prefabs
                int choixAleaIndex = Random.Range(0, effetAttaque.Length);
                // Pour créer un nouveau GameObject à partir du prefab du système de particules
                GameObject newParticles = Instantiate((effetAttaque[choixAleaIndex]), other.contacts[0].point, Quaternion.identity);

                // Détruire le GameObject des particules après un certain temps(particleDuration)
                Destroy(newParticles, particleDuration);

                /*vie*/
                pointsDeVie -= degatsBotte; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("Vous avez frappé l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");
                /*sons*/
                int randomIndex = Random.Range(0, sonBlesser.Length);//Jouer aléatoirement le son de mon personnage lorsqu'il est blessé 
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorEnnemi.Play("Blesser");
            }
            if (Input.GetKey(KeyCode.L))
            {
                // Instancier un objet au hasard depuis le tableau de prefabs
                int choixAleaIndex = Random.Range(0, effetAttaque.Length);
                // Pour créer un nouveau GameObject à partir du prefab du système de particules
                GameObject newParticles = Instantiate((effetAttaque[choixAleaIndex]), other.contacts[0].point, Quaternion.identity);

                // Détruire le GameObject des particules après un certain temps(particleDuration)
                Destroy(newParticles, particleDuration);

                /*vie*/
                pointsDeVie -= degatsFrappe; // soustraire les dégâts infligés aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre à jour le fill amount de la barre de vie
                print("Vous avez frappé l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");
                /*sons*/
                int randomIndex = Random.Range(0, sonBlesser.Length);//Jouer aléatoirement le son de mon personnage lorsqu'il est blessé 
                GetComponent<AudioSource>().PlayOneShot(sonBlesser[randomIndex]);
                animatorEnnemi.Play("Blesser");
            }
        }
    }
    /*/////////////////////////////////ZONE FONCTIONS/////////////////////////////////*/
    void Attaque()
    {
        animatorPerso.Play("Attaque");
    }

    void Botte()
    {
        animatorPerso.Play("Kick");
    }
    void Frappe()
    {
        animatorPerso.Play("Frappe");
    }
    /*void Saute()
    {
        animatorPerso.Play("Saute");
    }*/

    void FinPartie()
    {
        MenuVictoire.SetActive(true);
        partieGagnee = true;
    }

}