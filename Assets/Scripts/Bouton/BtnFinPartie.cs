using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnFinPartie : MonoBehaviour
{
    public GameObject MenuDefaite;
    public GameObject MenuVictoire;
    static public int NbFinPerdu;
    static public int NbFinPartie;
    static public int NbFinGagne;

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

        if (GestionEnnemi.partiePerdue == true || GestionPerso.partieGagnee == true) {
            GestionCompteParties();

            if (GestionEnnemi.partiePerdue == true) {
            GestionComptePertes();
            }
            
            if (GestionPerso.partieGagnee == true) {
                GestionCompteGagnes();
            }
        }
    }

    public void Rejouer()
    {
         if (BtnChangementScene.royaumeChoisi == "jingshen")
        {
            SceneManager.LoadScene("SceneNiveau1Jingshen");
        }

        else if (BtnChangementScene.royaumeChoisi == "kratos")
        {
            SceneManager.LoadScene("SceneNiveau1Kratos");
        }

        if (GestionEnnemi.partiePerdue == true || GestionPerso.partieGagnee == true) {
            GestionCompteParties();

            if (GestionEnnemi.partiePerdue == true) {
            GestionComptePertes();
            }            
            
            if (GestionPerso.partieGagnee == true) {
                GestionCompteGagnes();
            }
        }
    }

    private int GestionCompteParties(){
        NbFinPartie = NbFinPartie + 1;
        return NbFinPartie;
    }

    private int GestionComptePertes(){
        NbFinPerdu = NbFinPerdu + 1;
        return NbFinPerdu;
    }

    private int GestionCompteGagnes(){
        NbFinGagne = NbFinGagne + 1;
        return NbFinGagne;
    }

    void Update()
    {
        Debug.Log("NbPartiesGagnees : " + NbFinGagne);
    }
}
