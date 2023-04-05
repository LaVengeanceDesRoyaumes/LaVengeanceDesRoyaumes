using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnChangementScene : MonoBehaviour
{

    public static string royaumeChoisi;

    // Bouton chargement
    public void ChargementJeu()
    {
        SceneManager.LoadScene("SceneChoixClan");
    }
    public void ChargementMapKratos()
    {
        SceneManager.LoadScene("SceneMapKratos");
        royaumeChoisi = "kratos";
    }
    public void ChargementMapJingshen()
    {
        SceneManager.LoadScene("SceneMapJingshen");
        royaumeChoisi = "jingshen";
    }

    // Boutons de retour
    public void RetourSceneClan()
    {
        SceneManager.LoadScene("SceneChoixClan");
    }
    public void RetourIntro()
    {
        SceneManager.LoadScene("SceneIntroduction");
    }
    public void RetourAccueil()
    {
        SceneManager.LoadScene("SceneDemarrage");
    }
}
