using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour {

    private float rotation;
    private float radians;
    public float speed = 0.05f;
    private Vector3 pos;

    // Use this for initialization
    void Start () {
        rotation = transform.rotation.eulerAngles.z;
        radians = rotation / 360 * 2 * Mathf.PI;
        pos = transform.position;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {//moves projectile
        pos.y += Mathf.Cos(radians) * speed;
        pos.x += Mathf.Sin(-radians) * speed;
        transform.position = pos;
    }
}
