using System;

using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class Pushable : MonoBehaviour
{
    public const float PushPadding = 0.2f;

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
	}
	
	// Update is called once per frame
    private void Update () {
        Push(_player.transform,0.75f);
        if (!_player.GetComponent<Player>().HasPushObj)
        {
            GameObject pushObj = GameObject.FindWithTag("PushObj");
            if (pushObj != null)
            {
                Transform pushObjTrans = pushObj.transform;
                if (ObjectInRange(pushObjTrans, 0.75f))
                {
                    Push(pushObjTrans, 0.75f);
                }
            }

        }
        if (!_player.GetComponent<Player>().HasFreezeObj)
        {
            GameObject freezeObj = GameObject.FindWithTag("FreezeObj");
            if (freezeObj != null)
            {
                Freeze(freezeObj.transform);
            }
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

            Debug.DrawRay(_initPos, direction * (distance2 + PushPadding));
            var hit = Physics2D.Raycast(_initPos, direction, distance2 + PushPadding, ~LayerMask.GetMask("Water", "Ignore Raycast"));
            transform.position = _initPos + direction * (hit.collider != null ? hit.distance - PushPadding : distance2);
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
