using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriergameover : MonoBehaviour
{
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("AAAAAAAAAAAA");
        logic.gameOver();
        birdIsAlive = false;
    }
}
