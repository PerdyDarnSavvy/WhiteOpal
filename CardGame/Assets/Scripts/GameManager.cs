using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Cards;
using CardGame.UI;

public class GameManager : Singleton<GameManager> {

    [SerializeField] private CardUI CardUIPrefab;
    [SerializeField] private TargetableOverlay TargetableOverlayPrefab;
	[SerializeField] private Actor playerSprite;
	[SerializeField] private Actor enemySprite;
	
	[SerializeField] public Canvas canvas;

	public Actor newPlayer { get; set; }
	public List<Actor> enemies { get; set; }
	public Actor newEnemy { get; set; }
	public PlayerController playerController { get; set; }

	void Start () {
		enemies = new List<Actor>();
		CreatePlayer();
		CreateEnemies();
		CreatePlayerController();
	}

	void Update () {
	}

	public void CreatePlayer() {
		newPlayer = Instantiate(playerSprite) as Actor;
	}
	
	public void CreateEnemies() {
		enemies.Add(CreateEnemy());
	}

	public Actor CreateEnemy() {
		return Instantiate(enemySprite) as Actor;
	}

	public void CreatePlayerController() {
		playerController = new PlayerController(newPlayer, enemies, CardUIPrefab, TargetableOverlayPrefab);
	}
}

 
