using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

	// 最小サイズ
	private float minimum = 1.0f;
	// 拡大縮小スピード
	private float magSpeed = 10.0f;
	// 拡大率
	private float magnification = 0.07f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 雲を拡大縮小
		this.transform.localScale = new Vector3( // transform.localScaleに各軸方向の拡大率を設定する。Vector3はx, y, zの要素
			// Time.timeはゲーム開始からの秒数を取得できる
			this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification,
			// オブジェクト自身の大きさを指定
			this.transform.localScale.y,
			this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification
		);
	}
}
