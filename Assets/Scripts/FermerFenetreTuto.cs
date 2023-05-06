using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermerFenetreTuto : MonoBehaviour
{
    /*script pour si la petite fenetre tuto est active
    et je clique nimporte o� ou j'appuie sur n'importe quel clavier,
    fermer la petite fen�tre tuto et commencer le jeu*/

    public GameObject fenetreTuto;
    public GameObject personnage1;
    public GameObject personnage2;

 
    void Start()
    {

        // Si la fen�tre de tutoriel est active
        if (fenetreTuto.activeSelf)
        {
            //l'affichage des joueurs est d�sactiv�s
           personnage1.SetActive(false); 
            personnage2.SetActive(false);



       // Si j'appuie sur une touche du clavier           
      if (Input.anyKeyDown)
            {
                // d�sactiver la fen�tre de tutoriel
                fenetreTuto.SetActive(false);

            }
        }
    }
    void Update()
    {
        // Si la fen�tre de tutoriel est active
        if (fenetreTuto.activeSelf)
        {
            //Si j'appuie sur une touche du clavier
            if (Input.anyKeyDown)
            {
                // d�sactiver la fen�tre de tutoriel
                fenetreTuto.SetActive(false);

                //l'affichage des joueurs est activ�
                personnage1.SetActive(true);
                personnage2.SetActive(true);

             
            }
        
        }
      

    }

}
