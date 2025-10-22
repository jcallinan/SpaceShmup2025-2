using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen.
/// NOTE: this only works for an orthographic Main Camera
/// 
/// </summary>
public class BoundsCheck : MonoBehaviour
{
    public float camWidth;
    public float camHeight;
    public bool keepOnScreen = true;

    public bool isOnScreen = true;


    private void Awake()
    {
        camHeight= Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        if (pos.x > camWidth)
        {
            pos.x = camWidth;
            isOnScreen = false;
        }
        if (pos.x < -camWidth)
        {
            pos.x = -camWidth;
            isOnScreen = false;
        }
        if (pos.y > camHeight)
        {
            pos.y = camHeight;
            isOnScreen = false;
        }
        if (pos.y < -camHeight)
        {
            pos.y = -camHeight;
            isOnScreen = false;
        }
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }
        
    }
}
