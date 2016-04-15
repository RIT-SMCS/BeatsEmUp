﻿using UnityEngine;
using System.Collections;

public abstract class Enemy : LaneActor {

    protected enum State { Attacking, Tracking};

    [SerializeField]
    protected float startX;
    protected State currentState;
    protected GameObject player;

    private float bubbleDuration = 2.0f;
    public float BubbleDuration
    {
        get { return bubbleDuration; }
        set { bubbleDuration = Mathf.Max(0.1f, value);
            StartCoroutine(PrepForAttack(bubbleDuration));
        }
    }

    public float StartX
    {
        get { return startX; }
        set { startX = value; }
    }

	// Use this for initialization
	public virtual void Awake () {
        
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	public override void Update () {
        //this.transform.position += new Vector3(_xVelocity, 0.0f, 0.0f) * Time.deltaTime;
        base.Update();
    }  

    public override void DoAttackPattern()
    {
        //Debug.Log("Attacked!");
    }

    protected IEnumerator PrepForAttack(float duration)
    {
        SetBubble(duration);
        yield return new WaitForSeconds(duration);
        DoAttackPattern();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.gameObject.tag == "Player")
        {           
            col.gameObject.GetComponent<Player>().TakeDamage(1);                       
        }
    } 
    
    public void SetBubble(float duration)
    {
        GameObject temp = Instantiate(Resources.Load("Telegraph")) as GameObject;
        temp.transform.parent = transform;
        temp.transform.localPosition = new Vector3(0, 0, 1);
        temp.GetComponent<TelegraphAttackBubble>().duration = duration;
    }      
}
