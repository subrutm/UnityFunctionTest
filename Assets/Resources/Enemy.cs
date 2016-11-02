using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    GameObject target;

    public GameObject shot;
    float shotInterval = 0.0f;
    float shotIntervalMax = 1.0f;
    float attackDistance = 30.0f;
//    float initScale = 0.1f;

    public float armorPoint = 0.0f;
    public float armorPointMax = 0.0f;
    float damage = 100.0f;

    /// <summary>
    /// 爆発演出
    /// </summary>
    public GameObject exprosion;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("PlayerTarget");
        armorPoint = armorPointMax;
    }

    // Update is called once per frame
    void Update()
    {
        // 一定の距離に近づいたら
        if (Vector3.Distance(target.transform.position, transform.position) < attackDistance)
        {
            // ターゲットの方向を見る
            transform.LookAt(target.transform);
            shotInterval += Time.deltaTime;

            // 攻撃間隔
            if (shotInterval > shotIntervalMax) {
                Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
                shotInterval = 0.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collid) {

        if (collid.gameObject.tag == "shot") {
            // ダメージ量分をマイナスする
            armorPoint -= damage;
            Debug.Log("Enemy Life: " + armorPoint.ToString());

            // 体力が0以下なら
            if (armorPoint <= 0) {
                // 機体を破壊する
                Destroy(gameObject);
                Instantiate(exprosion, transform.position, transform.rotation);
            }
        }
    }
}
