﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Classes;
using CardGame.Cards;
using UnityEngine.UI;

public enum ActorType {
	enemy, player, minion
}

public class Actor : MonoBehaviour {

	Character characterStats {get;set;}
	private ActorType type;



	public Actor (ActorType thing) {
		type = thing;
	}
	//Character target {get;set;}

	// Use this for initialization
	void Start () {
		characterStats = new Warrior();
		GameManager.Instance.RegisterActor(this);
	}
	
	public Resource getHP() {
		return characterStats.HP;
	}

	public ActorType Type {
		get { return type; }
	}

}