using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRadius : MonoBehaviour 
{
    private Enemy self;

    // Start is called before the first frame update
    void Start()
    {
       self = GetComponentInParent<Enemy>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") self.playerInRadius = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
 
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") self.playerInRadius = null;
    }
}
