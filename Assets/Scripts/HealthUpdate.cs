using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpdate : MonoBehaviour {

    public GameObject unit;
    private int health;
    public GameObject[] pip;
    public Sprite healthSprite;
    public Sprite damageSprite;
    public GameObject deathFrames;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = unit.transform.position;
        health = unit.GetComponent<UnitCollision>().GetHealth();//displays health and damage above unit
        for(int i=0; i<5; i++)
        {
            if (i < health)
            {
                pip[i].GetComponent<SpriteRenderer>().sprite = healthSprite;
            }
            else
            {
                pip[i].GetComponent<SpriteRenderer>().sprite = damageSprite;
            }
        }
        if (health ==0)//if health 0, destroy unit
        {
            Instantiate(deathFrames, unit.GetComponent<Transform>().position, unit.GetComponent<Transform>().rotation);
            Destroy(unit);
            Destroy(gameObject);
        }
		
	}
}
