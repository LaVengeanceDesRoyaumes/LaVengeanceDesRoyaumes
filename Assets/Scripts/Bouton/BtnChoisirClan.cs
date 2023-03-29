using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnChoisirClan : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Invoke("ChargementJeu", 0f);
    }

    public void DetectionClic()
    {
        Invoke("ChargementJeu", 1f);
    }

    void ChargementJeu()
    {
        SceneManager.LoadScene("SceneChoixClan");
    }

}
