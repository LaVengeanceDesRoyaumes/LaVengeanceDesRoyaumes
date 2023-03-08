using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNinjaN1 : MonoBehaviour
{
    Animator animatorNinja;
    public GameObject Baton;

    // Start is called before the first frame update
    void Start()
    {
        animatorNinja = GetComponent<Animator>();
        Invoke("salut", 5);        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void salut()
    {
        animatorNinja.Play("Salut");
        Baton.SetActive(false);
        Invoke("batonRetour", 2.7f);
    }

    void batonRetour()
    {        
        Baton.SetActive(true);
    }


}
