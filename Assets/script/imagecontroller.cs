using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class imagecontroller : MonoBehaviour {

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    private float time;
	// Use this for initialization
	void Start () {
        time = 0;
        image1.SetActive(true);
        image2.SetActive(false);
        image2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 0.2)
        {
            image1.SetActive(false);
            image2.SetActive(true);
        }
        if (time >= 0.4)
        {
            image2.SetActive(false);
            image3.SetActive(true);
        }
        if (time >= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	
	}
}
