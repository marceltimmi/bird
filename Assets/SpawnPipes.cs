using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject Prefab;
   


    // Start is called before the first frame update
    void Start()
    {


        InvokeRepeating("Spawn", 2.0f, 2f);



    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        int randomNumber = Random.Range(-3, 4);
        GameObject a = Instantiate(Prefab, gameObject.transform);
        Prefab.transform.position = new Vector2(-3.754248f, randomNumber);
        
        Debug.Log(a.transform.position);
    }
}
