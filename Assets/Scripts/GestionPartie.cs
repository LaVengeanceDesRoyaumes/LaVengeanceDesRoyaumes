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
        if (GestionEnnemi.partiePerdue == true) {
            VieCoeurs[2].SetActive(false);
        }

        if (GestionPerso.partieGagnee == true) {
            ConqMap[0].SetActive(true);
            CadenasMap[0].SetActive(false);
        }
    }
}
