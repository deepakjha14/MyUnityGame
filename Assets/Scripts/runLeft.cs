using UnityEngine;
using System.Collections;

public class runLeft : MonoBehaviour {
    public float speed = 10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Time.deltaTime * speed * Vector3.left;
	}
}
