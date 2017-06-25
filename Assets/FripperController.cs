﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	// HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	// 初期傾き
	private float defaultAngle = 20;
	// 弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		// オブジェクトにアタッチしているHingeJointコンポーネントを取得（スクリプトでフリッパーを動かすため）
		// GetComponent<取得したいコンポーネント>
		this.myHingeJoint = GetComponent<HingeJoint>();

		// フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
		
		// 左矢印キーで左フリッパーを動かす
		// Input.GetKeyDownは引数のキーが押された時にtrueを返す
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		// 右矢印キーで右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		// 矢印キーが離されたらフリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		// タッチでフリッパーを動かす
		// Input.touches ですべてのタッチ情報のオブジェクトリストを返すので、これを使う
		if (Input.touches.Length != 0) { // タッチ情報がある時
			if (Input.touches[0].phase == TouchPhase.Began) {
				// タッチした時フリッパーを動かす
				Debug.Log("Touch position:" + Input.touches[0].position);
				// TODO: 画面の右半分をタップした時は右フリッパー、左半分をタップした時は左を動かす
				var touchPositionX = Input.touches[0].position.x;
				if (touchPositionX < Screen.width / 2 && tag == "LeftFripperTag") { // 画面の左半分をタップした時、かつ左フリッパー
					Debug.Log("Touch Left side");
					SetAngle (this.flickAngle);
				} if (touchPositionX > Screen.width / 2 && tag == "RightFripperTag") { // 画面の右半分をタップした時、かつ右フリッパー
					// var rightFripper = tag == "RightFripperTag";
					Debug.Log("Touch Right side");
					SetAngle (this.flickAngle);
				}
			}
			if (Input.touches[0].phase == TouchPhase.Ended) {
				// 画面から指が離れた時フリッパーを元に戻す
				SetAngle (this.defaultAngle);
			}
		}
	}

	// フリッパーの傾きを設定
	public void SetAngle (float angle) {
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
