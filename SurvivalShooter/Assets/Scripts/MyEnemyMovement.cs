using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    public bool away;

    public float fleeTime;
    float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        away = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("Jump"))
        {
            away = !away;
        }*/

        if (away == false)
        {
            nav.SetDestination(player.position);
        } else
        {
            Vector3 toPlayer = transform.position - player.position; // Code in here from https://www.youtube.com/watch?v=Zjlg9F3FRJs

            Vector3 newPosition = transform.position + toPlayer;

            nav.SetDestination(newPosition);

            if (timer >= fleeTime)
            {
                away = false;
                timer = 0f;
            } else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
