using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArme : MonoBehaviour
{
    public Transform pointDancrage; // le point d'ancrage de l'arme sur le personnage
    public GameObject arme; // l'objet de l'arme

    private Quaternion rotationOriginale; // la rotation originale de l'arme

    private void Start()
    {
        // Sauvegarde la rotation originale de l'arme
        rotationOriginale = arme.transform.localRotation;

    }

    private void Update()
    {

        arme.transform.SetParent(pointDancrage);
        arme.transform.localPosition = Vector3.zero;
        arme.transform.localRotation = rotationOriginale;

    }
}
