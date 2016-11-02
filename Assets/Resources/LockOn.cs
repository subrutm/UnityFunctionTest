using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockOn : MonoBehaviour {

    GameObject target;
    public Image lockonImage;
    public Image enemyHp;
    public Image enemyHpGaugeImage;

    // Use this for initialization
    void Start () {
        // 初期は、非表示
        lockonImage.enabled = false;
        enemyHp.enabled = false;
        enemyHpGaugeImage.enabled = false;
        target = null;
    }
	
	// Update is called once per frame
	void Update () {
        bool isLocked = false;

        if (Input.GetButtonDown("Lock")) {

            if (target != null) {
                // 解除
                target = null;
            } else {
                // ターゲット候補を取得 (今のところは一つだけ)
                target = GameObject.FindWithTag("Enemy");
            }
        }

        if (target != null) {

            GameObject muzzle = GameObject.Find("muzzle");

            // ターゲットの方向へ向ける
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - muzzle.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

            // カメラもターゲットの方向に合わせる
//            Vector3 cameraPos = new Vector3(Camera.main.transform.parent.position.x, muzzle.transform.position.y + 1.0f, Camera.main.transform.position.z);
//            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 6.0f, target.transform.position.z);
            Quaternion cameraRotation = Quaternion.LookRotation(target.transform.position - Camera.main.transform.parent.position);
            Camera.main.transform.parent.localRotation = Quaternion.Slerp(Camera.main.transform.parent.localRotation, cameraRotation, Time.deltaTime * 10);
            Camera.main.transform.parent.localRotation = new Quaternion(Camera.main.transform.parent.localRotation.x, 0, 0, Camera.main.transform.parent.localRotation.w);

            isLocked = true;

            // ロックオンカーソルのアニメーションと位置調整
//            lockonImage.transform.Rotate(0, 0, Time.deltaTime * 200);
            lockonImage.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);

            // ロック対象の敵の体力の割合をゲージに反映する
            Enemy tmpTarget = target.GetComponent<Enemy>();
            float percentage = tmpTarget.armorPoint / tmpTarget.armorPointMax;
            Debug.Log("tmpTarget.armorPoint: " + percentage.ToString());
            enemyHpGaugeImage.transform.localScale = new Vector3(percentage, 1, 1);
        }

        // ロックカーソルを表示する
        lockonImage.enabled = isLocked;
        enemyHp.enabled = isLocked;
        enemyHpGaugeImage.enabled = isLocked;
    }
}
