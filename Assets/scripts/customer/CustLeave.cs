using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustLeave : ComponentState<CustStateManager>
{
	[SerializeField]
	private float speed = 5;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}

	private void OnEnable()
	{
		foreach (Collider2D c in GetComponents<Collider2D>())
		{
			Destroy(c);
		}
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();

		rb.velocity = -Vector2.right * speed;
	}
}
