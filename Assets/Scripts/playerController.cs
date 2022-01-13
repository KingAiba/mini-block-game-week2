using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{

    public float speed = 20.0f;
    public float zLimit = 11.0f;

    public int maxHealth = 10;
    public int currHealth = 10;

    public bool isDead = false;

    public TMP_Text hpText;
    public TMP_Text DeadText;

    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "HP:" + currHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.z > zLimit )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }        
        else if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        if(!isDead)
        {
            transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
        }
        
    }

    public void AddHealth(int val)
    {
        if(!isDead)
        {
            currHealth += val;
            hpText.text = "HP:" + currHealth + "/" + maxHealth;
            if (currHealth <= 0)
            {
                if (DeadText.enabled == false)
                {
                    DeadText.enabled = true;
                }
                isDead = true;
            }
        }
    }
}
