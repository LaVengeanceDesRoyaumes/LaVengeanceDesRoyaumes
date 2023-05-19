using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnVolume : MonoBehaviour
{
    [Header("Zone volume musique")]
    public GameObject volumeBoutonMin;
    public GameObject volumeBoutonBas;
    public GameObject volumeBoutonNorm;
    public GameObject volumeBoutonMax;

    public AudioSource audioSource;
    public float volumeDecrement;

    [Header("Zone volume sons")]
    public GameObject volumeSonsMin;
    public GameObject volumeSonsBas;
    public GameObject volumeSonsNorm;
    public GameObject volumeSonsMax;

    public GameObject sonPerso;
    public GameObject sonEnnemi;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //VOLUME MUSIQUE
        volumeBoutonMin.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(VolumeMin);
        volumeBoutonBas.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(VolumeBas);
        volumeBoutonNorm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(VolumeNorm);
        volumeBoutonMax.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(VolumeMax);

        //VOLUME SONS
        volumeSonsMin.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SonMin);
        volumeSonsBas.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SonBas);
        volumeSonsNorm.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SonNorm);
        volumeSonsMax.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SonMax);

       // float leSonPerso = sonPerso.GetComponent<AudioSource>().volume;

    }

    public void VolumeMin()
    {
            audioSource.volume = 0f; // met le volume � 0%
            Debug.Log("Volume est � 0%!");
           
        
    }
    //-------------------------------------------------------------------//
           // VOLUME MUSIQUE 
    //-------------------------------------------------------------------//


    public void VolumeBas()
    {
            audioSource.volume = 0.1f; // met le volume � 20%
            Debug.Log("Volume est � 10%!");
           
    }



    public void VolumeNorm()
    {
            audioSource.volume = 0.5f; // met le volume � 50%
            Debug.Log("Volume est � 50%!");
           
    }



    public void VolumeMax()
    {
       
            audioSource.volume = 0.75f; // met le volume � 75%
            Debug.Log("Volume est � 75%!");
           
       
    }


    //-------------------------------------------------------------------//
    // VOLUME SONS
    //-------------------------------------------------------------------//


    public void SonMin()
    {
      
            sonPerso.GetComponent<AudioSource>().volume = 0; // met le volume du sons du perso � 0
            sonEnnemi.GetComponent<AudioSource>().volume = 0; // met le volume du sons de l'ennemi � 0
            Debug.Log("Volume est � 0%!");
           
       
    }

    public void SonBas()
    {
        
            sonPerso.GetComponent<AudioSource>().volume = 0.1f; // met le volume du sons du perso � 10%
            sonEnnemi.GetComponent<AudioSource>().volume = 0.1f; // met le volume du sons de l'ennemi � 10%
            Debug.Log("Volume est � 10%!");
           
      
    }



    public void SonNorm()
    {
       
            sonPerso.GetComponent<AudioSource>().volume = 0.5f; // met le volume du sons du perso � 50%
            sonEnnemi.GetComponent<AudioSource>().volume = 0.5f; // met le volume du sons de l'ennemi � 50%
            Debug.Log("Volume est � 50%!");
           
        
    }



    public void SonMax()
    {
        
            sonPerso.GetComponent<AudioSource>().volume = 0.75f; // met le volume du sons du perso � 75%
            sonEnnemi.GetComponent<AudioSource>().volume = 0.75f; // met le volume du sons de l'ennemi � 75%
            Debug.Log("Volume est � 75%!");
           
        
    }

}
