﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasPushObj = false;
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

        topSideLength = extents.y + Magic;
        topMarginSideLength = extents.y - Magic;

        rightSideLength = extents.x + Magic;
        rightMarginSideLength = extents.x - Magic;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            var r1 = Physics2D.Raycast(transform.position + new Vector3(rightSideLength * move.x, rightMarginSideLength, 0), xMove, dist - cornerRadius);
            var r2 = Physics2D.Raycast(transform.position + new Vector3(rightSideLength * move.x, -rightMarginSideLength, 0), xMove, dist - cornerRadius);
            var minDist = dist;

            if (r1.collider != null && r2.collider != null)
            {
                minDist = r1.distance < r2.distance ? r1.distance : r2.distance;
            }
            else if (r1.collider != null || r2.collider != null)
            {
                minDist = r1.distance > r2.distance ? r1.distance : r2.distance;
            }

            transform.position += (Vector3)xMove * minDist;
        }

        if (move.y != 0)
        {
            var yMove = new Vector2(0, move.y);
            var r1 = Physics2D.Raycast(transform.position + new Vector3(topMarginSideLength, topSideLength * move.y, 0), yMove, dist - cornerRadius);
            var r2 = Physics2D.Raycast(transform.position + new Vector3(-topMarginSideLength, topSideLength * move.y, 0), yMove, dist - cornerRadius);
            var minDist = dist;

            if (r1.collider != null && r2.collider != null)
            {
                minDist = r1.distance < r2.distance ? r1.distance : r2.distance;
            }
            else if (r1.collider != null || r2.collider != null)
            {
                minDist = r1.distance > r2.distance ? r1.distance : r2.distance;
            }

            transform.position += (Vector3)yMove * minDist;
        }
    }
}
