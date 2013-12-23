using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	
	private Transform myTransform;

	void Awake() {
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		target = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position);

		//Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		//Move towards targer
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime; 
	}
}
