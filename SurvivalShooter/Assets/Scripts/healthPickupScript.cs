using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickupScript : MonoBehaviour
{
    int health;

    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<MyPlayerHealth>().currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MyPlayerHealth>().TakeHealth();
            gameObject.SetActive(false);
        }
    }
}
