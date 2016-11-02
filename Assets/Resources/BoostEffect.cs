using UnityEngine;
using System.Collections;

public class BoostEffect : MonoBehaviour {

    public GameObject light;
    Light boostLight;

    // Use this for initialization
    void Start () {
        light.SetActive(false);
        boostLight = light.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Boost") || Input.GetButton("Jump")) {
            light.SetActive(true);

            if (Input.GetButton("Boost") && Input.GetButton("Jump")) {
                boostLight.range = 100;
            } else {
                boostLight.range = 2;
            }
        } else {
            light.SetActive(false);
        }
	}
}
