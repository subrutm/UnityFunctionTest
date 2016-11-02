using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {

    int armorPoint;
    int dispPoint;
    int damage = 100;
    Color initColor;

    public int armorPointMax = 5000;
    public Text armorHp;
    public Image gaugeImg;

	// Use this for initialization
	void Start () {
        armorPoint = armorPointMax;
        dispPoint = armorPoint;

        initColor = armorHp.color;
    }
	
	// Update is called once per frame                                                                                                                           
	void Update () {
        // ダメージカウントを徐々に減らす処理を追加
        if (dispPoint != armorPoint) {
            dispPoint = (int)Mathf.Lerp(dispPoint, armorPoint, 0.1f);
        }
        armorHp.text = string.Format("PlayerHP {0:0000} / {1:0000}", dispPoint.ToString(), armorPointMax.ToString());

        // 体力の割合によって色を変える
        float percentageForHP = (float)dispPoint / armorPointMax;
        if (percentageForHP > 0.5f) {
            armorHp.color = initColor;
            gaugeImg.color = new Color(0.25f, 0.7f, 0.6f);
        } else if (percentageForHP > 0.3f) {
            armorHp.color = Color.yellow;
            gaugeImg.color = Color.yellow;
        } else if (percentageForHP > 0.0f) {
            armorHp.color = Color.red;
            gaugeImg.color = Color.red;
        }

        // 体力の割合に合わせてゲージを減らす
        gaugeImg.transform.localScale = new Vector3(percentageForHP, 1, 1);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "shotEnemy") {
            armorPoint -= damage;
            armorPoint = Mathf.Clamp(armorPoint, 0, armorPointMax);
        }
    }
}
