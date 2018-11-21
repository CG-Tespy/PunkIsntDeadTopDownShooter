using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RotatingBullet2D : Bullet2D
{
	[SerializeField] Vector3 rotationSpeeds;

	protected override void Update()
	{
		base.Update();
		HandleRotation();
	}

	protected virtual void HandleRotation()
	{
		transform.eulerAngles += 			rotationSpeeds * Time.deltaTime;
	}
	
}
