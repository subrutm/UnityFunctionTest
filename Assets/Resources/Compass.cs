using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Compass : MonoBehaviour {

    public Image compassImg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // プレイヤー機のY軸回転に合わせて, 画像をZ軸を中心に回転する
        compassImg.transform.rotation = Quaternion.Euler(compassImg.transform.rotation.x, compassImg.transform.rotation.y, transform.eulerAngles.y);
	}
}
