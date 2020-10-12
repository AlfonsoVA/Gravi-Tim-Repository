using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthScript : MonoBehaviour{
    GameObject healthCounter;
    TextMeshProUGUI txtHPercent;    
    SpriteRenderer spr;
    int counter;
    
    void Start(){
        healthCounter = GameObject.FindWithTag("HealthCounter");
        txtHPercent = healthCounter.GetComponent<TMPro.TextMeshProUGUI>();        
    }

    
    void Update(){
        counter = int.Parse(txtHPercent.text);
    }        

    private void OnTriggerEnter2D(Collider2D col){  
        if(col.gameObject.tag == "Player" && counter < 100){            
            if(counter > 90){
                counter = 100;    
            }else{
                counter += 10;
            }                
            txtHPercent.text = counter.ToString();                
            Object.Destroy(gameObject);
        }                     
    }
}
