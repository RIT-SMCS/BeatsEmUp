﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Attack : MonoBehaviour {

	public bool attacking;
    static int asdf = 0;

    private SpriteRenderer _renderer;
    // Use this for initialization
    void Start () {
		attacking = false;

        _renderer = this.GetComponent<SpriteRenderer>();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (attacking)
        {
            _renderer.enabled = true;
        }
        else
        {
            _renderer.enabled = false;
        }
	}

	void OnTriggerStay2D(Collider2D other)
	{
        //Debug.Log("Stay called "+asdf++);
		if (attacking && other.gameObject.CompareTag("Enemy")) 
		{
            //deal damage if attacking a valid enemy
            //other.gameObject.GetComponent<LaneActor>().Health = other.gameObject.GetComponent<LaneActor>().Health - 2; 
            other.gameObject.GetComponent<Enemy>().Health -= 1; 
			//end the attack after hitting something
			attacking = false; 
			ScoreManager.Combo += 1;
            ScoreManager.AddScoreWithMultiplier(10);

            Debug.Log("ENEMY HIT "+ Time.realtimeSinceStartup); 
		}
	}
}