using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BtnMapJingshen : MonoBehaviour
{

    public GameObject MenuJouer;

    void Start(){
        //Jouer.onClick.AddListener(GestionChargement);
    }

    void Update(){
        // if (GestionPartie.CadenasMapJin[0].activeSelf == false){
            
        // }
    }

    // Menu Jouer
    public void OuvrirMenuJouer()
    {
        MenuJouer.SetActive(true);
    }
    public void FermerMenuJouer()
    {
        MenuJouer.SetActive(false);
    }

    public void GestionChargement(){

    }

    public void ChargementJeuNiveau1()
    {
        SceneManager.LoadScene("SceneNiveau1Jingshen");
    }
    public void ChargementJeuNiveau2()
    {
        SceneManager.LoadScene("SceneNiveau2Jingshen");
    }
    public void ChargementJeuNiveau3()
    {
        SceneManager.LoadScene("SceneNiveau3Jingshen");
    }
    public void ChargementJeuNiveau4()
    {
        SceneManager.LoadScene("SceneNiveau4Jingshen");
    }

}
