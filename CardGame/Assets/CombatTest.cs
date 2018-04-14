using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Classes;
using CardGame.Cards;

public class CombatTest : MonoBehaviour {

	Character player {get;set;}
	Character target {get;set;}

	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		player = new Warrior();
		target = new Warrior();

		var testStrike = new Strike();

		player.CastCard(testStrike, target);
		
		Debug.Log("End");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
