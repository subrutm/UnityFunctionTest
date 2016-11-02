using UnityEngine;
using System.Collections;

public class BurretEnemy : MonoBehaviour {

    public GameObject explosion;
//    float attackDuration = 0.0f;
//    float attackDurationMax = 1.0f;

    // Use this for initialization
    void Start () {
        // 2.5秒後に破棄する
        Destroy(gameObject, 4.5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * 100;
	}
    
    private void OnCollisionEnter(Collision collid) {
//        Debug.Log("OnCollisionEnter: " + collid.gameObject.name);

        // 地形に衝突したら、弾オブジェクトを破棄する
        if (collid.gameObject.name == "Terrain" || collid.gameObject.tag == "Player") {
            Destroy(gameObject);

            // パーティクルモーション
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
