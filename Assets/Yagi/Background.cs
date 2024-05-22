using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Background : MonoBehaviour
{
    [SerializeField]
    float scrollspeed = -1;

    Vector3 CameraRectMin;
    // Start is called before the first frame update
    void Start()
    {
        //ƒJƒƒ‰‚Ì”ÍˆÍ‚ğæ“¾
        CameraRectMin = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * scrollspeed * Time.deltaTime);
        if(transform.position.x<
            (CameraRectMin.x - 
            Camera.main.transform.position.x)*2)
        {
            transform.position = new
                Vector2((Camera.main.transform.position.x
                - CameraRectMin.x) * 2,
                transform.position.y);
        }
    }
}
