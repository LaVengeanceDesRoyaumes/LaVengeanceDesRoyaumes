using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPassePartout : MonoBehaviour
{
    //detection scenne actuelle
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scene.name.Contains("Jingshen"));
        
        if(scene.name.Contains("Kratos")){
            BtnChangementScene.royaumeChoisi = "kratos";
        }
        else if (scene.name.Contains("Jingshen")){
            BtnChangementScene.royaumeChoisi = "jingshen";
        }   
    }
}
