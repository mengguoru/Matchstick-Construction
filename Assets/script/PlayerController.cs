using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 0.2f;
    public GameObject bullet;
    public Camera camera;
    public int Health = 100;
    public int BulletNum = 100;
    public float GunRotateSpeed = 5f;
    public bool superJump;
    public Animator animator;

    Vector3 offset;
    float nextFire;
    public float fireRate;
    public Transform shotSqawn;

    float Dogde = 0;
    int DogdeForward = 0;
    int DogdeSpace = 0;
    const float DogdeFrashTime = 3;
	// Use this for initialization
	void Start () { 
        superJump = false;
        offset = camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //camera.transform.position = transform.position + offset;
        Dogde += Time.deltaTime;
        if (Dogde > DogdeFrashTime)
        {
            //DogdeForward = 0;
            DogdeSpace = 0;
            Dogde = 0;
        }
        if (transform.position.y < -1)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);

        transform.Rotate(new Vector3(0, 1, 0), moveHorizontal);
        if (Input.GetKey(KeyCode.I))
        {
            shotSqawn.transform.Rotate(new Vector3(1, 0, 0), -Time.deltaTime * GunRotateSpeed);
        }
        if (Input.GetKey(KeyCode.K))
        {
            shotSqawn.transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * GunRotateSpeed);
        }


        if (Input.GetKey(KeyCode.O))
        {
            camera.transform.Rotate(new Vector3(1, 0, 0), -Time.deltaTime * GunRotateSpeed * 2);
        }
        if (Input.GetKey(KeyCode.L))
        {
            camera.transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * GunRotateSpeed * 2);
        }

        //camera.transform.Rotate(new Vector3(0, 1, 0), moveHorizontal);

        if (Input.GetKeyDown(KeyCode.W))
        {
            DogdeForward++;

        }

        if (Input.GetKeyUp(KeyCode.W) && DogdeForward >= 2)
        {
            DogdeForward = 0;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("ISwalk", false);
            animator.SetBool("ISrun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.position -= transform.forward * speed;
            animator.SetBool("ISwalk", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (DogdeForward >= 2)
            {
                transform.position += transform.forward * speed * 1.5f;
                animator.SetBool("ISrun", true);
            }
            else
            {
                transform.position += transform.forward * speed;
                animator.SetBool("ISrun", false);
            }
            animator.SetBool("ISwalk", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DogdeSpace <= 3 || ((superJump == true ) && (DogdeForward >= 2)))
            {
                GetComponent<Rigidbody>().AddForce(0, 200f, 0);
                DogdeSpace++;
            }
            
        }


        if (Input.GetKey(KeyCode.J) && Time.time > nextFire && BulletNum > 0) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSqawn.position, shotSqawn.rotation);
            BulletNum--;
            animator.SetTrigger("Shot");
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("SuperJump"))
        {
            Destroy(other.gameObject);
            superJump = true;
        }
        if (other.gameObject.tag.Equals("BulletPack"))
        {
            Destroy(other.gameObject);
            BulletNum += 50;
        }
        if (other.gameObject.tag.Equals("Pintu1"))
        {
            Destroy(other.gameObject);
            Application.LoadLevel("gupchang1");
        }
        if (other.gameObject.tag.Equals("Pintu2"))
        {
            Destroy(other.gameObject);
            Application.LoadLevel("guochang2");
        }
    }
}
