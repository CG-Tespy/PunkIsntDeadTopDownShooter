using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MortalActor2D
{
	[SerializeField] Bullet2D bulletPrefab;
	[Tooltip("How many bullets this can shoot per second.")]
	[SerializeField] float fireRate = 			3;
	public bool canShoot 						{ get; set; }
	protected float firingTimer;


    // Baradoros
    public GameObject manager;

    public void Start() {
        Animator anim = GetComponent<Animator>();
        int character = manager.GetComponent<GameManager>().character;
        anim.SetInteger("character", character);
    }
    // End



    protected override void Awake()
	{
		base.Awake();
		canShoot = 								false;
		firingTimer = 							1 / fireRate;
	}

	protected override void Update()
	{
		base.Update();
		HandleMovement();
		HandleShooting();
	}

	protected override void HandleMovement()
	{
		// Simple 2d movement.
		Vector2 horizontal = 					Vector2.right * Input.GetAxisRaw("Horizontal");
		Vector2 vertical = 						Vector2.up * Input.GetAxisRaw("Vertical");

		Vector2 movement = 						(horizontal + vertical) * moveSpeed;

		rigidbody.velocity = 					movement;
	}

	protected virtual void HandleShooting()
	{
		if (firingTimer <= 0)
			canShoot = 					true;
		
		else 
			firingTimer -= 				Time.deltaTime;
		

		
		if (canShoot && Input.GetButton("Fire1"))
		{
			// Spawn the bullet at the right position.
			float bulletOffset = 					1;
			Vector2 spawnPos = 						rigidbody.position + (Vector2.up * bulletOffset);

			Bullet2D bullet = 						Instantiate<Bullet2D>(bulletPrefab, spawnPos, Quaternion.identity);

			// Make sure the bullet is on the same layer as this, and it moves in the right 
			// direction.
			bullet.gameObject.layer = 				this.gameObject.layer;

			Vector3 shotDir = 						spawnPos - rigidbody.position;
			bullet.velocity = 						shotDir * bullet.moveSpeed;

			firingTimer = 							1 / fireRate;
			canShoot = 								false;
			// ^Only allow shooting when the timer is up again.
		}
	}

	public override void Die()	
	{
		canMove = 					false;
		canShoot = 					false;
		spriteRenderer.enabled = 	false;
	}
}
