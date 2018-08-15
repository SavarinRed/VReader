using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TestManager : MonoBehaviour
{
    private List<GameObject> cameras;
    private GameObject currentCamera;
    private bool canSwitch = true;
    [SerializeField] private CanvasGroup texts;
    [SerializeField] private GameObject lake;
    [SerializeField] private AudioMixer audioMixer;

    //- Variables touch movement
    //private int touchSensitiveHorizontal = 8, touchSensitiveVertical = 4;
    //private Vector2 previousUnitPosition = Vector2.zero, direction = Vector2.zero;

    private void Awake()
    {
        var tmp = FindObjectsOfType<Camera>();
        cameras = new List<GameObject>();
        for (int i = 0; i < tmp.Length; i++)
            cameras.Add(tmp[i].gameObject);
        currentCamera = cameras[0];
        ChangeSpot();
    }

#if !UNITY_ANDROID && !UNITY_IPHONE
    void Start()
    {
        Cursor.visible = false;
    }
#endif

    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        //android input
#else
        SwitchCameraSpot(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.S)) texts.alpha = texts.alpha == 0 ? 1 : 0;
        if (Input.GetKeyDown(KeyCode.W)) lake.SetActive(!lake.activeSelf);
        if (Input.GetKeyDown(KeyCode.M))
        {
            float volume;
            audioMixer.GetFloat("Volume", out volume);
            print(volume);
            audioMixer.SetFloat("Volume", volume == -80 ? 0 : -80);
        }
#endif
    }

    void SwitchCameraSpot(float axis)
    {
        if (axis == 0 || !canSwitch) return;

        int aux;
        if (axis > 0)
        {
            aux = cameras.IndexOf(currentCamera) + 1;
            currentCamera = cameras[aux > cameras.Count - 1 ? 0 : aux];
        }
        else
        {
            aux = cameras.IndexOf(currentCamera) - 1;
            currentCamera = cameras[aux < 0 ? cameras.Count - 1 : aux];
        }
        ChangeSpot();
        StartCoroutine(SwitchTimer());
    }

    IEnumerator SwitchTimer()
    {
        canSwitch = false;
        yield return new WaitForSeconds(.5f);
        canSwitch = true;
        yield break;
    }

    void ChangeSpot()
    {
        for (int i = 0; i < cameras.Count; i++)
            cameras[i].SetActive(cameras[i] == currentCamera);
    }
}
