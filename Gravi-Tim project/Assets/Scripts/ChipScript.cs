using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChipScript : MonoBehaviour{
    private GameObject chipCounter;
    private TextMeshProUGUI txtCount;    
    private SpriteRenderer spr;
    private BoxCollider2D boxcol;
    private Vector3 pos;
    private int counter;

    void Start(){
        chipCounter = GameObject.FindWithTag("ChipCounter");        
        txtCount = chipCounter.GetComponent<TMPro.TextMeshProUGUI>();
        counter = int.Parse(txtCount.text);
        spr = GetComponent<SpriteRenderer>();
        boxcol = GetComponent<BoxCollider2D>();
    }

    void Update(){
        //Floating "animation"
        pos = transform.position;
        pos.y =  pos.y + (float)0.05 * Mathf.Sin((float)5.75*Time.time);                  
        transform.position = pos;
    }

    //increase chip counter and destroy gm with contact with player. 
    private void OnTriggerEnter2D(Collider2D col){   
        if(col.gameObject.tag == "Player"){            
            counter += 1;
            txtCount.text = counter.ToString();                
            Object.Destroy(gameObject);
        }                     
    }
}
