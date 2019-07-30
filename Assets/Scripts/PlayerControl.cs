using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private float rotation;
    private float speed;
    private Vector3 pos;
    private bool collided;
    private float radians;

    public float rotationalSpeed = 1.5f;
    public float maxSpeed = 0.04f;

    public KeyCode up = KeyCode.UpArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode shoot = KeyCode.Z;

    public GameObject ammunition;


	// Use this for initialization
	void Start () {
        speed = 0;
        pos = transform.position;
        rotation = transform.rotation.eulerAngles.z;
        collided = false;//used to stop input while colliding

    }
	
	// Update is called once per frame
	void Update () {
        
        
        float deltaS = Time.deltaTime;
        if (Input.GetKey(up) && !collided)//move forward
        {
            speed = Mathf.Min(speed + deltaS, maxSpeed);
        }

        if (Input.GetKey(down) && !collided)//move backward
        {
            speed = Mathf.Max(-maxSpeed, speed - deltaS);
        }

        if (Input.GetKey(left) && !collided)//rotate left
        {
            rotation += rotationalSpeed;
        }

        if (Input.GetKey(right) && !collided)//rotate right
        {
            rotation -= rotationalSpeed;
        }

        if (Input.GetKeyDown(shoot))//shoot
        {
            float scale = 1f;
            if (gameObject.GetComponent<UnitCollision>().IsLarge())//got large power up
            {
                scale = 2f;
            }
            Instantiate(ammunition, transform.position + new Vector3(Mathf.Sin(-radians),Mathf.Cos(radians),0)*0.3f, transform.rotation).transform.localScale = new Vector3(scale,scale,1f);//creates bullet infront of player

            if (gameObject.GetComponent<UnitCollision>().IsMulti())//got multishot power up
            {
                Instantiate(ammunition, transform.position + new Vector3(Mathf.Sin(-radians - Mathf.PI/4), Mathf.Cos(radians + Mathf.PI / 4), 0) * 0.3f, Quaternion.Euler(0, 0, rotation+45)).transform.localScale = new Vector3(scale, scale, 1f); ;
                Instantiate(ammunition, transform.position + new Vector3(Mathf.Sin(-radians + Mathf.PI / 4), Mathf.Cos(radians - Mathf.PI / 4), 0) * 0.3f, Quaternion.Euler(0, 0, rotation-45)).transform.localScale = new Vector3(scale, scale, 1f); ;
            }
        }
        
		
	}

    void FixedUpdate()
    {   
        //update position and rotation
        radians = rotation / 360 * 2 * Mathf.PI;
        pos.y += Mathf.Cos(radians) * speed;
        pos.x += Mathf.Sin(-radians) * speed;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, rotation); 
        speed *= 0.95f;

    }

    public void Bounce()//if hits an object
    {
        speed = -speed;
        collided = true;
    }

    public void Stop()//if travelling through object
    {
        speed = 0;
        collided = true;
    }

    public void Free()//if free from colliion
    {
        collided = false;
    }

}
