using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PushObj; 
    public GameObject FreezeObj;
    public bool HasPushObj;
    public bool HasFreezeObj;
    public float Speed;

    private const float Magic = 0.06f;

    private Vector2 extents;
    private float cornerRadius;
    private float rightSideLength, rightMarginSideLength;
    private float topSideLength, topMarginSideLength;

    public Vector2 NorthEast
    {
        get
        {
            return new Vector2(transform.position.x + extents.x, transform.position.y + extents.y);
        }
    }

    public Vector2 SouthEast
    {
        get
        {
            return new Vector2(transform.position.x + extents.x, transform.position.y - extents.y);
        }
    }

    public Vector2 SouthWest
    {
        get
        {
            return new Vector2(transform.position.x - extents.x, transform.position.y - extents.y);
        }
    }

    public Vector2 NorthWest
    {
        get
        {
            return new Vector2(transform.position.x - extents.x, transform.position.y + extents.y);
        }
    }

    // Use this for initialization
    void Start()
    {
        extents = GetComponent<Collider2D>().bounds.extents;
        cornerRadius = ((Vector2)transform.position - SouthEast).magnitude;

        topSideLength = extents.x + Magic;
        topMarginSideLength = extents.x - Magic;

        rightSideLength = extents.y + Magic;
        rightMarginSideLength = extents.y - Magic;

        Debug.Log(String.Format("{0} {1}", topSideLength, rightSideLength));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Action();
    }

    private void Action()
    {
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

    private void Move()
    {
        var move = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            move += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            move += Vector2.right;
        if (Input.GetKey(KeyCode.UpArrow))
            move += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))

            move += Vector2.down;

        // No movement
        if (move == Vector2.zero) return;

        var dist = Speed * Time.deltaTime;

        if (move.x != 0)
        {
            var xMove = new Vector2(move.x, 0);
            var r1 = Physics2D.Raycast(transform.position + new Vector3(topSideLength * move.x, rightMarginSideLength, 0), xMove, dist - topMarginSideLength);
            var r2 = Physics2D.Raycast(transform.position + new Vector3(topSideLength * move.x, -rightMarginSideLength, 0), xMove, dist - topMarginSideLength);
            Debug.DrawRay(transform.position + new Vector3(topSideLength * move.x, rightMarginSideLength, 0), xMove * 3);
            Debug.DrawRay(transform.position + new Vector3(topSideLength * move.x, -rightMarginSideLength, 0), xMove * 3);
            var minDist = dist;

            if (r1.collider != null && r2.collider != null)
            {
                minDist = r1.distance < r2.distance ? r1.distance : r2.distance;
            }
            else if (r1.collider != null || r2.collider != null)
            {
                minDist = r1.distance > r2.distance ? r1.distance : r2.distance;
            }
            Debug.Log("x " + minDist);
            transform.position += (Vector3)xMove * minDist;
        }

        if (move.y != 0)
        {
            var yMove = new Vector2(0, move.y);
            var r1 = Physics2D.Raycast(transform.position + new Vector3(topMarginSideLength, rightSideLength * move.y, 0), yMove, dist - rightMarginSideLength);
            var r2 = Physics2D.Raycast(transform.position + new Vector3(-topMarginSideLength, rightSideLength * move.y, 0), yMove, dist - rightMarginSideLength);
            Debug.DrawRay(transform.position + new Vector3(topMarginSideLength, rightSideLength * move.y, 0), yMove * 3);
            Debug.DrawRay(transform.position + new Vector3(-topMarginSideLength, rightSideLength * move.y, 0), yMove * 3);
            var minDist = dist;

            if (r1.collider != null && r2.collider != null)
            {
                minDist = r1.distance < r2.distance ? r1.distance : r2.distance;
            }
            else if (r1.collider != null || r2.collider != null)
            {
                minDist = r1.distance > r2.distance ? r1.distance : r2.distance;
            }
            Debug.Log("y " + minDist);
            transform.position += (Vector3)yMove * minDist;
        }
    }
}
