using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScript : MonoBehaviour
{
    float bulletCount = 0;
    public TMP_Text bullets;
    float gunCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //bullets
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            bulletCount = bulletCount + 1;
            bullets.text = bulletCount.ToString() + "/10 Bullets";


        }

        if (bulletCount >= 10)
        {
            bullets.text = "Get the Gun";
        }
        //gun
        if (other.CompareTag("gun"))
        {
            Destroy(other.gameObject);
            gunCount = gunCount + 1;
        }

        if (gunCount >= 1)
        {
            bullets.text = "Yeah, I'm thinking I'm back";
        }

    }

    }
