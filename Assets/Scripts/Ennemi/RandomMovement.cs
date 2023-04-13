using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Vitesse du mouvement
    public float speed = 5f;

    // Temps avant de changer de direction
    public float changeDirectionTime = 20f;

    // Direction du mouvement (1 pour droite, -1 pour gauche)
    private int direction = 1;

    // Temps écoulé depuis le dernier changement de direction
    private float elapsedTime = 0f;

    void Update()
    {
        // Mise à jour de la direction en fonction du temps écoulé
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeDirectionTime)
        {
            direction = Random.Range(0, 2) == 0 ? -1 : 1;
            elapsedTime = 0f;
        }

        // Calcul du déplacement en fonction de la direction et de la vitesse
        float moveZ = direction * speed * Time.deltaTime;

        // Déplacement de l'objet sur l'axe x
        transform.Translate(0f, 0f, moveZ);
    }
}
