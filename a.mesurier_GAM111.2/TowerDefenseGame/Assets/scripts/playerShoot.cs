using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {

    public Slider powerBar;

    float powerBarValue = 0f;
    public float power = 0.5f;
    public float releasePower = 0f;

    public GameObject projectile;
    GameObject spawnedProjectile;

    float destoryTime = 5f;

    public float projectileDamage = 0.3f;

    Rigidbody projectileRb;

    public float projectileForce = 25f;

    private void Awake()
    {
        powerBar.value = powerBarValue;
    }

    void Update ()
    {
        //increases the power value based on how long the user holds down the key
        if (Input.GetKey(KeyCode.Space))
        {
            powerBarValue += power * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (powerBar.value > 1)
            {
                powerBarValue = 1f;
            }

            //when the user lets go of the key the power of the projectile is increased based on the 
            //value of the power bar
            releasePower = powerBarValue;

            projectileDamage = releasePower;

            spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * projectileForce * releasePower);

            //resets the power back to 0 after its launched the projectile
            powerBarValue = 0f;

            Destroy(spawnedProjectile, destoryTime);
        }

        powerBar.value = powerBarValue;
    }
}
