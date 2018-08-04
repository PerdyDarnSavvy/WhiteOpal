using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : Singleton<TurnManager> {

	private int turnTimer = 0;
	public int[] TurnList;
	public int currentTurn = 0;
	public bool isInitialized = false;
	private bool skipEnemy = false;

	void Start() {
	}

	void Update () {
			
	//	if (isPlayerTurn == false) {
	//		playerController.currentState = PlayerSelectionState.Disabled;
	//	} else {
	//		playerController.currentState = PlayerSelectionState.SelectCard;
	//    }

	}

	public void SetTurnList(){
		var listOfActorIDs = new List<int>();
		listOfActorIDs.Add(GameManager.Instance.Player.ID);
		listOfActorIDs.AddRange(GameManager.Instance.enemies.Select(x => x.ID));
		TurnList = listOfActorIDs.ToArray();
		isInitialized = true;
	}	

	private void FixedUpdate() {
		if (isInitialized && !isPlayerTurn() && skipEnemy) {
			turnTimer++;
			if (turnTimer >= 100) {
				PassTurn();
				turnTimer = 0;
			}
		}
	}

	public bool isPlayerTurn() {
		return TurnList[currentTurn] == GameManager.Instance.Player.ID; 
	}

	public void OnClick() {
		PassTurn();
	}

	public void PassTurn() {
		if (isPlayerTurn()) {
			GameManager.Instance.playerController.EndTurn();
		} 

		currentTurn++;
		if (currentTurn >= TurnList.Length){
			currentTurn = 0;
		}

		StartTurn();
	}

	public void StartTurn() {
		if (isPlayerTurn()) {
			GameManager.Instance.playerController.StartTurn();
		}
		else {
			var actingActor = GetActingActor();
			if (actingActor != null && !skipEnemy) {
				actingActor.TakeTurn();
			}
		}
	}

	private Actor GetActingActor() {
		return GameManager.Instance.enemies.FirstOrDefault(x => x.ID == TurnList[currentTurn]);
	}
}
