using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Classes;
using CardGame.Cards;
using CardGame.Enums;
using CardGame.Factories;
using CardGame.UI;
using UnityEngine.UI;

public class Actor : MonoBehaviour {
	
	public PercentScale PercentPrefab;
	private ActorType type;
	public Character characterStats { get; set; }
	private List<ResourceUI> ourResources;
	public CardManager CardManager;
	public int ID;
	public ClassType actorClass;
	public RaceType actorRace;

	private AutoBrain AutomatedBrain { get; set; }
	//private List<> OtherBars { get; set; }

	public void Initialize(ActorType type) {
		ID = this.GetInstanceID();
		this.type = type;

		if (type != ActorType.PLAYER) {
			InitAutoActor();
		} else {
			CardManager.DemoInit();
		}
	}

	public void InitAutoActor() {
		Debug.Log("InitAutoActor");
		var cards = CardFactory.GetCards(this.actorClass, this.actorRace);

		AutomatedBrain = this.GetComponent<AutoBrain>();
		AutomatedBrain.Initialize(cards);
	}

	void Awake () {
		characterStats = new Warrior();
		ourResources = new List<ResourceUI>();
		MakeResourceBars();
		CardManager = new CardManager();
	}

	void Update () {
		foreach (var resourceUI in ourResources){
			resourceUI.updateValue();
		}
	}
	
	private void MakeResourceUI (Resource myResource, float counter) {
		var newPercentScale = Instantiate(PercentPrefab) as PercentScale;
		ourResources.Add(new ResourceUI(myResource, this.transform, newPercentScale, counter));
	}

	private void MakeResourceBars() {
		List<Resource> resources = characterStats.GetAllResources();
		float offset = 1.75f;
		foreach(var resource in resources) {
			MakeResourceUI(resource, offset);
			offset += 0.4f;
		}
	}

	public void TakeTurn() {
		Debug.Log("Actor Take Turn");
		if (AutomatedBrain != null) {
			AutomatedBrain.TakeTurn();
		}

		TurnManager.Instance.PassTurn();
	}
}
