using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithoutVRMaterial : MonoBehaviour
{
    public bool change;
    // Use this for initialization
    void Awake()
    {
        if (change)
        {
            var gameObjects = FindObjectsOfType<Transform>();
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i].GetComponent<Renderer>())
                    gameObjects[i].GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            }
        }
    }
}
