using UnityEngine;
using UnityEngine.UI;

public class DectectionCoup : MonoBehaviour
{
    public float pointsDeVie = 100f; // points de vie du personnage
    public float degats = 10f; // les d�g�ts inflig�s aux ennemis
    public Image barreDeVie; // la barre de vie de l'ennemi

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("ennemi"))
        {
            if (Input.GetKey(KeyCode.J))
            {
                pointsDeVie -= degats; // soustraire les d�g�ts inflig�s aux points de vie du personnage
                float pourcentageDeVie = pointsDeVie / 100f; // calculer le pourcentage de vie restant
                barreDeVie.fillAmount = pourcentageDeVie; // mettre � jour le fill amount de la barre de vie
                print("Vous avez frapp� l'ennemi ! Il lui reste " + pointsDeVie + " points de vie.");
            }
        }
    }

    // Fonction pour infliger des d�g�ts aux ennemis
    /*private void DonnerCoup()
    {
        degats = 10f;
    }*/

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            DonnerCoup();
        }
    }*/
}


