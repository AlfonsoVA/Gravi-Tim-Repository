using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour{    

    private GameObject chipCounter;
    private TextMeshProUGUI txtCount;
    

    void Start(){
        chipCounter = GameObject.FindWithTag("ChipCounter");        
        txtCount = chipCounter.GetComponent<TMPro.TextMeshProUGUI>();
    }    

    void Update(){}

    private void OnCollisionEnter2D(Collision2D col){           
        if((col.gameObject.tag == "Player") && (int.Parse(txtCount.text) > 0)){               
            int counter = (int.Parse(txtCount.text)) - 1;
            txtCount.text = counter.ToString();
            Object.Destroy(gameObject);     
        }
    }
}
