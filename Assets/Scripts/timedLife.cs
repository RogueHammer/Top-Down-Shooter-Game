using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedLife : MonoBehaviour {

    public float timer = 0.5f;
    private float counter;
	
    void Start()
    {
        counter = 0;
    }
	// Update is called once per frame
	void FixedUpdate () {//used to determine how long particles, like bullet explosion stay on sceen
        counter += Time.deltaTime;
        if (counter >= timer)
        {
            Destroy(gameObject);
        }

    }
}
