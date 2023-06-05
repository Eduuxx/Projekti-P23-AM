using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // Publics
    public UnityEvent onFireEvent;
    public AmmoScript ammoUIManager;
    public GameObject muzzleFlashPrefab;
    public Transform barrelTransform;
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
        // Reset ammo counter
        ammoUIManager.setCurrentAmmo(magazineSize); ammoUIManager.setMaxAmmo(magazineSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCanFire() && checkWantsToFire())
        {
            doGunSound();
            doMuzzleFlash();
            --remainingBullets;
            ammoUIManager.setCurrentAmmo(remainingBullets);
            onFireEvent.Invoke();
            currentFireDelay = fireDelay;
        };
        currentFireDelay -= Time.deltaTime;
    }

    bool checkWantsToFire()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0)) return true;
        }

        if (Input.GetMouseButtonDown(0)) return true;

        return false;
    }

    bool checkCanFire()
    {
        return currentFireDelay > 0f || remainingBullets <= 0 ? false : true;
    }

    void doGunSound()
    {
        audioSource.Play();
    }

    void doMuzzleFlash()
    {
        GameObject flash = Instantiate(muzzleFlashPrefab, barrelTransform.position, Quaternion.identity);
        Destroy(flash, 0.1f);
    }
}
