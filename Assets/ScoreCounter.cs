using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	// スコアを表示するテキスト
	private GameObject scoreText;
	// スコア
	private int score;

	// Use this for initialization
	void Start () {
		// シーン中のオブジェクトを取得
		scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		// ボールが星・雲に当たった時の得点
		switch(other.gameObject.tag) {
		case "SmallStarTag":
			score += 10;
			Debug.Log("Collied to Small Star(+10pt). Score:" + score);
			break;
		case "LargeStarTag":
			score += 30;
			Debug.Log("Collied to Large Star(+30pt). Score:" + score);
			break;
		case "SmallCloudTag":
			score += 20;
			Debug.Log("Collied to Small Cloud(+20pt). Score:" + score);
			break;
		case "LargeCloudTag":
			score += 50;
			Debug.Log("Collied to Large Cloud(+50pt). Score:" + score);
			break;
		default:
			Debug.Log("Collied to something.");
			break;
		}

		// int型をString変換
		string scoreString = score.ToString();
		// テキストを表示
		scoreText.GetComponent<Text>().text = scoreString;
		// Debug.Log(scoreString);
		// Debug.Log(gameObject);
	}
}
