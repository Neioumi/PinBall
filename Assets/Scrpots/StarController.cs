using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	// 回転速度
	private float rotSpeed = 1.0f; // float型の変数に値を代入する時は最後にfが必要

	// Use this for initialization
	void Start () {
		// 回転開始の角度を設定
		this.transform.Rotate(0, Random.Range(0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () {
		// 回転
		this.transform.Rotate(0, this.rotSpeed, 0); // Rotate関数の引数は、X, Y, Z軸を中心とした回転量
	}
}
