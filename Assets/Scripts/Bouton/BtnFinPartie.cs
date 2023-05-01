using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnFinPartie : MonoBehaviour
{
    public GameObject MenuDefaite;
    public GameObject MenuVictoire;

    public void RetourMap()
    {
        if (BtnChangementScene.royaumeChoisi == "jingshen")
        {
            SceneManager.LoadScene("SceneMapJingshen");
        }

        else if (BtnChangementScene.royaumeChoisi == "kratos")
        {
            SceneManager.LoadScene("SceneMapKratos");
        }
    }
}
