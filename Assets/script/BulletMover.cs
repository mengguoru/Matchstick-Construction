using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {
    public float speed;
    float timer = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 10)
        {

            Destroy(this.gameObject);
        }
	}
}
