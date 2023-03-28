using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    float bulletCount = 0;
    public TMP_Text bullets;
    float gunCount = 0;
    public float mSpeed;
    public float rSpeed;
    public Rigidbody rb;
    public float badGuyForce;
    public float carForce;
    public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player controls
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * mSpeed * vAxis, Space.World);
        gameObject.transform.Rotate(0, rSpeed * Time.deltaTime * hAxis, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //bullets
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            bulletCount = bulletCount + 1;
            bullets.text = bulletCount.ToString() + "/10 BULLETS";


        }

        if (bulletCount >= 10)
        {
            bullets.text = "GET THE GUN";
            GameObject weapon = Instantiate(Gun, new Vector3(-23, 1, 36), transform.rotation);

        }
        //gun
        if (other.CompareTag("gun"))
        {
            Destroy(other.gameObject);
            gunCount = gunCount + 1;
        }

        if (gunCount >= 1)
        {
            bullets.text = "YEAH, I'M THINKING I'M BACK";
        }

        //bad guys and cars
        if (other.CompareTag("car"))
        {
            rb.AddForce(gameObject.transform.forward * carForce);
        }

        if (other.CompareTag("badGuy"))
        {
            rb.AddForce(gameObject.transform.forward * badGuyForce);
        }
    }

    }
