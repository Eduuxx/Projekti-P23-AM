using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // Publics
    public UnityEvent onFireEvent;
    public float fireDelay;
    public bool automatic;

    private float currentFireDelay;

    // Start is called before the first frame update
    void Start()
    {
        currentFireDelay = fireDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentFireDelay <= 0f)
                {
                    onFireEvent.Invoke();
                    currentFireDelay = fireDelay;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireDelay <= 0f)
                {
                    onFireEvent.Invoke();
                    currentFireDelay = fireDelay;
                }
            }
        }
        currentFireDelay -= Time.deltaTime;
    }
}
