using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject fireBullet;
    public AudioSource source;
    [SerializeField] public AudioClip FireSfx;

    private void Awake()
    {
       FireSfx = GetComponent<AudioClip>();
    }
    private void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        if (Input.GetKeyDown (KeyCode.J))
        {
            
           GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);  //Quaternion.identity =(0,0,0)
            bullet.GetComponent<FireBulletScript>().Speed *= transform.localScale.x;

            source.PlayOneShot(FireSfx);
        }
    }

   /* public void PlaySound (AudioClip _sound)
    {
        FireSfx.PlayOneShot(_sound);
    }*/
}
