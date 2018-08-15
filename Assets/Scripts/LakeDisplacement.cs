using UnityEngine;

public class LakeDisplacement : MonoBehaviour
{
    Material mat;

    public Transform startMarker;
    public Transform endMarker;

    public float speed = 0.001f;
    private float startTime, journeyLength;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        var offset = Vector2.Lerp(endMarker.position, startMarker.position, fracJourney);

        mat.SetTextureOffset("_MainTex", offset);
    }
}