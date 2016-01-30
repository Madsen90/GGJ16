using System;

using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    public int Width;
    public int Height;

    private Vector2 size;
    private GameObject player;

    void Start ()
    {
        size = new Vector2(Width, Height);
        player = GameObject.Find("Player");
    }
    
    void Update ()
    {
        var x = Mathf.Floor((player.transform.position.x + size.x/2) / size.x) * size.x;
        var y = Mathf.Floor((player.transform.position.y + size.y/2) / size.y) * size.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
