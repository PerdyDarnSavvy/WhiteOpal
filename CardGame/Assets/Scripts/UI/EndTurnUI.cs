using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnUI : MonoBehaviour {

	public void OnClick() {
		TurnManager.Instance.OnClick();
	}
}
