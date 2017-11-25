using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustLeave : ComponentState<CustStateManager>
{
	[SerializeField]
	private float speed = 5;
	[SerializeField]
	private Collider2D positionCollider;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}

	private void OnEnable()
	{
		foreach (Collider2D c in GetComponents<Collider2D>())
		{
			if(positionCollider!=c)
				Destroy(c);
		}
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		rb.bodyType = RigidbodyType2D.Kinematic;
		rb.velocity = -Vector2.right * speed;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (this.enabled)
			if (collider.gameObject.tag == "Exit" )
			{
				Destroy (gameObject);
			}
	}
}
