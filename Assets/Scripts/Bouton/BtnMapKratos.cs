using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnMapKratos : MonoBehaviour
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
        SceneManager.LoadScene("SceneNiveau1Kratos");
    }
    public void ChargementJeuNiveau2()
    {
        SceneManager.LoadScene("SceneNiveau2Kratos");
    }
    public void ChargementJeuNiveau3()
    {
        SceneManager.LoadScene("SceneNiveau3Kratos");
    }
    public void ChargementJeuNiveau4()
    {
        SceneManager.LoadScene("SceneNiveau4Kratos");
    }

}
