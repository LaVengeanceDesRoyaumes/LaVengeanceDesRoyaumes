using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnPause : MonoBehaviour
{
    public GameObject MenuPause;
    public GameObject MenuOption;

    // Menu Pause
    public void OuvrirMenuPause()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0;
    }

    // retour a la map
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

    // retour au jeu
    public void SortirMenuPause()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1;
    }

    // Menu Option
    public void OuvrirMenuOption()
    {
        MenuOption.SetActive(true);
    }
    public void FermerMenuOption()
    {
        MenuOption.SetActive(false);
    }
}
