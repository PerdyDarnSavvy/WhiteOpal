using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardGame.Abstract;
using CardGame.Classes;
using CardGame.Cards;
using UnityEngine.UI;

public enum ActorType {
	enemy, player, minion
}

public class Actor : MonoBehaviour {
	
	[SerializeField] 
	public PercentScale HPBar;
	private ActorType type;
	public Character characterStats { get; set; }
	private PercentScale healthBar { get; set; }


	public Actor (ActorType thing) {
		type = thing;
	}

	void Awake () {
		characterStats = new Warrior();
		MakeResourceBar(characterStats.HP, 0);
	}

	void LateUpdate () {
		updateHealthBar();
	}
	
	private void MakeResourceBar (Resource resouce, int counter) {
		healthBar = Instantiate(HPBar) as PercentScale;
		healthBar.transform.SetParent(GameManager.Instance.canvas.transform, false);
        healthBar.transform.position = new Vector2(transform.localPosition.x, (transform.localPosition.y - 1.75f - counter));
	}

	private void updateHealthBar() {
		int newPercent = (int)Mathf.Round(((float)characterStats.HP.GetAmount() / (float)characterStats.HP.GetMaxAmount()) * 100f);
		healthBar.UpdateScale(newPercent);
	}

	// Not yet used, but this will be the next step:
	// We would use this so we can use the same logic to make a "Stamina" bar, and a "Health" bar
	private void MakeResourceBars() {
		List<Resource> resources = characterStats.GetAllResources();
		int counter = 0;
		foreach(var resource in resources) {
			MakeResourceBar(resource, counter);
			counter++;
		}
	}
}