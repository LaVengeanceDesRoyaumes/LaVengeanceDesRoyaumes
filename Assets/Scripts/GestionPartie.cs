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
        // Trouver une façon plus efficace d'écrire ça?
        // Un for loop où la variable i représente la position dans le tableau vieCoeurs

        if (BtnFinPartie.NbFinPerdu == 1)
        {
            // Désactiver le troisième élément du tableau VieCoeurs
            VieCoeurs[2].SetActive(false);
        }

        if (BtnFinPartie.NbFinPerdu == 2)
        {
            // Désactiver les deuxième et troisième éléments du tableau VieCoeurs
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);
        }

        if (BtnFinPartie.NbFinPerdu == 3)
        {
            // Désactiver tous les éléments du tableau VieCoeurs
            VieCoeurs[0].SetActive(false);
            VieCoeurs[1].SetActive(false);
            VieCoeurs[2].SetActive(false);

            // Activer l'élément EcranPerdu
            EcranPerdu.SetActive(true);
        }

        if (GestionPerso.partieGagnee == true)
        {
            if (BtnFinPartie.NbFinGagne == 1)
            {
                // Activer le premier élément du tableau ConqMap
                ConqMap[0].SetActive(true);

                // Désactiver le premier élément du tableau CadenasMap
                CadenasMap[0].SetActive(false);
            }
            else if (BtnFinPartie.NbFinGagne == 2)
            {
                // Activer le deuxième élément du tableau ConqMap
                ConqMap[1].SetActive(true);

                // Désactiver les deux premiers éléments du tableau CadenasMap
                CadenasMap[0].SetActive(false);
                CadenasMap[1].SetActive(false);
            }
            else if (BtnFinPartie.NbFinGagne == 3)
            {
                // Activer le troisième élément du tableau ConqMap
                ConqMap[2].SetActive(true);

                // Désactiver les trois premiers éléments du tableau CadenasMap
                CadenasMap[0].SetActive(false);
                CadenasMap[1].SetActive(false);
                CadenasMap[2].SetActive(false);
            }
            else if (BtnFinPartie.NbFinGagne == 4)
            {
                // Activer le quatrième élément du tableau ConqMap
                ConqMap[3].SetActive(true);

                // Désactiver tous les éléments du tableau CadenasMap
                CadenasMap[0].SetActive(false);
                CadenasMap[1].SetActive(false);
                CadenasMap[2].SetActive(false);

                // Activer l'élément EcranGagne
                EcranGagne.SetActive(true);
            }
        }
    }


    void PerteVie()
    {

    }
}
