using System.Collections;
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

			foreach (Touch n in Input.touches) {
				var id = n.fingerId; // タッチした指のID

				switch(n.phase) {
					case TouchPhase.Began: // タッチした時
						var touchPositionX = Input.touches[id].position.x; // タッチのx座標

						// 画面の左半分をタップした時、左フリッパーを動かす
						if (touchPositionX < Screen.width / 2 && tag == "LeftFripperTag") {
							Debug.LogFormat("{0}:左側をタッチ", id);
							SetAngle (this.flickAngle);
						}
						// 画面の右半分をタップした時、右フリッパーを動かす
						if (touchPositionX > Screen.width / 2 && tag == "RightFripperTag") {
							// var rightFripper = tag == "RightFripperTag";
							Debug.LogFormat("{0}:右側をタッチ", id);
							SetAngle (this.flickAngle);
						}
						break;
					
					case TouchPhase.Ended: // 画面から指が離れた時
						Debug.LogFormat("{0}:離した", id);
						// フリッパーを元に戻す
						SetAngle (this.defaultAngle);
						break;
				}
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
