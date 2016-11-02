using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (animator) {
//            Debug.Log("PlayerMotion: " + Input.GetAxis("Horizontal").ToString());

            // 右移動時のモーション
            if (Input.GetAxis("Horizontal") > 0) {
                animator.SetInteger("Horizontal_r", 1);
            } else {
                animator.SetInteger("Horizontal_r", 0);
            }

            // 左移動時のモーション
            if (Input.GetAxis("Horizontal") < 0) {
                animator.SetInteger("Horizontal_l", 1);
            } else {
                animator.SetInteger("Horizontal_l", 0);
            }

            // 前進時のモーション
            if (Input.GetAxis("Vertical") > 0) {
                animator.SetInteger("Vertical_a", 1);
            } else {
                animator.SetInteger("Vertical_a", 0);
            }

            // 後退時のモーション
            if (Input.GetAxis("Vertical") < 0) {
                animator.SetInteger("Vertical_b", 1);
            } else {
                animator.SetInteger("Vertical_b", 0);
            }

            // ジャンプ時のモーション
            if (Input.GetAxis("Jump") > 0) {
                animator.SetInteger("Jump", 1);
            } else {
                animator.SetInteger("Jump", 0);
            }

            animator.SetBool("Boost", Input.GetButton("Boost"));
        }
	}
}
