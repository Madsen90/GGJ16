using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {
    private Vector3 initPos;
    public float MaxPush;

	// Use this for initialization
	void Start () {
        initPos = transform.position;
        Debug.Log(initPos);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D player)
    {
        Vector3 delta = initPos - player.transform.position;
        float distance = delta.magnitude;

        if (distance == 0)
        {
            return;
        }

        if (distance > MaxPush)
        {
            transform.position = initPos;
            return;
        }

        Vector3 direction = delta / distance;
        float distance2 = MaxPush - distance;

        transform.position = initPos + direction * distance2;


        //if (transform.position == initPos)
        //{
        //    Debug.Log("delta:" + delta);
        //    Debug.Log("dis:" + distance);
        //    Debug.Log("dir:" + direction);
        //    Debug.Log("dis2:" + distance2);
        //}
    }

    void OnTriggerExit2D(Collider2D player)
    {
       //    transform.position = initPos;
    }
}
