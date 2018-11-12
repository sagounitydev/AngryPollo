using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points100Script : MonoBehaviour {

    public int timeToDestroy = 5;

	void Start () {
        Invoke("AutoDestroy", timeToDestroy);
	}

	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime);
	}

    private void AutoDestroy() {
        Destroy(this.gameObject);
    }
}
