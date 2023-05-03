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


    private void Awake()
    {
        // R�cup�rer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

        // Fonction pour ne pas d�truire l'objet (la musique de fond) lorsque je change de sc�ne
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


    }
}
