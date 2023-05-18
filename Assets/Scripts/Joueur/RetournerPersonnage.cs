using UnityEngine;

public class RetournerPersonnage : MonoBehaviour
{
    public Transform autrePersonnage; // R�f�rence au transform de l'autre personnage

    private bool estRetourne = false; // Indique si le personnage est retourn� ou non

    // Update is called once per frame
    void Update()
    {
        // V�rifier si les personnages se chevauchent
        if (Physics.CheckSphere(transform.position, 0.5f) && autrePersonnage != null)
        {
            // Si le personnage est retourn�, ne rien faire
            if (estRetourne)
                return;

            // Calculer la direction de l'autre personnage
            Vector3 direction = autrePersonnage.position - transform.position;

            // V�rifier si les personnages se font face
            if (Vector3.Dot(transform.forward, direction) < 0)
            {
                // Les personnages se font dos, retourner le personnage
                transform.Rotate(0f, 180f, 0f);
                estRetourne = true;
            }
        }
        else
        {
            // R�initialiser l'�tat de retournement si les personnages ne se chevauchent pas
            estRetourne = false;
        }
    }
}
