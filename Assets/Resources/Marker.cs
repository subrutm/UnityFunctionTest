using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Marker : MonoBehaviour
{

    Image marker;                   // 敵マーカーのインスタンス
    public Image makerImg;          // マーカーの絵
    GameObject compass;             // コンパス画像オブジェクト
    GameObject player;              // プレイヤー

//    float enableDistanceMax = 150.0f;  // レーダーに表示する距離

    // Use this for initialization
    void Start() {
        compass = GameObject.Find("CompassMask");
        player = GameObject.Find("PlayerTarget"); // 敵が見ている位置

        marker = Instantiate(makerImg, compass.transform.position, Quaternion.identity) as Image;
        marker.transform.SetParent(compass.transform, false);
    }

    // Update is called once per frame
    void Update() {
        // ターゲット機との相対距離にマーカーを配置する
        Vector3 Position = transform.position - player.transform.position;
        marker.transform.localPosition = new Vector3(Position.x, Position.z, 0);
    }

    void OnDestroy() {
        Destroy(marker);
    }
}
