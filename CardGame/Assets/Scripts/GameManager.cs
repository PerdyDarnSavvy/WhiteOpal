using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject playerSprite;
	[SerializeField] private GameObject enemySprite;
	[SerializeField] private Image HPBar;
	[SerializeField] private Canvas canvas;
	[SerializeField] private Text textPrefab;
	[SerializeField] private Image[] HPTabs;
	//[SerializeField] private GameObject 

	// Use this for initialization
	void Start () {
		GameObject newEnemy = Instantiate(enemySprite) as GameObject;
		GameObject newPlayer = Instantiate(playerSprite) as GameObject;
		Canvas playCanvas = Instantiate(canvas) as Canvas;
		newEnemy.transform.position = new Vector2(5, 2);
		playCanvas.transform.position = new Vector2(newPlayer.transform.localPosition.x, newPlayer.transform.position.y);
		MakeHPBars(playCanvas, newPlayer, newEnemy);
		//GameObject newPlayerHP = Instantiate(playerHP) as GameObject;
		//HPLabeler();		
		//newEnemy.rectTransform.SetParent(playCanvas, false);

	}

	// Update is called once per frame
	void Update () {
		
	}

	void HPLabeler (Canvas canvas) {
		Text label = Instantiate<Text>(textPrefab);
        label.rectTransform.SetParent(canvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(transform.localPosition.x, transform.localPosition.z);
        label.text = "100";
	}

	private void MakeHPBars (Canvas canvas, GameObject player, GameObject enemy) {
		Image PlayerHP = Instantiate(HPBar) as Image;
		Image EnemyHP = Instantiate(HPBar) as Image;
		PlayerHP.rectTransform.SetParent(canvas.transform, false);
        PlayerHP.rectTransform.position = new Vector2(player.transform.localPosition.x, (player.transform.localPosition.y - 1.75f));
		EnemyHP.rectTransform.SetParent(canvas.transform, false);
        EnemyHP.rectTransform.position = new Vector2(enemy.transform.localPosition.x, (enemy.transform.localPosition.y - 1.75f));
		
	}

}

 
