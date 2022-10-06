using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTargets : MonoBehaviour
{
    public float radius;
    public float spawnCountdown;
    public float spawnCountdownInit;
    public GameObject targets;

    private Vector3 spawnCoords;

    void Start(){
        spawnCountdownInit = spawnCountdown;
    }

    // Update is called once per frame
    void Update(){
        spawnCountdown-=Time.deltaTime;
        if(spawnCountdown<=0){
            //TODO: Change the size of the thing
            //instantiates a taget object in the range of the current spawner's position, within the area of a square that is the length of the radius parameter
            spawnCoords = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0);
            Instantiate(targets, spawnCoords, transform.rotation);

            spawnCountdown=spawnCountdownInit;
        }
    }
}
