using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Cards;
using CardGame.UI;

public class GameManager : Singleton<GameManager> {

    [SerializeField] private CardUI CardUIPrefab;
    [SerializeField] private TargetableOverlay TargetableOverlayPrefab;
	[SerializeField] private CardZoneUI CardZoneUIPrefab;
	[SerializeField] private Button EndTurnPrefab;
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
		SetupTurnManager();
		CreatePlayerController();
	}

	public void CreatePlayer() {
		newPlayer = Instantiate(playerSprite) as Actor;
		newPlayer.Initialize();
	}
	
	public void CreateEnemies() {
		var numberOfEnemies = 2;
		var scaleFactor = (1f / (float)numberOfEnemies) + 0.25f;
		for (int i = 0; i < numberOfEnemies; i++) {
			var newEnemy = CreateEnemy();
			newEnemy.Initialize();
			newEnemy.transform.position = new Vector2(newEnemy.transform.position.x + (3f * i) - 2f, newEnemy.transform.position.y);
			newEnemy.transform.localScale = new Vector3(newEnemy.transform.localScale.x * scaleFactor, newEnemy.transform.localScale.y * scaleFactor, newEnemy.transform.localScale.z);
			enemies.Add(newEnemy);
		}
	}

	public void SetupTurnManager() {
		TurnManager.Instance.SetTurnList();
	}

	public void StartTurn() {
		newPlayer.CardManager.DrawHand();
		playerController.currentState = PlayerSelectionState.SelectCard;
	}

	public void EndTurn() {
		newPlayer.CardManager.DiscardHand();
		playerController.DestroyPlayerHand();
		playerController.currentState = PlayerSelectionState.Disabled;
	}

	public Actor CreateEnemy() {
		return Instantiate(enemySprite) as Actor;
	}

	public void CreatePlayerController() {
		playerController = new PlayerController(newPlayer, enemies, CardUIPrefab, CardZoneUIPrefab, TargetableOverlayPrefab, EndTurnPrefab);
	}

	public void DestroyCardObject(CardUI objectToDestroy) {
		Destroy(objectToDestroy);
	}
}

 
