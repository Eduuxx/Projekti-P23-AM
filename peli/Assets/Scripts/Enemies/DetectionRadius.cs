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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(self.playerInRadius);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") self.playerInRadius = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
 
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") self.playerInRadius = null;
    }
}
