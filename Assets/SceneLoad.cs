using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    bool vloaded = false;
    bool ploaded = false;
    // Start is called before the first frame update
    void Start()
    {

   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneVormaier()
    {
        vloaded = !vloaded;
    
    }

    public void LoadSceneprobst()
    {
        ploaded = !ploaded;
  
    }

    public void LoadScene()
    {
        if(vloaded == true)
        {
            SceneManager.LoadScene("Scenes/Vormaier");
        }

        else if(ploaded == true)
        {
            SceneManager.LoadScene("Scenes/Probst");
        }
    }
}
