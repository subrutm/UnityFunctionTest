using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour {
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("azalea");
    }
	
	// Update is called once per frame
	void Update () {
        // プレイヤー機の回転とメインカメラの回転を同期する
        player.transform.Rotate(0, Input.GetAxis("Horizontal3"), 0);
        Camera.main.transform.parent.gameObject.transform.Rotate(Input.GetAxis("Horizontal2"), 0, 0);
    }
}
