using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPers : MonoBehaviour
{
    Animator animatorPerso;
    public GameObject Baton;
    public Rigidbody rigidbodyPerso;
    public  float vitesseDeplacement = 100f; 
    

    // Start is called before the first frame update
    void Start()
    {
        animatorPerso = GetComponent<Animator>();
        rigidbodyPerso= GetComponent<Rigidbody>();
        Invoke("salut", 5);           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Invoke("attaque", 0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Invoke("botte", 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Invoke("bloque", 0);
        }

        var vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
        rigidbodyPerso.velocity= transform.forward * vDeplacement;

        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector3.left * Time.deltaTime * 200, Space.World);
            animatorPerso.Play("Recule");
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.right * Time.deltaTime * 200, Space.World);
            animatorPerso.Play("Avance");
        }        
    }

    void salut()
    {
        animatorPerso.Play("Salut");
        Baton.SetActive(false);
        Invoke("batonRetour", 2.7f);
    }

    void batonRetour()
    {        
        Baton.SetActive(true);
    }

    void attaque()
    {
        animatorPerso.Play("Attaque");
    }

    void botte()
    {
        animatorPerso.Play("Botte");
    }

    void bloque()
    {
        animatorPerso.Play("Bloque");
    }

    /* oncollisitionenter (si detecte un coup) 
    {
        animatorPerso.Play("Coup");
    }

    */
    // void OnAnimatorMove()
    // {

    //     if (animatorPerso)
    //     {
    //         Vector3 newPosition = transform.position;
    //         newPosition += animatorPerso.deltaPosition * Time.deltaTime;
    //         transform.position = newPosition;
    //     }
    // }
}
