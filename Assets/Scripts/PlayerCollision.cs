using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerControl control;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Terrain" || other.tag == "Unit")
        {
            control.Bounce();//only bounce back if hits terrain or unit
        }
        
    }

    void OnTriggerExit2D()//free to move again when not colliding
    {
        control.Free();
    }
}
