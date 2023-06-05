using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // Publics
    public UnityEvent onFireEvent;
    public AmmoScript ammoUIManager;
    public float fireDelay;
    public int magazineSize;
    public bool automatic;

    private AudioSource audioSource;
    private float currentFireDelay;

    [System.NonSerialized]
    public int remainingBullets;

    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = magazineSize;
        currentFireDelay = fireDelay;
        audioSource = GetComponent<AudioSource>();
        ammoUIManager.setMaxAmmo(magazineSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanFire())
        {
            doGunSound();
            --remainingBullets;
            ammoUIManager.setCurrentAmmo(remainingBullets);
            onFireEvent.Invoke();
            currentFireDelay = fireDelay;
        }
        else
        {
            Debug.Log("Tried to shoot... couldn't. LOL!");
        }
        currentFireDelay -= Time.deltaTime;
    }

    bool checkCanFire()
    {
        if (currentFireDelay > 0f || remainingBullets <= 0) return false;

        if (automatic)
        {
            if (Input.GetMouseButton(0)) return true;
        }

        if (Input.GetMouseButtonDown(0)) return true;

        return false;
    }

    void doGunSound()
    {
        audioSource.Play();
    }
}
