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
		player = new Zealot();
		target = new Warrior();

		var playerResource = player.GetResource();
		var targetResource = target.GetResource();
		
		// player.CastCard(new Strike(), target);
		// Debug.Log(playerResource.Name + ": " + playerResource.GetAmount() + " / " + playerResource.GetMaxAmount());
		// player.CastCard(new ViciousVigor(), target);
		// Debug.Log(playerResource.Name + ": " + playerResource.GetAmount() + " / " + playerResource.GetMaxAmount());
		// player.CastCard(new ViciousVigor(), target);
		// Debug.Log(playerResource.Name + ": " + playerResource.GetAmount() + " / " + playerResource.GetMaxAmount());
		// player.CastCard(new Respite(), target);
		// Debug.Log(playerResource.Name + ": " + playerResource.GetAmount() + " / " + playerResource.GetMaxAmount());

		
		// Debug.Log("Player Status:");
		// Debug.Log(player.HP.Name + ": " + player.HP.GetAmount() + " / " + player.HP.GetMaxAmount());
		// //Debug.Log(playerResource.Name + ": " + playerResource.GetAmount() + " / " + playerResource.GetMaxAmount());
		
		// Debug.Log("Target Status:");
		// Debug.Log(target.HP.Name + ": " + target.HP.GetAmount() + " / " + target.HP.GetMaxAmount());
		// Debug.Log(targetResource.Name + ": " + targetResource.GetAmount() + " / " + targetResource.GetMaxAmount());

		// Debug.Log("End");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
