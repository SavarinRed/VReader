using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPos : MonoBehaviour {
    [SerializeField] Transform pos;
	void Start () {
        transform.position = pos.position;
	}
}
