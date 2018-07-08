using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Abstract;

public class CardUI : MonoBehaviour {

	public Card Card { get; set; }
	public PlayerController PlayerController { get; set; }

	public void Initialize(Card Card, PlayerController PlayerController) {
		this.Card = Card;
		this.PlayerController = PlayerController;

		var NameText = this.transform.Find("Name").GetComponent<Text>();
		NameText.text = Card.Name;
		
		var CostText = this.transform.Find("Cost").GetComponent<Text>();
		CostText.text = "(" + Card.Cost + ")";

		var DescriptionText = this.transform.Find("Description").GetComponent<Text>();
		DescriptionText.text = Card.Name;
	}
	
	public void OnClick() {
		PlayerController.CardClicked(this);
	}

	public void DestroySelf() {
		Destroy(gameObject);
	}
}
