using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour {

    private static bool active = false;

	// Use this for initialization
	void Start () {
        if (!active)
        {
            active = true;
            GameObject.DontDestroyOnLoad(gameObject);//make sure music keeps playing through scenes
        }
        else
        {
            Destroy(gameObject);//make sure only one music player exisits
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
