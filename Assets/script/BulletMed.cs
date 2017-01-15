using UnityEngine;
using System.Collections;

public class BulletMed : MonoBehaviour {

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
            col.GetComponent<PlayerController>().BulletNum += 100;
            Destroy(this.gameObject);
        }
    }
}
