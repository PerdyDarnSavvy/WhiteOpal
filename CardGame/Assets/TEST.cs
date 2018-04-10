using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	private int health = 100;
	private int damage = 10;
	
	private int DamageHero (int damage) {
	
		health -= damage;
		return health;
		
	}	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DamageHero(damage);
	}
}
