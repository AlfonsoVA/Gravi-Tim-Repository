using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour{    
    public float speed = 20f;
    
    private Rigidbody2D rbd;
    
    GameObject player;
    ShotTim sTim; 

    void Start(){
        rbd = gameObject.GetComponent<Rigidbody2D>();
        rbd.velocity = transform.right * speed;    
        player = GameObject.FindWithTag("Player");
        sTim = (ShotTim) player.GetComponent(typeof(ShotTim));
    }
    
    void Update(){}

    private void OnTriggerEnter2D(Collider2D col){      
        //Gotta make a parent class for this one!! ._."                             
        if(col.gameObject.tag.Equals("Bitter")){
            col.gameObject.GetComponent<MoveBitter>().hit();            
        }        
        Object.Destroy(gameObject);
        sTim.bCapacity += 1;        
    }
}
