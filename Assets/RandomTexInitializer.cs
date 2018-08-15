using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexInitializer : MonoBehaviour {

    public bool GetRandomTexOnAwake = false;

	void Awake () {
        if (GetRandomTexOnAwake) {
            GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
        }
	}

}
