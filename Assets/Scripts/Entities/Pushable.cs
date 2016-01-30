using System;

using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class Pushable : MonoBehaviour
{
    public float MinorMovementDist;
    public float PushDist;
    public float FreezeDist;

    public Vector2 Min;
    public Vector2 Max;

    private GameObject _player;
    private Vector3 _initPos;
    private float _time;
    private bool _frozen;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindWithTag("Player");
        _initPos = transform.position;
        _time = Random.Range(0, Mathf.PI * 2);

        //float w = 8, h = 6;

        //_limitX = new Vector2(
        //    Mathf.Floor((_initPos.x + w / 2)/w) * w,
        //    Mathf.Floor((_initPos.x - w / 2)/w) * w);
        
        //_limitY = new Vector2(
        //    Mathf.Floor((_initPos.y + h / 2)/h) * h,
        //    Mathf.Floor((_initPos.y - h / 2)/h) * h);

        //Debug.Log(String.Format("Limit X: {0}", _limitX));
        //Debug.Log(String.Format("Limit Y: {0}", _limitY));
        Debug.Log(String.Format("Init: {0}", transform.localPosition));
	}
	
	// Update is called once per frame
    private void Update () {
        Push(_player.transform,0.5f);
        if (!_player.GetComponent<Player>().HasPushObj)
        {
            Transform pushObj = GameObject.FindWithTag("PushObj").transform;
            if (ObjectInRange(pushObj,1f))
            {
                Push(pushObj, 1f);
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

    private bool ObjectInRange(Transform transform, float pushfactor)
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
            transform.position = _initPos + direction * distance2;

            if (transform.localPosition.x < Min.x)
            {
                transform.position = new Vector2(transform.position.x + (Min.x - transform.localPosition.x), transform.position.y);
            }
            else if (transform.localPosition.x > Max.x)
            {
                transform.position = new Vector2(transform.position.x + (Max.x - transform.localPosition.x), transform.position.y);
            }

            if (transform.localPosition.y < Min.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + (Min.y - transform.localPosition.y));
            }
            else if (transform.localPosition.y > Max.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + (Max.y - transform.localPosition.y));
            }
        }
    }

    private void MinorMovement()
    {
        if (!_frozen)
        {
            _time += Time.deltaTime*3;
            float x = Mathf.Cos(_time*1.7f)*0.43f * MinorMovementDist;
            float y = Mathf.Sin(_time)*0.43f * MinorMovementDist;
            transform.position += new Vector3(x, y, 0);
        }
    }
}
