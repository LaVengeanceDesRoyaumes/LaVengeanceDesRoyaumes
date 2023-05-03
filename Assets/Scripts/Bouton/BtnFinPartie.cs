using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BtnFinPartie : MonoBehaviour
{
    public GameObject MenuDefaite;
    public GameObject MenuVictoire;
    static public int NbFinPartie;

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

        if (GestionEnnemi.partiePerdue == true){
            GestionComptePertes();
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

        if (GestionEnnemi.partiePerdue == true){
            GestionComptePertes();
        }
    }

    private int GestionComptePertes(){
        NbFinPartie= NbFinPartie + 1;
        return NbFinPartie;
    }

    void Update()
    {
        Debug.Log(NbFinPartie);
    }
}
