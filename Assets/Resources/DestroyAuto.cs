using UnityEngine;
using System.Collections;

public class DestroyAuto : MonoBehaviour {
    public float destrooyInterval = 0.1f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destrooyInterval);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
