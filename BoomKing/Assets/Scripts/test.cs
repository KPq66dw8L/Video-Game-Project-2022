using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("test");
            rb.AddForce((transform.position - bomb.transform.position) * 10, ForceMode2D.Impulse);
        }
    }
}
