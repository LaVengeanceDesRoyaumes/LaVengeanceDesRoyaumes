using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectionCoup : MonoBehaviour
{
    public float pointsDeVie = 100f; // points de vie du personnage
    public float degats = 10; // les d�g�ts inflig�s aux ennemis

    void Update()
    {

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            print("Vous avez frapp� l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");
            if (Input.GetKeyDown(KeyCode.J))
            {
                pointsDeVie -= degats; // soustraire les d�g�ts inflig�s aux points de vie du personnage
                DonnerCoup();
            }
        }
    }

    // Fonction pour infliger des d�g�ts aux ennemis
    private void DonnerCoup()
    {
        degats = 10;
    }

}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectionCoup : MonoBehaviour
{
    public float pointsDeVie = 100f; // point de vie du personnage
    public float degats = 10; // les d�g�ts inflig�s aux ennemis

    // Update is called once per frame


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            print("Vous avez frapp� l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");

            if (Input.GetKeyDown(KeyCode.J))
            {
                DonnerCoup();
            }

        }
    }

    private void DonnerCoup()
    {
        degats = 10;
    }
}*/


