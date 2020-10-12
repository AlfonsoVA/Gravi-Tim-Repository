using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTim : MonoBehaviour{
    public Transform bPoint;        
    public KeyCode shootKey = KeyCode.C;
    public GameObject bullet;        
    public int bCapacity = 5;
    public Sprite[] sprArray;    
    public SpriteRenderer spr;

    
    void Start(){
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update(){
        if(Input.GetKeyDown(shootKey) && bCapacity > 0){
            shootBullet();  
            bCapacity -= 1;
            spr.sprite = sprArray[1];            
        }else{
            spr.sprite = sprArray[0];            
        }  
    }

    void shootBullet(){
        //Create the bullet and give it a position :^l
        Instantiate(bullet, bPoint.position, bPoint.rotation);
    }
}
