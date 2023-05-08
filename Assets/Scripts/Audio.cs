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
        // Récupèrer l'AudioSource du GameObject actuelle
        audioSource = GetComponent<AudioSource>();

        // Fonction pour ne pas détruire l'objet (la musique de fond) lorsque je change de scène
        DontDestroyOnLoad(gameObject);

        // S'abonner à l'événement de changement de scène
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
        // Si la scène chargée correspond à "combat" ou "carte"
        if (scene.name == "SceneNiveau1Jingshen" || scene.name == "SceneNiveau1Kratos")
        {
            // Arrêter la musique
            audioSource.Stop();

            // Enlever le GameObject de la scène courante pour éviter qu'il ne soit détruit lors du changement de scène
           // Destroy(gameObject);
        }
    }
}
