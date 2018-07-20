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
	public Boolean isInitialized = false;

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
		listOfActorIDs.Add(GameManager.Instance.newPlayer.ID);
		listOfActorIDs.AddRange(GameManager.Instance.enemies.Select(x => x.ID));
		TurnList = listOfActorIDs.ToArray();
		isInitialized = true;
		Debug.Log(TurnList.Length);
		Debug.Log("Made It!");
	}	

	private void FixedUpdate() {
		if (isInitialized && !isPlayerTurn()) {
			turnTimer++;
			if (turnTimer >= 100) {
				Debug.Log(TurnList);
				PassTurn();
				Debug.Log("Turn passed via timer");
				turnTimer = 0;
			}
		}
	}

	public Boolean isPlayerTurn() {
		
		return TurnList[currentTurn] == GameManager.Instance.newPlayer.ID; 
	}

	public void OnClick() {
		PassTurn();
	}

	private void PassTurn() {

		Debug.Log(TurnList[currentTurn]);

		if (isPlayerTurn()) {
			GameManager.Instance.playerController.EndTurn();
		} 

		currentTurn++;
		if (currentTurn >= TurnList.Length){
			currentTurn = 0;
		}	
		
		if (isPlayerTurn()) {
			GameManager.Instance.playerController.StartTurn();
		}
	}

}
