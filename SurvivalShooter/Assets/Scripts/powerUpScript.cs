using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    //bool toDestroy;
    //public float fleeTime;
    //float timer;
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        //toDestroy = false;
        //timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //toDestroy = true;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int index = 0; index < enemies.Length; index++)
            {
                enemies[index].GetComponent<MyEnemyMovement>().away = true;
                enemies[index].transform.Find("Text (TMP)").GetComponent<TextColorController>().away = true;
            }
            gameObject.SetActive(false);
        }
    }
}
