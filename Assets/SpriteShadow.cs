using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteShadow : MonoBehaviour
{
	[SerializeField]private Vector2 spriteOffset = new Vector2(-4f, -3f);

	[SerializeField]private SpriteRenderer spriteToShadow;

	[SerializeField]private SpriteRenderer shadowRenderer;

	[SerializeField]private Sprite lastSprite;

	[SerializeField]private Transform thisTransform;

	[SerializeField]private Transform transformToShadow;
	
	private void Start()
	{
		this.spriteToShadow = base.transform.parent.GetComponent<SpriteRenderer>();
		this.shadowRenderer = base.GetComponent<SpriteRenderer>();
		this.thisTransform = base.transform;
		this.transformToShadow = this.spriteToShadow.transform;
		this.shadowRenderer.color = new Color(0f, 0f, 0f);
	}

	private void LateUpdate()
	{
		if (this.spriteToShadow.sprite != this.lastSprite)
		{
			this.shadowRenderer.sprite = this.spriteToShadow.sprite;
			this.lastSprite = this.spriteToShadow.sprite;
		}
		this.thisTransform.position = new Vector2(this.transformToShadow.position.x + this.spriteOffset.x, this.transformToShadow.position.y + this.spriteOffset.y);
	}


}

