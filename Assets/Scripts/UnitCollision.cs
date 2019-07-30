using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCollision : MonoBehaviour {

    private int currentHealth;
    private bool multi;
    private bool large;

    private void Start()
    {
        currentHealth = 5;
        multi = false;
        large = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")//if hit by bullet
        {
            currentHealth--;
        }
        else if (other.tag == "PowerUpMulti")//if goes over multishot powerup
        {
            multi = true;
        }
        else if(other.tag == "PowerUpLarge")//if goes over large powerup
        {
            large = true;
        }

    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public bool IsMulti()
    {
        return multi;
    }
    public bool IsLarge()
    {
        return large;
    }
}
