using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFrames : MonoBehaviour {

    public Sprite frame1;
    public Sprite frame2;
    private float counter;

	// Use this for initialization
	void Start () {
        counter = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //used for death animation of unit
        counter += Time.deltaTime;

        if (counter >= 1.5f)//if 1.5 seconds past, destroy game object
        {
            Destroy(gameObject);
        }
        else if (counter >= 0.6f)//after 0.6 seconds remove sprite
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (counter >= 0.4f)//after 0.4 seconds set to 3rd frame
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = frame2;
        }
        else if(counter >= 0.2f)//after .2 seconds set to 2nd frame
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = frame1;
        }
        
	}
}
