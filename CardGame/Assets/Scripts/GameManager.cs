using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	[SerializeField] private GameObject playerSprite;
	[SerializeField] private GameObject enemySprite;
	[SerializeField] private Image HPBar;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Text textPrefab;
	public List<Actor> PlayerList = new List<Actor>();
	public List<Actor> EnemyList = new List<Actor>();
	public List<Actor> AllyList = new List<Actor>();
	//[SerializeField] private GameObject 

	void Start () {
		GameObject newEnemy = Instantiate(enemySprite) as GameObject;
		Actor enemy1 = new Actor(ActorType.enemy);
		GameObject newPlayer = Instantiate(playerSprite) as GameObject;
		Actor player1 = new Actor(ActorType.player);
		Canvas playCanvas = Instantiate(canvas) as Canvas;
		
		playCanvas.transform.position = new Vector2(newPlayer.transform.localPosition.x, newPlayer.transform.position.y);
		MakeHPBars(playCanvas, newPlayer, newEnemy);
		//hideTab(11);
	}

	void Update () {

	}

	public void RegisterActor(Actor actor) {
		if (actor.Type == ActorType.minion) {
			AllyList.Add(actor);
		} else if (actor.Type == ActorType.player) {
			PlayerList.Add(actor);
		} else {
			EnemyList.Add(actor);
		}
		
	}

	private void MakeHPBars (Canvas canvas, GameObject player, GameObject enemy) {
		Image PlayerHP = Instantiate(HPBar) as Image;
		Image EnemyHP = Instantiate(HPBar) as Image;
		PlayerHP.rectTransform.SetParent(canvas.transform, false);
        PlayerHP.rectTransform.position = new Vector2(player.transform.localPosition.x, (player.transform.localPosition.y - 1.75f));
		EnemyHP.rectTransform.SetParent(canvas.transform, false);
        EnemyHP.rectTransform.position = new Vector2(enemy.transform.localPosition.x, (enemy.transform.localPosition.y - 1.75f));
	}

	private void hideTab(int i) {

	}

}

 
