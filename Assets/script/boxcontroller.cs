using UnityEngine;
using System.Collections;

public class boxcontroller : MonoBehaviour {

    public float HP = 40;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HPController();
        if (transform.position.y < -50)
        {
            Destroy(this.gameObject);
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.tag.Equals("Bullet"))
        {
            HP = HP - 10;
            Destroy(col.gameObject);
        }
    }
    private void HPController ()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
