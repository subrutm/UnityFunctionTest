using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour {

    public Text blinkText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) {
            //            Application.LoadLevel("Unity");
            SceneManager.LoadScene("Unity");
        }

        blinkText.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1));
    }
}
