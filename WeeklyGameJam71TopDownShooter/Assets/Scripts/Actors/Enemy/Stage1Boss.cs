using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Just shoots fans of discs that ricochet off the walls.
/// </summary>
public class Stage1Boss : RangedEnemy
{
	[SerializeField] int bulletsPerFan = 				3;
	
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
		HandleShooting();
		
	}

	protected override void HandleShooting()
	{
		if (!canShoot)
			return;

		if (firingTimer <= 0)
		{
			FanShot();
			firingTimer = 			1 / fireRate;
		}
		else 
			firingTimer -= 			Time.deltaTime;
		
	}
	void FanShot()
	{
		// Decide where each bullet should go.
		float distOffset = 						1;

		List<Vector2> bulletPositions = 		new List<Vector2>();
		Vector2 bulletPos = 					Vector2.zero;
		float // The min and max angles decide the shape and size of the fan.
			minAngle = 							200,
			maxAngle = 							340,
			angleStep = 						((maxAngle - minAngle) / (bulletsPerFan - 1)) * Mathf.Deg2Rad,
			shotAngle = 						minAngle * Mathf.Deg2Rad;

		// angleStep is to help the bullets be spread as evenly as possible in the fan.
		for (int i = 0; i < bulletsPerFan; i++)
		{
			bulletPos.x = 						Mathf.Cos(shotAngle) * distOffset;
			bulletPos.y = 						Mathf.Sin(shotAngle) * distOffset;

			bulletPos += 						rigidbody.position;

			bulletPositions.Add(bulletPos);
			shotAngle += 						angleStep;

		}

		// Now, spawn bullets at each of those positions...
		Vector2 shotDir = 						Vector2.zero;
		foreach (Vector2 spawnPos in bulletPositions)
		{
			Bullet2D bullet = 					Instantiate<Bullet2D>(bulletPrefab, spawnPos, 
																	Quaternion.identity);

			// ... Making them go off in the right directions.
			shotDir = 							bullet.rigidbody.position - rigidbody.position;

			bullet.velocity = 					shotDir.normalized * bullet.moveSpeed;

		}
		

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
