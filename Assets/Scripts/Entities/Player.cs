using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool hasPushObj = false;
    public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            move += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow))
            move += Vector3.right;
        if (Input.GetKey(KeyCode.UpArrow))
            move += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow))
            move += Vector3.down;
        //if(move != Vector3.zero)
        //{
        //    Debug.Log("player position:" + transform.position);

        //}
        transform.position += move * Speed * Time.deltaTime;
    }
}
