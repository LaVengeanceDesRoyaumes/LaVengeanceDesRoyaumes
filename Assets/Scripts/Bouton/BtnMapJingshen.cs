using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnMapJingshen : MonoBehaviour
{

    public GameObject MenuJouer;
    public GameObject boutonFrontiere;

    void Start(){
        //boutonFrontiere = GetComponent<Button>().onClick.Invoke(ChargementJeuNiveau2);;
    }

    void Update(){
     /*   if (GestionPartie.CadenasMapJin[0].activeSelf == false){
            
        }*/
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
