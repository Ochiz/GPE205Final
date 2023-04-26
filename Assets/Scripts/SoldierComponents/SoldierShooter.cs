using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoldierShooter : Shooter
{
    private AudioClip shot;
    public Transform firepointTransform;
    // Start is called before the first frame update
    public override void Start()
    {
        shot = GetComponent<Pawn>().controller.ShootSFX;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    //function to shoot a shell
    public override void Shoot(GameObject bulletPrefab, float fireForce, float damageDone, float lifespan)
    {
        GameObject newBullet = Instantiate(bulletPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        DamageOnHit doh = newBullet.GetComponent<DamageOnHit>();
        if (doh != null)
        {
            doh.damageDone = damageDone;
            doh.owner = GetComponent<Pawn>();
        }
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        AudioSource test= GetComponent<AudioSources>().SFXSource;
        test.PlayOneShot(shot);
        
        Destroy(newBullet, lifespan);
        
    }
}
