using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Cards;
using CardGame.UI;

public class GameManager : Singleton<GameManager> {

	[SerializeField] private Actor playerSprite;
	[SerializeField] private Actor enemySprite;
	[SerializeField] private PercentScale HPBar;
	
	[SerializeField] public Canvas canvas;

	public Actor newPlayer {get;set;}
	public Actor newEnemy {get;set;}

	private int counter1 {get;set;}
	void Start () {
		counter1 = 0;

		newEnemy = Instantiate(enemySprite) as Actor;
		newPlayer = Instantiate(playerSprite) as Actor;
		
		var playerResource = newPlayer.characterStats.GetResource();
		var targetResource = newEnemy.characterStats.GetResource();
	}

	void Update () {
		var playerResource = newPlayer.characterStats.GetResource();

		if(counter1 <= 50) {
			counter1 = counter1 + 1;
		} else {
			counter1 = 0;
			newPlayer.characterStats.CastCard(new Strike(), newEnemy.characterStats);
		}
	}
}

 
