using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textList;

    public int currentScore=0;
    public int streak=0;
    public int streakKept=0;

    public float length;
    public float height;
    public float spawnCountdown;
    public float spawnCountdownInit;

    public AudioSource hitMarkerSFX;
    public AudioSource ohBabySFX;
    public AudioSource airhornSFX;

    Vector3 mouseCoords;

    Camera mainCam;
    public GameObject hitmarkerObject;

    private Vector3 spawnCoords;

    public void Start(){
        spawnCountdownInit = spawnCountdown;
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void OnMouseDown(){
        currentScore++;
        streakKept=1;

        mouseCoords = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        Instantiate(hitmarkerObject, mouseCoords, transform.rotation);

        hitMarkerSFX.Play();
    }

    void Update(){
        spawnCountdown-=Time.deltaTime;
        if(spawnCountdown<=0){
            //TODO: Change the size of the thing
            //instantiates a taget object in the range of the current spawner's position, within the area of a square that is the length of the radius parameter
            spawnCoords = new Vector3(Random.Range(-length, length), Random.Range(-height, height), 0);
            transform.position = spawnCoords;

            if(streakKept==1){
                streak++;
                if(streak==3 || streak%9==0){
                    ohBabySFX.Play();
                }
                if(streak%10==0 && streak!=0){
                    airhornSFX.Play();
                }       
            }
            else{
                streak=0;
            }
            textList.text = "Score = " + currentScore.ToString() + ", Streak = " +streak.ToString(); 

            streakKept=0;
            spawnCountdown=spawnCountdownInit;
        }
    }
}
