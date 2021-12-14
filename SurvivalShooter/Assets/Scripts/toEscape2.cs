using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEscape2 : MonoBehaviour
{
    public GameObject spawn2;
    public GameObject player;
    GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn2 = GameObject.Find("Escape2");
        spawner = spawn2.transform.Find("Spawner").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameObject.Find("Player").GetComponent<SpawnController>().spawned = true;
            other.transform.position = spawner.transform.position;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && GameObject.Find("Player").GetComponent<SpawnController>().spawned == true)
        {
            GameObject.Find("Player").GetComponent<SpawnController>().spawned = false;
        }
    }*/
}
