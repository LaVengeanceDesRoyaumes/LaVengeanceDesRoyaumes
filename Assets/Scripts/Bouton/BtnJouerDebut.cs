using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnJouerDebut : MonoBehaviour
{
    public void ChargementJeu()
    {
        SceneManager.LoadScene("SceneChoixClan");
    }
}
