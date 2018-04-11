using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	Health Health { get; set; }

	// List<Card> Deck { get; set; }

	// Use this for initialization
	public void Start () {
		Health = new Health(100);
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	abstract public void CastCard();
}
