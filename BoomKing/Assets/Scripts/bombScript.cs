using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class bombScript : MonoBehaviour
{

    public float fieldOfImpact;
    public float force;
    public LayerMask LayerToHit;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce((obj.transform.position - transform.position) * 30, ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

}
