using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    Camera mainCam;
    Collider2D mouseCollider;
    public GameObject target;
    public OnHit script;
    public int score=0;
    //public Target target;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //script = gameObject.GetComponent<OnHit>();
    }

    public void addScore(int amount){
        Debug.Log("SCORE ADDED from follower script");
        score+=amount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }
}
