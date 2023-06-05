using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteRadius : MonoBehaviour
{
    private Player playerInRadius;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(doBiteDamage());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator doBiteDamage() {
        for (;;)
        {
            if (playerInRadius != null)
            {
                playerInRadius.takeDamage(29); // Remove fifteen damage from player
                playerInRadius.updateHealthBar();
                yield return new WaitForSeconds(1); // Execute this func only every second
            }
            yield return new WaitForSeconds((float)0.2); // Execute this func only every second
        }
    } 

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Player") playerInRadius = other.gameObject.GetComponentInParent<Player>();
    }
 
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") playerInRadius = null;
    }

}
