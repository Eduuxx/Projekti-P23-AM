using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // Publics
    public UnityEvent onFireEvent;
    private AudioSource audioSource;
    public float fireDelay;
    public int magazineSize;
    public bool automatic;
    private float currentFireDelay;

    [System.NonSerialized]
    public int remainingBullets;

    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = magazineSize;
        currentFireDelay = fireDelay;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanFire())
        {
            doGunSound();
            onFireEvent.Invoke();
            currentFireDelay = fireDelay;
        }
        currentFireDelay -= Time.deltaTime;
    }

    bool checkCanFire()
    {
        if (currentFireDelay > 0f) return false;

        if (automatic)
        {
            if (Input.GetMouseButton(0)) return true;
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) return true;
        }
        return false;
    }

    void doGunSound()
    {
        audioSource.Play();
    }
}
