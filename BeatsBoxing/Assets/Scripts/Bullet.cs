﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Bullet : MonoBehaviour {

    private float velocity = -2.0f;
    private float minX;

    public float Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        minX = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Vector3.zero).x;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(velocity, 0.0f, 0.0f) * Time.deltaTime;

        if(this.transform.position.x <= minX)
        {
            Destroy(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().TakeDamage(1);
            Destroy(this);
        }
    }
}
