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
    private bool sonMortJoue = false; // Variable pour suivre l'état de lecture du son de mort


    [Header("Zone animation personnage")]
    public Animator animatorPerso;
    public Animator animatorEnnemi;
    //public GameObject Baton;

    [Header("Vitesse et rigidbody personnage")]
    public Rigidbody rigidbodyPerso;
    public Rigidbody enemyRigidbody;
    public float vitesseDeplacement = 100f;
    private float vDeplacement;
    public float hauteurSaut;

    [Header("Zone detection des coups")]
    public float pointsDeVie = 100f; // points de vie de l'ennemie
    public float degats = 3f; // les dégâts infligés aux ennemis
    public float degatsFrappe = 4f; // les dégâts avec la frappe
    public float degatsBotte = 5f; // les dégâts infligés aux ennemis avec kick
    public float reculeAttaque = 100;
    public float reculeFrappe = 100;
    public float reculeKick = 1000;
    public Image barreDeVie; // la barre de vie de l'ennemi

    [Header("Zone gestion de partie")]
    public static bool finPartie = false;
    public GameObject MenuVictoire;
    //public static bool partieGagnee;

    [Header("Zone retourne perso")]
    private bool estRetourne = false; // Indique si le personnage est retourné ou non
    public GameObject autrePersonnage; // Référence à l'autre personnage

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
            /* GERER RETOURNEMENT*/
            if (Input.GetKeyDown(KeyCode.R))
            {
                RetournerPersonnages();
            }

            float vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;

            if (estRetourne)
            {
                // Inverser les valeurs de déplacement gauche et droite
                vDeplacement = -vDeplacement;
            }

            rigidbodyPerso.velocity = new Vector2(vDeplacement, 0);

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (estRetourne)
                {
                    animatorPerso.SetBool("MouvementRecule", true);
                }
                else
                {
                    animatorPerso.SetBool("MouvementAvance", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (estRetourne)
                {
                    animatorPerso.SetBool("MouvementRecule", false);
                }
                else
                {
                    animatorPerso.SetBool("MouvementAvance", false);
                }
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (estRetourne)
                {
                    animatorPerso.SetBool("MouvementAvance", true);
                }
                else
                {
                    animatorPerso.SetBool("MouvementRecule", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (estRetourne)
                {
                    animatorPerso.SetBool("MouvementAvance", false);
                }
                else
                {
                    animatorPerso.SetBool("MouvementRecule", false);
                }
            }
        }

        if (pointsDeVie <= 0)
        {
            animatorEnnemi.SetTrigger("Mort");
            Invoke("FinPartie", 4);
            if (!sonMortJoue)
            {
                GetComponent<AudioSource>().PlayOneShot(sonMort);
                sonMortJoue = true; // Définir la variable sur "true" lorsque le son de mort est joué
            }

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

                enemyRigidbody.AddForce(transform.forward * reculeAttaque, ForceMode.Impulse);
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

                enemyRigidbody.AddForce(transform.forward * reculeKick, ForceMode.Impulse);
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

                enemyRigidbody.AddForce(transform.forward * reculeFrappe, ForceMode.Impulse);
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
        //partieGagnee = true;
    }

    public void RetournerPersonnages()
    {
        // Inverser la valeur de estRetourne
        estRetourne = !estRetourne;

        // Inverser la rotation du personnage actuel
        transform.Rotate(Vector3.up, 180f);

        // Inverser la rotation de l'autre personnage
        autrePersonnage.transform.Rotate(Vector3.up, 180f);
    }

}