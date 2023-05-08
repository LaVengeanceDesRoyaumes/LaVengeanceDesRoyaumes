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

    [Header("Musiques de fonds pour niveau finale")]
    public AudioClip audioNvxFinale;



    private void Awake()
    {
        // R�cup�rer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

        // Fonction pour ne pas d�truire l'objet (la musique de fond) lorsque je change de sc�ne
        DontDestroyOnLoad(gameObject);

        // S'abonner � l'�v�nement de changement de sc�ne
        SceneManager.sceneLoaded += OnSceneLoaded;
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
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si la sc�ne charg�e correspond � "combat" ou "carte"
        if (scene.name == "SceneNiveau1Jingshen" || scene.name == "SceneNiveau1Kratos")
        {
            // Arr�ter la musique
            audioSource.Stop();

            // Enlever le GameObject de la sc�ne courante pour �viter qu'il ne soit d�truit lors du changement de sc�ne
           // Destroy(gameObject);
        }
    }
}
