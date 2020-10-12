using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDamage : MonoBehaviour{
    GameObject player;
    MoveTim scrtim;
        
    void Start(){
        player = GameObject.FindWithTag("Player");
        scrtim = (MoveTim) player.GetComponent(typeof(MoveTim));
    }
    
    void Update(){}

    private void OnTriggerEnter2D(Collider2D col){   
        if(col.gameObject.tag == "Player"){
            scrtim.decreaseHealth(20);          
        }                     
    }
}
