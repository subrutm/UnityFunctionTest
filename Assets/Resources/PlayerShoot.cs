using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject shot;
    public GameObject muzzle;
    public GameObject muzzleFlash;

    float shotInterval;
    public float shotIntervalMax;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")) {
//            Debug.Log(name + "Position: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
//            Debug.Log(name + "Rotation: " + transform.rotation.w + ", " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);

            shotInterval += Time.deltaTime;

            if (shotInterval >= shotIntervalMax) {
                // 武器の位置から発射/カメラの方向に合わせる
                Instantiate(shot, muzzle.transform.position, Camera.main.transform.rotation);
                shotInterval = 0;
                Instantiate(muzzleFlash, muzzle.transform.position, transform.rotation);
            }
        }
    }
}
