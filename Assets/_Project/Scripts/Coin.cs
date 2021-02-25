using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField]private Transform target;

	[SerializeField]private Transform trans;

	[SerializeField] private AnimationCurve curve;

	[SerializeField] private AnimationCurve curveEaseOut;

	[SerializeField] private WaitForSeconds waitTime;

	private void OnEnable()
	{
		//base.StartCoroutine(this.Animate());
		base.StartCoroutine(this.Wiggle());
		base.StartCoroutine(this.Move());
	}

	private void Awake()
    {
		target = FindObjectOfType<PlayerPostionRotation>().transform;
		trans = transform;
		waitTime = new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));

	}

	private IEnumerator Move()
	{
		float timer = 0f;
		float speed = UnityEngine.Random.Range(1f, 2f);
		Vector2 nextPos = new Vector2(trans.position.x, trans.position.y) + Random.insideUnitCircle * Random.Range(2f, 8f);
		while (this.trans.position.x != nextPos.x && this.trans.position.y != nextPos.y)
		{
			timer += Time.deltaTime;
			this.trans.position = Vector2.Lerp(this.trans.position, nextPos, this.curveEaseOut.Evaluate(timer / speed));
			yield return null;
		}
		yield return this.waitTime;
		float moveTime = UnityEngine.Random.Range(0.75f, 1.5f);
		float moveTimer = 0f;
		while (Vector2.Distance(this.target.position, this.trans.position) > 4f)
		{
			moveTimer += Time.deltaTime;
			this.trans.position = Vector2.Lerp(this.trans.position, this.target.position, this.curve.Evaluate(moveTimer / moveTime));
			yield return 0;
		}
		CoinAcquired();
		yield break;
	}

	private IEnumerator Wiggle()
	{
		float interval = UnityEngine.Random.Range(0.5f, 1.25f);
		float timer = 0f;
		float rot = 0f;
		while (base.gameObject.activeInHierarchy)
		{
			float rotNext = (float)UnityEngine.Random.Range(-360, 360);
			while (timer < interval)
			{
				timer += Time.deltaTime;
				rot = Mathf.Lerp(rot, rotNext, this.curve.Evaluate(timer / interval));
				base.transform.rotation = Quaternion.Euler(0f, 0f, rot);
				yield return null;
			}
			timer = 0f;
		}
		yield break;
	}



	private void CoinAcquired()
	{
		GameMaster.instance.ScorePlus();
		base.gameObject.SetActive(false);
	}
	
	//private void OnCollisionEnter2D(Collision2D col){
	//		if (col.collider.CompareTag("Player"))
	//		{
	//			//CoinAcquired();
	//		}
	//	}
}
