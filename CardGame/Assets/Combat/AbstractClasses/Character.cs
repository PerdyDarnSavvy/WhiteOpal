using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	private Health HP { get; set; }

	// List<Card> Deck { get; set; }

	// Use this for initialization
	public void Start () {
		this.HP = new Health(100);
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	abstract public void CastCard();
}
