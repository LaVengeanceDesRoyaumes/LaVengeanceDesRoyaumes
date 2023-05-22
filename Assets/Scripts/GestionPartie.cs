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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // trouver une façon plus efficace d'écrire ça?
        // un for loop ou la variable i represente la position dans le array vieCoeurs
        if (BtnFinPartie.NbFinPerdu == 1) {
            VieCoeurs[2].SetActive(false);
        }
        if (BtnFinPartie.NbFinPerdu == 2) {
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
        }
        if (BtnFinPartie.NbFinPerdu == 3) {
            VieCoeurs[0].SetActive(false);
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
        }


        // if (GestionEnnemi.partiePerdue == true) {
        //     VieCoeurs[2].SetActive(false);
        // }
        

        if (GestionPerso.partieGagnee == true) {

            if (BtnChangementScene.royaumeChoisi == "jingshen") {

                if (BtnFinPartie.NbFinGagne == 1) {
                    ConqMapJin[0].SetActive(true);
                    CadenasMapJin[0].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 2) {
                    ConqMapJin[1].SetActive(true);
                    CadenasMapJin[1].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 3) {
                    ConqMapJin[2].SetActive(true);
                    CadenasMapJin[2].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 4){
                    ConqMapJin[3].SetActive(true);
                }

            }

        }
    }

    void PerteVie()
    {

    }
}
