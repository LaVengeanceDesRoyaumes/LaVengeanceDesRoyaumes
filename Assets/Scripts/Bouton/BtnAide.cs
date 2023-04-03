using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnAide : MonoBehaviour
{
    public GameObject MenuAide;
    public GameObject MenuTuto;

    // Menu Aide
    public void OuvrirMenuAide()
    {
        MenuAide.SetActive(true);
    }
    public void SortirMenuAide()
    {
        MenuAide.SetActive(false);
    }

    // MenuTuTo
    public void OuvrirMenuTuto()
    {
        MenuTuto.SetActive(true);
    }
    public void SortirMenuTuto()
    {
        MenuTuto.SetActive(false);
    }

}
