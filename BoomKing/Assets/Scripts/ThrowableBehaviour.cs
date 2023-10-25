using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableBehaviour : MonoBehaviour
{
    public float speed = 4;
    public Vector3 launchOffset;
    public static bool thrown;
    public GameObject bomb;


    // Start is called before the first frame update
    void Start()
    {
        BombCooldown.activate = true;
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.C))
        {
            StopScript();
        }
    }
    
    IEnumerator waiter()
    {
        //apres 5sec, si la bombe n'a pas etait declenchee, alors elle explose
        yield return new WaitForSecondsRealtime(4);
        StopScript();
    }

    public void StopScript() 
    {

        transform.Translate(launchOffset);
        bomb.GetComponent<bombScript>().Explode();
        Destroy(gameObject);
    }

}
