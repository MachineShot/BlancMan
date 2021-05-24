using System.Collections;
using TMPro;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public TextMeshProUGUI reloadDisplay;
    public int damage = 10;
    public float bulletSpeed = 20f;
    public float fireSpeed = 2f;
    public float reloadSpeed = 5f;
    public int clipSize = 5;
    public int ammo = 5;
    public float elapsedTime;
    public bool canReload;
    AudioSource shootingSound;

    private void Start()
    {
        shootingSound = GetComponent<AudioSource>();
        ammo = clipSize;
        elapsedTime = fireSpeed;
        canReload = true;
        reloadDisplay = GameObject.Find("Reload Display").GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (gameObject.tag.Equals("ActiveWeapon"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (elapsedTime < fireSpeed)
            {
                elapsedTime += Time.deltaTime;
            }
            if (ammo > 0)
            {
                if (Input.GetButtonDown("Fire1") && elapsedTime >= fireSpeed)
                {
                    elapsedTime = 0;
                    shootingSound.Play();
                    Shoot();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R) && canReload)
            {
                StartCoroutine(ReloadWait(reloadSpeed));
            }
            else
            {
                reloadDisplay.enabled = true;
            }
        }
    }

    void Shoot()
    {
        ammo--;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator ReloadWait(float length)
    {
        reloadDisplay.text = "RELOADING...";
        canReload = false;
        yield return new WaitForSeconds(length);
        ammo = clipSize;
        canReload = true;
        reloadDisplay.enabled = false;
        reloadDisplay.text = "PRESS R TO RELOAD!";
    }
}
