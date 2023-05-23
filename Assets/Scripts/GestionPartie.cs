using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPartie : MonoBehaviour
{

    // array de game objects pour detection du nombre de coeurs
    public GameObject[] VieCoeurs;
    // array de game objects pour detection de la conquete des territoires
    public GameObject[] ConqMap;
    // array de game objects pour detection des territoires déverrouillés
    public GameObject[] CadenasMap;
    // ecran de fin
    public GameObject EcranGagne;
    public GameObject EcranPerdu;


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
            EcranPerdu.SetActive(true);
        }


        // if (GestionEnnemi.partiePerdue == true) {
        //     VieCoeurs[2].SetActive(false);
        // }
        

        if (GestionPerso.partieGagnee == true) {
        

                if (BtnFinPartie.NbFinGagne == 1) {
                    ConqMap[0].SetActive(true);
                    CadenasMap[0].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 2) {
                    ConqMap[1].SetActive(true);
                    CadenasMap[0].SetActive(false);
                    CadenasMap[1].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 3) {
                    ConqMap[2].SetActive(true);
                    CadenasMap[0].SetActive(false);
                    CadenasMap[1].SetActive(false);
                    CadenasMap[2].SetActive(false);
                }
                else if (BtnFinPartie.NbFinGagne == 4){
                    ConqMap[3].SetActive(true);
                    CadenasMap[0].SetActive(false);
                    CadenasMap[1].SetActive(false);
                    CadenasMap[2].SetActive(false);
                    EcranGagne.SetActive(true);
                }

        }
    }

    void PerteVie()
    {

    }
}
