using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
	// スコア初期化
	private int score = 0;
	// スコアを表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		// シーン中のオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		this.scoreText.GetComponent<Text>().text = score.ToString();
	}
}
