using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    public GameObject bulletExplode;
    private bool collided;

    private void Start()
    {
        collided = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag != "PowerUpMulti" && other.tag != "PowerUpLarge")//if not a powerup explode
        {
            collided = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (collided)
        { 
            Instantiate(bulletExplode, transform.position, transform.rotation);//exploded bullet sprite
            Destroy(gameObject);
        }
    }

}
