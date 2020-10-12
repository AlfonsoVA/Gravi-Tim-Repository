using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBitter : MonoBehaviour{
    private Rigidbody2D rbd;
    private SpriteRenderer spr;    
    public float speed = 2.0f;
    public bool directionRight = false;
    public Vector3 vectorMove;
    public bool flipped = false;
    public int timeTurn = 500;  
    public int lifeCount = 3;  
    
    public int timeTurnReboot;
    
    GameObject player;
    MoveTim scrtim;
    
    void Start(){
        rbd = gameObject.GetComponent<Rigidbody2D>();                  
        spr = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        scrtim = (MoveTim) player.GetComponent(typeof(MoveTim));
        timeTurnReboot = timeTurn;
        if(flipped){
            rbd.gravityScale *= -1;
            spr.flipY = !(spr.flipY);
        }
    }

    
    void Update(){
        timeTurnReboot -= 1;
        if (timeTurnReboot <= 0){
            timeTurnReboot = timeTurn;
            directionRight = !directionRight;
        }
        if(directionRight){
            vectorMove = new Vector3(1f, 0f, 0f);                                    
        }else{
            vectorMove = new Vector3(-1f, 0f, 0f);                        
        }        
        transform.Translate(vectorMove.normalized * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D col){           
        if(col.gameObject.tag == "Player"){            
            scrtim.decreaseHealth(20);          
        }
    }

    public void hit(){
        if(lifeCount == 1){
            Object.Destroy(gameObject);
        }else{
            lifeCount -= 1;
        }
    }
}
