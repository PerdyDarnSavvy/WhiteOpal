using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Image HPBar;

	// Use this for initialization
	public void MakeHPBars () {
		Image PlayerHP = Instantiate(HPBar) as Image;
		Image EnemyHP = Instantiate(HPBar) as Image;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
