using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnMapJingshen : MonoBehaviour
{

    public GameObject MenuJouer;

    // Menu Jouer
    public void OuvrirMenuJouer()
    {
        MenuJouer.SetActive(true);
    }
    public void FermerMenuJouer()
    {
        MenuJouer.SetActive(false);
    }
    public void ChargementJeuNiveau1()
    {
        SceneManager.LoadScene("SceneNiveau1");
    }
    public void ChargementJeuNiveau2()
    {
        SceneManager.LoadScene("SceneNiveau2");
    }
    public void ChargementJeuNiveau3()
    {
        SceneManager.LoadScene("SceneNiveau3");
    }
    public void ChargementJeuNiveau4()
    {
        SceneManager.LoadScene("SceneNiveau4");
    }

}
