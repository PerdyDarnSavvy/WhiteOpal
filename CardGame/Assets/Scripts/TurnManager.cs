using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : Singleton<TurnManager> {

// Game states: 0=disabled, 1=active.
//private bool gameState;
public bool isPlayerTurn { get; set; }
private int turnTimer = 0;

void Start() {
	isPlayerTurn = true;
}

void Update () {
		
//	if (isPlayerTurn == false) {
//		playerController.currentState = PlayerSelectionState.Disabled;
//	} else {
//		playerController.currentState = PlayerSelectionState.SelectCard;
//    }

}

private void FixedUpdate() {
	if (isPlayerTurn == false) {
		turnTimer++;
		if (turnTimer >= 100) {
			PassTurn();
			Debug.Log("Turn passed via timer");
			turnTimer = 0;
		}
	}
}

public void OnClick() {
	PassTurn();
}

private void PassTurn() {
	if (isPlayerTurn == false) {
		isPlayerTurn = true;
		GameManager.Instance.playerController.StartTurn();
		Debug.Log("player turn is " + isPlayerTurn);
	} else {
		isPlayerTurn = false;
		GameManager.Instance.playerController.EndTurn();
		Debug.Log("player turn is " + isPlayerTurn);
	}
}

}
