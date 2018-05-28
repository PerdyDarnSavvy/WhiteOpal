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
	private PercentScale healthBar { get; set; }
	private List<ResourceUI> ourResources;
	private CardManager CardManager;
	//private List<> OtherBars { get; set; }

	public Actor (ActorType thing) {
		type = thing;
	}

	void Awake () {
		characterStats = new Warrior();
		ourResources = new List<ResourceUI>();
		MakeResourceBars();
		Debug.Log("Starting Card Manager . . .");
		CardManager = new CardManager();
	}

	void Update () {
		//updateHealthBar();
		foreach (var resourceUI in ourResources){
			resourceUI.updateValue();
		}
	}
	
	private void MakeResourceUI (Resource myResource, float counter) {
		var newPercentScale = Instantiate(PercentPrefab) as PercentScale;
		ourResources.Add(new ResourceUI(myResource, this.transform, newPercentScale, counter));
	}

	// private void MakeResourceBar (Resource resouce, int counter) {

	// 	var VariableBar = healthBar.transform.Find("Container");
	// 	var BarFront = VariableBar.Find("BarFront");
	// 	var BarSprite = BarFront.GetComponent<SpriteRenderer>();
	// 	BarSprite.sortingLayerID -= counter;
	// 	healthBar.SetType(counter);
	// 	//var otherBar = Instantiate(HPBar) as PercentScale;
	// 	//otherBar.transform.SetParent(GameManager.Instance.canvas.transform, false);
	// 	//otherBar.transform.position = new Vector2(transform.localPosition.x, (transform.localPosition.y - 1.85f));
	// 	//otherBar.SetType(7);
	// }

	// private void updateHealthBar() {
	// 	int newPercent = (int)Mathf.Round(((float)characterStats.HP.GetAmount() / (float)characterStats.HP.GetMaxAmount()) * 100f);
	// 	healthBar.UpdateScale(newPercent);
	// }

	// // Not yet used, but this will be the next step:
	// // We would use this so we can use the same logic to make a "Stamina" bar, and a "Health" bar
	private void MakeResourceBars() {
		List<Resource> resources = characterStats.GetAllResources();
		float counter = 1.75f;
		foreach(var resource in resources) {
			MakeResourceUI(resource, counter);
			counter += 0.4f;
		}
	}
}
