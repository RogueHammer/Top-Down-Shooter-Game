using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject[] objects;
    private List<int[]> coords;
    private Vector3 pos;

    // Use this for initialization
    void Start() {
        coords = new List<int[]>();
        //populate array of coordinates
        for (int i = 3; i >= -3; i -= 3)//y position
        {
            for (int j = -6; j <= 6; j += 4)//x posiion
            {
                coords.Add(new int[]{i,j});
            }
        }
        

        for(int i=0; i<objects.Length; i++)//places each object at random,unique position from coordinates list
        {
            pos = objects[i].GetComponent<Transform>().position;
            int index = Random.Range(0, coords.Count);
            pos.x = coords[index][1];
            pos.y = coords[index][0];
            coords.RemoveAt(index);//removes used coordinate from list
            objects[i].GetComponent<Transform>().position = pos;
            objects[i].GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Random.Range(180f, -180f));
        }

        Destroy(gameObject);//destroy generator once done
    }

}
