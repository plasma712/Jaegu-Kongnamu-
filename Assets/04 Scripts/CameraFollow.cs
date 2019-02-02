using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Vector2 veloctiy;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    public bool bounds;

    public Vector3 minCameraFos;
    public Vector3 maxCameraFos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref veloctiy.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y + 2.5f, ref veloctiy.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraFos.x, maxCameraFos.x),
                Mathf.Clamp(transform.position.y, minCameraFos.y, maxCameraFos.y),
                Mathf.Clamp(transform.position.z, minCameraFos.z, maxCameraFos.z));
        }
    }

    public void SetMinCamPosition()
    {
        minCameraFos = gameObject.transform.position;
    }

    public void SetMaxCamPosition()
    {
        maxCameraFos = gameObject.transform.position;
    }

    // Update is called once per frame	
}