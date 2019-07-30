using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Unit")//if power up is hit by unit (player or enemy)
        {
            Destroy(gameObject);
        }

    }
}
