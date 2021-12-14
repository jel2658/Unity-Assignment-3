﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    public Image gameOverScreen;

    Animator anim;
    AudioSource playerAudio;
    MyPlayerMovement playerMovement;
    bool isDead;
    bool damaged;
    float speed;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        speed = GetComponent<MyPlayerMovement>().speed;
        playerMovement = GetComponent<MyPlayerMovement>();

        currentHealth = startingHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        //health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        } else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;

        /*if (health <= 0)
        {
            speed = 0;
            anim.SetTrigger("Die");
        }*/

    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;

        //gameOverScreen.GetComponent<Image>().enabled = true;
    }

    public void TakeHealth()
    {
        currentHealth *= 2;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthSlider.value = currentHealth;
    }
}
