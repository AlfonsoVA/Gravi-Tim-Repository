using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTim : MonoBehaviour{
    private Rigidbody2D rbd;
    private SpriteRenderer spr;
    private int health;
    
    public GameObject healthCounter;
    public TextMeshProUGUI txtHPercent;
    public KeyCode jumpKey = KeyCode.X;
    public KeyCode gravityKey = KeyCode.Z;          
    public float jumpHeight = 8f;        
    public float speed = 5f;
    public bool faceRight = true;  
    public Vector3 vectorMove, vectorStart;
    public Animator anim;

    void Start(){
        rbd = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        healthCounter = GameObject.FindWithTag("HealthCounter");
        txtHPercent = healthCounter.GetComponent<TMPro.TextMeshProUGUI>();        
        health = int.Parse(txtHPercent.text);
        vectorStart = rbd.position;
    }
    
    void FixedUpdate(){        

        //Walking lines
        vectorMove = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        anim.SetFloat("Speed", Mathf.Abs(vectorMove.x * speed));
        if(rbd.velocity.y != 0){
            anim.SetBool("OnJump", true);
            anim.SetFloat("Speed", 0f);
        }
        if((vectorMove.x > 0 && !(faceRight)) || (vectorMove.x < 0 && faceRight)){            
            faceRight = !faceRight;
            transform.Rotate(Vector3.up * 180);
        }        
        if(vectorMove.x != 0){            
            transform.position += vectorMove * Time.deltaTime * speed;
        }                                        

        //Flip gravity lines
        if(Input.GetKeyDown(gravityKey)){               
            rbd.gravityScale *= -1;   
            spr.flipY = !(spr.flipY);                                              
        }        

        //Jumping lines
        if(Input.GetKeyDown(jumpKey)){   
            if(rbd.velocity.y == 0){
                anim.SetBool("OnJump", true);
                if(rbd.gravityScale < 0){
                    rbd.velocity = new Vector2(rbd.velocity.x, jumpHeight *-1);            
                }else{
                    rbd.velocity = new Vector2(rbd.velocity.x, jumpHeight);            
                }                
            }                                      
        }        
        if(rbd.velocity.y == 0 && rbd.velocity.x == 0){
            anim.SetBool("OnJump", false);
        }        
    }
    
    public void decreaseHealth(int damage){
        health -= damage;
        txtHPercent.text = health.ToString();                       
    }
}
