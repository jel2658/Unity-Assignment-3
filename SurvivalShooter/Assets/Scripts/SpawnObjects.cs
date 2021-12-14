using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject healthPickup;
    public GameObject[] enemies;
    public GameObject powerUp;
    float spawnCountdown;
    float timer;
    int item = 0;

    /*public Transform plane;
    float xDimensions;
    float zDimensions;*/

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        //xDimensions = plane.transform.size.x;
        //zDimensions = plane.transform.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnCountdown)
        {
            if (item == 2)
            {
                Debug.Log("Spawning Health Pickup.");
                GameObject newObj = Instantiate(healthPickup, newSpawn(), Quaternion.identity);
            } else if (item == 1)
            {
                Debug.Log("Spawning Powerup.");
                Instantiate(powerUp, newSpawn(), Quaternion.identity);
            } else if (item == 0)
            {
                Debug.Log("Spawning Enemy.");

                UnityEngine.AI.NavMeshTriangulation Triangulation = UnityEngine.AI.NavMesh.CalculateTriangulation();
                int vIndex = UnityEngine.Random.Range(0, Triangulation.vertices.Length);
                UnityEngine.AI.NavMeshHit Hit;
                if (UnityEngine.AI.NavMesh.SamplePosition(Triangulation.vertices[vIndex], out Hit, 30f, UnityEngine.AI.NavMesh.AllAreas))
                {
                    GameObject nEnemy = Instantiate(newEnemy(enemies), newSpawn(), Quaternion.identity);
                    UnityEngine.AI.NavMeshAgent agent = nEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
                    agent.Warp(Hit.position);
                }
            }
            item = (int)UnityEngine.Random.Range(0f, 3f);
            spawnCountdown = UnityEngine.Random.Range(0f, 10f);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    Vector3 newSpawn(int count = 0)
    {
        float radius = 0.1f;

        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-23f, 22f), 0.5f, UnityEngine.Random.Range(-23f, 22f));
        if (Physics.CheckSphere(spawnPos, radius))
        {
            count++;
            spawnPos = newSpawn(count);
        }
        return spawnPos;
    }

    GameObject newEnemy(GameObject[] enemies)
    {
        int size = enemies.Length;
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, size);
        return enemies[index];
    }
}
