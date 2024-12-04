using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    bool birdIsAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.gameoverEvent.AddListener(OnGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)== true)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        }
    }

    void OnGameOver()
    {
        birdIsAlive = false;
    }
}
