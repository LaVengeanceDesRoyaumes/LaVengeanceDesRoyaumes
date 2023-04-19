using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendreArme : MonoBehaviour
{
    public Transform pointDancrage; // le point d'ancrage de l'arme sur le personnage
    public GameObject arme; // l'objet de l'arme
    public KeyCode toucheEquiper = KeyCode.E; // la touche pour équiper/déséquiper l'arme
    public float vitesseRotation = 10f; // la vitesse de rotation de l'arme

    private bool estEquipee = false; // indique si l'arme est équipée ou non
    private Quaternion rotationOriginale; // la rotation originale de l'arme

    private void Start()
    {
        // Sauvegarde la rotation originale de l'arme
        rotationOriginale = arme.transform.localRotation;
    }

    private void Update()
    {
        // Vérifie si la touche pour équiper/déséquiper l'arme est pressée
        if (Input.GetKeyDown(toucheEquiper))
        {
            estEquipee = !estEquipee;

            // Attache ou détache l'arme du point d'ancrage
            if (estEquipee)
            {
                arme.transform.SetParent(pointDancrage);
                arme.transform.localPosition = Vector3.zero;
                arme.transform.localRotation = rotationOriginale;
            }
            else
            {
                arme.transform.SetParent(null);
                arme.transform.rotation = Quaternion.identity;
            }
        }

        // Fait tourner l'arme en fonction des mouvements du personnage
        if (estEquipee)
        {
            float mouseX = Input.GetAxis("Mouse X") * vitesseRotation;
            arme.transform.Rotate(Vector3.up, mouseX, Space.World);
        }
    }
}
