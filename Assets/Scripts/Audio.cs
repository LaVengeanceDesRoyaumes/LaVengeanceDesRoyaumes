using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Musiques de fonds principale")]
    public AudioClip audioPrincipale;

    private bool estMute = false;

    [Header("Musiques de fonds pour Jingshen")]
    public AudioClip audioJinNvxUn;
    public AudioClip audioJinNvxDeux;
    public AudioClip audioJinNvxTrois;

    [Header("Musiques de fonds pour Kratos")]
    public AudioClip audioKraNvxUn;
    public AudioClip audioKraNvxDeux;
    public AudioClip audioKraNvxTrois;

    [Header("Musiques de fonds pour niveau finale")]
    public AudioClip audioNvxFinale;



    private void Awake()
    {
        // Récupèrer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

        // Fonction pour ne pas détruire l'objet (la musique de fond) lorsque je change de scène
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Joue la musique de fond
        audioSource.clip = audioPrincipale;
        audioSource.Play();
    }

    private void Update()
    {
        //Si j'appuie sur la touche M, le jeu devient mute
        if (Input.GetKeyDown(KeyCode.M))
        {
            estMute = !estMute;
            audioSource.mute = estMute;
        }


        // Arrête la musique de fond du menu démarage et autres interfaces qui vient avant les scènes de niveaux de chaque clan
        if (SceneManager.GetActiveScene().name == "SceneNiveau1Jingshen")
        {
            audioSource.clip = audioJinNvxUn;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveau2Jingshen")
        {
            audioSource.clip = audioJinNvxDeux;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveau3Jingshen")
        {
            audioSource.clip = audioJinNvxTrois;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveau1Kratos")
        {
            audioSource.clip = audioKraNvxUn;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveau2Kratos")
        {
            audioSource.clip = audioKraNvxDeux;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveau3Kratos")
        {
            audioSource.clip = audioKraNvxTrois;
            audioSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "SceneNiveauFinale")
        {
            audioSource.clip = audioNvxFinale;
            audioSource.Play();
        }


    }
}
