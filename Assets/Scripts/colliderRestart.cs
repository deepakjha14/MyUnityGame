using UnityEngine;
using System.Collections;

public class colliderRestart : MonoBehaviour {

    public Collision2D collider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Background"))
        {
            Destroy(collision.gameObject);
        }        
    }
}
