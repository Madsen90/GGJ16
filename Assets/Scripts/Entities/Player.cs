using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject PushObj; 
    public GameObject FreezeObj;
    public bool HasPushObj;
    public bool HasFreezeObj;
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

        transform.position += move * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) && HasPushObj)
        {
            HasPushObj = false;
            Instantiate(PushObj,transform.position, Quaternion.identity);
            PushObj.GetComponent<PushObj>().HasBeenLaidDown = true;
        }

        if (Input.GetKey(KeyCode.X) && HasFreezeObj)
        {
            HasFreezeObj = false;
            Instantiate(FreezeObj, transform.position, Quaternion.identity);
            FreezeObj.GetComponent<FreezeObj>().HasBeenLaidDown = true;
        }
    }
}
