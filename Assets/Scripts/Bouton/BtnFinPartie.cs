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
        
            GestionCompteParties();

        if (GestionEnnemi.partiePerdue == true) {

                GestionComptePertes();
            
        }
        if (GestionEnnemi.partiePerdue == false)
        {
                GestionCompteGagnes();
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

        
            GestionCompteParties();

        if (GestionEnnemi.partiePerdue == true)
        {
                GestionComptePertes();
            
        }

        if (GestionEnnemi.partiePerdue == false)
        {
                GestionCompteGagnes();
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
        Debug.Log("Gagnees : " + NbFinGagne);
        Debug.Log("Perdues : " + NbFinPerdu);
        Debug.Log("Totales : " + NbFinPartie);

        Debug.Log("Gagne?" + GestionEnnemi.partiePerdue);
    }
}
