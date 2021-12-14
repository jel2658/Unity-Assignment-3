using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorController : MonoBehaviour
{
    public bool away;

    private TextMeshPro tmpro;

    float fleeTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = gameObject.GetComponent<TextMeshPro>();
        //tmpro.text = "!";
        //tmpro.color = Color.red;
        away = false;
        timer = 0f;
        fleeTime = transform.parent.GetComponent<MyEnemyMovement>().fleeTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("Jump"))
        {
            away = !away;
        }*/

        if (away == true)
        {
            if (timer >= fleeTime)
            {
                away = false;
                timer = 0f;
            } else
            {
                timer += Time.deltaTime;
            }
            tmpro.color = Color.blue;
        } else
        {
            tmpro.color = Color.red;
        }
    }
}
