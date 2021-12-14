using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEscape1 : MonoBehaviour
{
    GameObject spawn1;
    public GameObject player;
    GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn1 = GameObject.Find("Escape");
        spawner = spawn1.transform.Find("Spawner").gameObject;
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
