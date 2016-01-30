using UnityEngine;
using System.Collections;
using Random = System.Random;
using System;

public class Pushable : MonoBehaviour {
    public float PushDist;
    public float FreezeDist;
    private GameObject _player;
    private Vector3 _initPos;
    private float _time = 0;
    private bool _frozen;

	// Use this for initialization
	void Start () {
        Debug.Log("start pushable");
        _player = GameObject.FindWithTag("Player");
        _initPos = transform.position;
        Debug.Log(_initPos);
    }
	
	// Update is called once per frame
    private void Update () {
        Push(_player.transform,1f);
        if (!_player.GetComponent<Player>().HasPushObj)
        {
            Transform pushObj = GameObject.FindWithTag("PushObj").transform;
            if (ObjectInRange(pushObj,2))
            {
                Push(pushObj, 2f);
            }

        }
        if (!_player.GetComponent<Player>().HasFreezeObj)
        {
            GameObject freezeObj = GameObject.FindWithTag("FreezeObj");
            Freeze(freezeObj.transform);

        }
        else
        {
            _frozen = false;
        }
        MinorMovement();
	}

    private bool ObjectInRange(Transform transform, int pushfactor)
    {
        Vector3 delta = _initPos - transform.position;
        float distance = delta.magnitude;

        return distance < PushDist*pushfactor;

    }

    private void Freeze(Transform col)
    {
        Vector3 delta = transform.position - col.position;
        float distance = delta.magnitude;

        if (distance < FreezeDist)
        {
            _frozen = true;
        }
    }

    void Push(Transform col, float pushfactor)
    {
        if (!_frozen)
        {
            Vector3 delta = _initPos - col.position;
            float distance = delta.magnitude;

            if (distance > PushDist*pushfactor)
            {
                transform.position = _initPos;
                return;
            }
            Vector3 direction = delta/distance;
            float distance2 = PushDist*pushfactor - distance;

            transform.position = _initPos + direction*distance2;
        }
    }

    private void MinorMovement()
    {
        if (!_frozen)
        {
            _time += Time.deltaTime*3;
            float x = Mathf.Cos(_time*1.7f)*0.43f;
            float y = Mathf.Sin(_time)*0.43f;
            transform.position += new Vector3(x, y, 0);
        }
    }
}
