using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Classes;
using CardGame.Cards;
using CardGame.UI;
using UnityEngine.UI;

public enum ActorType {
	enemy, player, minion
}

public class Actor : MonoBehaviour {
	
	public PercentScale PercentPrefab;
	private ActorType type;
	public Character characterStats { get; set; }
	private List<ResourceUI> ourResources;
	public CardManager CardManager;
	//private List<> OtherBars { get; set; }

	public Actor (ActorType thing) {
		type = thing;
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
		float counter = 1.75f;
		foreach(var resource in resources) {
			MakeResourceUI(resource, counter);
			counter += 0.4f;
		}
	}
}
