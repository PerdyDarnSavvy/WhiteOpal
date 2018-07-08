using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardGame.Abstract;
using CardGame.Other;

public class CardZoneUI : MonoBehaviour {

	private CardZone Zone { get; set; }

	[SerializeField]
	public Text Count;

	[SerializeField]
	public Text ZoneName;

	public PlayerController PlayerController { get; set; }

	public void Initialize(CardZone zone, string name) {
		Zone = zone;
		UpdateCounter();		
		ZoneName.text = name;
	}

	public void UpdateCounter() {
		Count.text = Zone.Count().ToString();
	}

	void Update() {
		UpdateCounter();
	}
}
