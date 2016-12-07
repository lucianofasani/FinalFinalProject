using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject focus;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	// Use this for initialization
	void Start () {
       // focus = GameObject.FindGameObjectWithTag("focus");
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x , focus.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, focus.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }

    }
}
