using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Just shoots fans of discs that ricochet off the walls.
/// </summary>
public class Stage1Boss : EnemyController
{
	[SerializeField] Bullet2D discPrefab;
	[SerializeField] int discsPerFan = 				3;
	Vector2 moveDir = 								Vector2.right;

	// Use this for initializing own members
	protected override void Awake () 
	{
		base.Awake();
		HandleMovement();
	}
	
	protected override void Update () 
	{
		// Movement no longer handled here.
		//collidersTouching.RemoveAll((Collider2D coll) => coll == null);
		
	}

	void FanShot()
	{
		// Decide where each disc should go. Have the discs spread apart as evenly 
		// as possible in the fan.
		float distOffset = 						1;
		Vector2 posOffset = 					distOffset * Vector2.down;

		List<Vector2> discPositions = 			new List<Vector2>();
		

	}

	protected override void HandleMovement()
	{
		// To be called only in Awake and OnCollisionEnter2D (instead of Update), 
		// so this gets called only when it needs to.
		rigidbody.velocity = 			moveDir * moveSpeed;

	}

	protected override void OnCollisionEnter2D(Collision2D other)
	{
		// Reverse direction once hitting a wall.
		bool hitWall = 					other.gameObject.CompareTag("Wall");

		if (hitWall)
		{
			moveDir = 					-moveDir;
			HandleMovement();
		}
	}
}
