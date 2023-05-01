using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPartie : MonoBehaviour
{
    public GameObject[] VieCoeurs;
    public GameObject[] ConqMap;
    public GameObject[] CadenasMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BtnFinPartie.NbFinPartie == 1) {
            VieCoeurs[2].SetActive(false);
        }
        if (BtnFinPartie.NbFinPartie == 2) {
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
        }
        if (BtnFinPartie.NbFinPartie == 3) {
            VieCoeurs[0].SetActive(false);
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
        }


        // if (GestionEnnemi.partiePerdue == true) {
        //     VieCoeurs[2].SetActive(false);
        // }
        

        if (GestionPerso.partieGagnee == true) {
            ConqMap[0].SetActive(true);
            CadenasMap[0].SetActive(false);
        }
    }

    void PerteVie()
    {

    }
}
