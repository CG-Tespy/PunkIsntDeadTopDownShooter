using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetingBullet2D : RotatingBullet2D 
{
	[Tooltip("How many times this bullet can ricochet before being allowed to die.")]
	[SerializeField] int ricochetCount = 					1;
	int ricochetsDone = 0;

	protected override void OnCollisionEnter2D(Collision2D other)
	{
		contactEvents.CollisionEnter2D.Invoke(other);
	}
	
}
