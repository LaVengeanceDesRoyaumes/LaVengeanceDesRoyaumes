using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnOption : MonoBehaviour
{
    public GameObject MenuOption;

    // Menu Option
    public void OuvrirMenuOption()
    {
        MenuOption.SetActive(true);
    }
    public void SortirMenuOption()
    {
        MenuOption.SetActive(false);
    }

}
