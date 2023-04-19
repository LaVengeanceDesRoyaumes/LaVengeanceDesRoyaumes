using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleurDeBarre : MonoBehaviour
{
    public Image imageDeBarre; // l'image de la barre
    public float valeurMaximale = 100f; // la valeur maximale de la barre
    public float valeurActuelle = 100f; // la valeur actuelle de la barre
    public static float vitesseDeDiminution = 5f; // la vitesse de diminution de la barre

    private void Update()
    {
        // Diminue la valeur actuelle de la barre à une vitesse donnée
        valeurActuelle -= vitesseDeDiminution * Time.deltaTime;

        // Empêche la valeur actuelle de la barre de descendre en dessous de 0
        valeurActuelle = Mathf.Clamp(valeurActuelle, 0f, valeurMaximale);

        // Met à jour l'image de la barre avec la nouvelle valeur actuelle
        imageDeBarre.fillAmount = valeurActuelle / valeurMaximale;
    }
}
