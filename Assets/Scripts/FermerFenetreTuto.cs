using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermerFenetreTuto : MonoBehaviour
{
    /*script pour si la petite fenetre tuto est active
    et je clique nimporte où ou j'appuie sur n'importe quel clavier,
    fermer la petite fenêtre tuto et commencer le jeu*/

    public GameObject fenetreTuto;
    public GameObject personnage1;
    public GameObject personnage2;

 
    void Start()
    {

        // Si la fenêtre de tutoriel est active
        if (fenetreTuto.activeSelf)
        {
            //l'affichage des joueurs est désactivés
           personnage1.SetActive(false); 
            personnage2.SetActive(false);



       // Si j'appuie sur une touche du clavier           
      if (Input.anyKeyDown)
            {
                // désactiver la fenêtre de tutoriel
                fenetreTuto.SetActive(false);

            }
        }
    }
    void Update()
    {
        // Si la fenêtre de tutoriel est active
        if (fenetreTuto.activeSelf)
        {
            //Si j'appuie sur une touche du clavier
            if (Input.anyKeyDown)
            {
                // désactiver la fenêtre de tutoriel
                fenetreTuto.SetActive(false);

                //l'affichage des joueurs est activé
                personnage1.SetActive(true);
                personnage2.SetActive(true);

             
            }
        
        }
      

    }

}
