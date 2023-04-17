using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectionCoup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            print("ENTER");
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            print("STAY");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            print("EXIT");
        }

    }
}

