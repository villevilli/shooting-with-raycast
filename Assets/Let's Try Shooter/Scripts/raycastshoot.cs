using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastshoot : MonoBehaviour {
    public int GunDamage = 1;
    public float firerate = .25f;
    public float weapomrange = 100f;
    public float hitforce = 100f;
    public Transform gunend;

    private Camera fpsCam;
    private WaitForSeconds shotduration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;


    // Use this for initialization
    void Start ()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();

            
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + firerate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            laserLine.SetPosition(0, gunend.position);
            

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weapomrange))
            {
                laserLine.SetPosition(1, hit.point);

                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                if (health != null)
                {
                    health.Damage(GunDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitforce);
                }
            }
                else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weapomrange));
            }
        }

    
	}
    private IEnumerator ShotEffect ()
    {
        gunAudio.Play();

        laserLine.enabled = true;
        yield return shotduration;
        laserLine.enabled = false; 
    }
}
