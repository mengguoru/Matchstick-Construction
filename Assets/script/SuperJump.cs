using UnityEngine;
using System.Collections;

public class SuperJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            col.GetComponent<PlayerController>().superJump = true;
            Destroy(this.gameObject);
        }
    }
}
