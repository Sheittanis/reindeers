using UnityEngine;
using System.Collections;

public class SnowFall : MonoBehaviour {

	Vector2 avgDrift;
	Vector2 maxSway;
	float angle;
	Vector2 swayThisMuch;
	float timeUntilDeath;
	float angleOffset;

	void Start () {
		angle = 0.0f;
		angleOffset = Random.Range (0.0f, Mathf.PI * 2);
		timeUntilDeath = 10.0f;
		avgDrift.x = Random.Range (-1.5f,  1.5f);
		avgDrift.y = Random.Range (-3.0f, -1.0f);
		maxSway.x = Random.Range (0.0f, 2.5f);
		maxSway.y = Random.Range (0.0f, 0.5f);
	}

	void Update () {
		swayThisMuch = maxSway * Mathf.Sin (angle);
		transform.Translate ((avgDrift + swayThisMuch) * Time.deltaTime, Space.World);
		this.transform.eulerAngles = new Vector3(0, 0, 90 * Mathf.Sin (angle + angleOffset));
		angle += Time.deltaTime;
		timeUntilDeath -= Time.deltaTime;
		if (timeUntilDeath < 0) {
			Destroy(this.gameObject);
		}
	}
}
