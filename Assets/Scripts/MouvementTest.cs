using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementTest : MonoBehaviour
{
    public float vitesseDeplacement;
    public float vitesseRotation;
    public float forceSaut;

    private float vitesseV;
    private float vitesseH;
    private Vector3 directionDep;
    private float tourne;
    private float gravite;
    private bool saut;
    private bool auSol;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        vitesseV = Input.GetAxis("Vertical") * vitesseDeplacement;
        vitesseH = Input.GetAxis("Horizontal") * vitesseDeplacement;
        //tourne = Input.GetAxis("Mouse X") * vitesseRotation;

        gravite = GetComponent<Rigidbody>().velocity.y;

        RaycastHit infoCollision;
        auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.1f, -Vector3.up, out infoCollision, 0.8f);

        if (auSol)
        {
            if (Input.GetKeyDown(KeyCode.Space)) saut = true;
        }



        //transform.forward = Vector3.Lerp(transform.forward, new Vector3(vitesseH, 0f, vitesseV), 0.9f);
        //transform.forward = new Vector3(vitesseH, 0f, vitesseV);
        directionDep.y = 0;
        transform.forward = directionDep;
        GestionAnimation();
    }

    private void FixedUpdate()
    {
        if (saut) gravite += forceSaut;
        //GetComponent<Rigidbody>().velocity = new Vector3(vitesseH, 0f, vitesseV) + new Vector3(0f, gravite, 0f);
        if (directionDep != Vector3.zero)
        {
            GetComponent<Rigidbody>().velocity = (transform.forward * vitesseDeplacement) + new Vector3(0f, gravite, 0f);

        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, gravite, 0f);
        }

        saut = false;
    }

    private void GestionAnimation()
    {
        Vector3 vitesse = new Vector3(vitesseH, 0f, vitesseV).normalized;
        GetComponent<Animator>().SetFloat("vitesseDep", vitesse.magnitude);
        GetComponent<Animator>().SetBool("Saut", !auSol);
    }
}
