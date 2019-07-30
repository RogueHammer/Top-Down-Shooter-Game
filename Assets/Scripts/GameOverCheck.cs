using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCheck : MonoBehaviour {

    public GameObject canvas;
    public Text text;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject[] Enemies;



	// Use this for initialization
	void Start () {

        canvas.SetActive(false);
		
	}
	

	void FixedUpdate () {
        if((Enemies[0] != null || Enemies[1] != null) && Player1 == null && Player2 == null)//if enemies are alive and players have died
        {
            text.text = "Bad Luck!\n The enemies have won.";
            canvas.SetActive(true);
        }
        if (Enemies[0] == null && Enemies[1] == null && Player1 != null && Player2 == null)//if player 1 only one alive
        {
            text.text = "Congratulations Player 1!\n You've won.";
            canvas.SetActive(true);
        }
        if (Enemies[0] == null && Enemies[1] == null && Player1 == null && Player2 != null)//if player 2 only one alive
        {
            text.text = "Congratulations Player 2!\n You've won.";
            canvas.SetActive(true);
        }
        if (Enemies[0] == null && Enemies[1] == null && Player1 == null && Player2 == null)//if all died
        {
            text.text = "A tie!\n What?";
            canvas.SetActive(true);
        }



    }
}
