using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class counterTime : MonoBehaviour {
    public float a = 60.0f;
    public Text showTimes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        a -= Time.deltaTime;
        showTimes.text = "Time left:"+(int)a;
        if (a <= 0)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
	}
}
