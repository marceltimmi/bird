using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    
    public static HighScore instance; // Singleton-Instanz
    public int score;
    public int level;

    void Awake()
    {
        // Singleton-Pattern: Nur eine Instanz des GameManagers sollte existieren
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Verhindert das L�schen des GameManagers bei Szenenwechsel
        }
        else
        {
            Destroy(gameObject);  // Zerst�rt das doppelte GameObject
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
