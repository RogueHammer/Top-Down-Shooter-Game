using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject ammunition;
       

    private float rotation;
    private float radians;
    private enum Acceleration//used to set direction unit is going in
    {
        forward,
        stop,
        back
    };
    private Acceleration gear;

    public float rotationalSpeed = 1f;
    public float maxSpeed = 0.04f;
    public float fireRate = 0.5f;
    private float speed;
    private float travelCounter;
    private float shootCounter;
    private bool stop;

    private Vector3 pos;
    private Vector3 target;

    // Use this for initialization
    void Start () {
        speed = 0;
        travelCounter = 0;
        shootCounter = 0;
        gear = Acceleration.forward;
        pos = transform.position;
        rotation = transform.rotation.eulerAngles.z;
        stop = false;
    }

    void FixedUpdate()
    {
        //determine which player is closer
        if(Player1 == null && Player2 == null)//if both players dead unit stops chasing anything
        {
            stop = true;
        }
        else if (Player1 == null)//if player 2 dead, chase player 1
        {
            target = Player2.GetComponent<Transform>().position;
        }
        else if (Player2 == null)//if player 1 dead, chase player 2
        {
            target = Player1.GetComponent<Transform>().position;
        }
        //else chase closest enemy
        else if (Vector3.Distance(Player1.GetComponent<Transform>().position, transform.position)<=Vector3.Distance(Player2.GetComponent<Transform>().position, transform.position))
        {
            target = Player1.GetComponent<Transform>().position;//player 1 is closer
        }
        else
        {
            target = Player2.GetComponent<Transform>().position;//player 2 is closer
        }

        if (!stop)//if game not over
        {
            //determine which direction to turn towards enemy
            radians = rotation / 360 * 2 * Mathf.PI;
            float targetRadians = Mathf.Atan2(pos.x - target.x, target.y - pos.y);
            if ((targetRadians - radians > 0 && targetRadians - radians <= Mathf.PI) || targetRadians - radians <= -Mathf.PI)//rotate anti-clockwaise
            {
                rotation += rotationalSpeed;
                if (rotation >= 181)
                {
                    rotation = -179;
                }
            }
            else if (targetRadians - radians < 0 || targetRadians - radians > Mathf.PI)//rotate clockwise
            {
                rotation -= rotationalSpeed;
                if (rotation <= -180)
                {
                    rotation = 180;
                }
            }
            transform.rotation = Quaternion.Euler(0, 0, rotation);

            //determine if enemy in shooting arc
            shootCounter += Time.deltaTime;
            if (targetRadians - radians >= -Mathf.PI / 4 && targetRadians - radians <= Mathf.PI / 4 && shootCounter > fireRate)//enemy in arc and shoot delay has passed
            {
                Instantiate(ammunition, transform.position + new Vector3(Mathf.Sin(-radians), Mathf.Cos(radians), 0) * 0.5f, transform.rotation);//creates bullet infront of enemy
                shootCounter = 0;
            }


            //determine movement
            float deltaS = Time.deltaTime;
            travelCounter += Time.deltaTime;

            switch (gear)//switch gears after set delay
            {
                case Acceleration.forward:
                    speed = Mathf.Min(maxSpeed, speed + deltaS);
                    if (travelCounter > 3)
                    {
                        switchGears();
                        travelCounter = 0;
                    }
                    break;
                case Acceleration.stop:
                    speed *= 0.9f;

                    if (travelCounter > 4)
                    {
                        switchGears();
                        travelCounter = 0;
                    }
                    break;
                case Acceleration.back:
                    speed = Mathf.Max(-maxSpeed, speed - deltaS);
                    if (travelCounter > 2)
                    {
                        switchGears();
                        travelCounter = 0;
                    }
                    break;
            }

            //update position and rotation
            radians = rotation / 360 * 2 * Mathf.PI;
            pos.y += Mathf.Cos(radians) * speed;
            pos.x += Mathf.Sin(-radians) * speed;
            transform.position = pos;
            
        }

        
        
    }


    private void switchGears()//randomly set next movement cycle
    {
        int number = (int)(Random.value * 6);
        if (number < 3)
        {
            gear = Acceleration.forward;
        }
        else if (number < 5)
        {
            gear = Acceleration.stop;
        }
        else
        {
            gear = Acceleration.back;
        }
    }

}
