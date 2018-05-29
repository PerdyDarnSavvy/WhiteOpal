using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetableOverlay : MonoBehaviour {

	public Actor Actor { get; set; }
	public PlayerController PlayerController { get; set; }

	public void Initialize(Actor Actor, PlayerController PlayerController) {
		this.Actor = Actor;
		this.PlayerController = PlayerController;
	}
	
	public void OnClick() {
		PlayerController.TargetClicked(Actor);
	}
}
