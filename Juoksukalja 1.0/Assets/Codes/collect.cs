using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour{

    public int value;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            pointCounter.instance.IncreasePoints(value);
        }
    }
    void OnBecameInvisible(){
        Destroy(gameObject); 
    }

}
