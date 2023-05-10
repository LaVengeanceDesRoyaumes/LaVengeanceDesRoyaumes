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
    static public bool partieRejouee = false; // pour débogger le cadenas qui bloque à nouveau si le joueur perd une partie qu'il a déja gagné

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

        if (GestionPerso.partieGagnee == true || GestionPerso.partieGagnee == false) {
            GestionCompteParties();
            GestionPartieGagnee();
            if (GestionPerso.partieGagnee == false) {
            GestionComptePertes();
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

        if (GestionPerso.partieGagnee == true || GestionPerso.partieGagnee == false) {
            GestionCompteParties();
            if (GestionPerso.partieGagnee == false) {
            GestionComptePertes();
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

    void Update()
    {
        Debug.Log("NbPartiesPerdues : " + NbFinPerdu);
        Debug.Log("NbParties : " + NbFinPartie);
    }

    private void GestionPartieGagnee(){
        partieRejouee = true;
    }
}
