using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPartie : MonoBehaviour
{

    // array de game objects pour detection du nombre de coeurs
    public GameObject[] VieCoeurs;
    // array de game objects pour detection de la conquete des territoires
    public GameObject[] ConqMapJin;
    // array de game objects pour detection des territoires déverrouillés
    public GameObject[] CadenasMapJin;

    // Update is called once per frame
    void Update()
    {
        // trouver une façon plus efficace d'écrire ça?
        // un for loop ou la variable i represente la position dans le array vieCoeurs
        if (BtnFinPartie.NbFinPerdu == 1) {
            VieCoeurs[0].SetActive(false);
        }
        if (BtnFinPartie.NbFinPerdu == 2) {
            VieCoeurs[0].SetActive(false);
            VieCoeurs[1].SetActive(false);
        }
        if (BtnFinPartie.NbFinPerdu == 3) {
            VieCoeurs[0].SetActive(false);
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
            //setactive la scene / image de "perte totale du jeu"
        }


        if (BtnFinPartie.partieRejouee == true) {
            ConqMapJin[0].SetActive(true);
            CadenasMapJin[0].SetActive(false);

            
        }


    }

    void PerteVie()
    {

    }
}
