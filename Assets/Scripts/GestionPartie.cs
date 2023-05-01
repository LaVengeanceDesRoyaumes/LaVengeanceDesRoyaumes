using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPartie : MonoBehaviour
{
    public GameObject[] vieCoeurs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GestionEnnemi.partiePerdue == true) {
            vieCoeurs[2].SetActive(false);
        }
    }
}
