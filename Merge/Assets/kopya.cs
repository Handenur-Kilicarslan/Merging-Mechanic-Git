using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kopya : MonoBehaviour
{



    public GameObject obje;
    public GameObject obje2;
    public Rigidbody objerb;
    public Rigidbody objerb2;
    public float speed = 10f;




    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "obje2")
        {

            GetComponent<Collider>().enabled = false;
            Makebigger();
            Invoke("Makebigger", 1);
            InvokeRepeating("Makebigger", 2, 1 / 2);

            //  col.gameObject.transform.parent = transform;
            //col.gameObject.transform = transform.parent;
            transform.parent = col.gameObject.transform;
        }
    }


    void Update()
    {
        objerb = obje.GetComponent<Rigidbody>();
        objerb2 = obje2.GetComponent<Rigidbody>();

        if (Input.GetKey("a"))
        {
            objerb.AddForce(transform.right * speed);
            objerb2.AddForce(transform.right * -speed);
        }
        else
        {
            objerb.velocity = Vector2.zero;

        }

        /*
        obje2.GetComponent<Rigidbody>().useGravity = true;
        obje2.GetComponent<Rigidbody>().isKinematic = false;
        */
    }

    public void Makebigger()
    {
        obje2.transform.localScale += new Vector3(0.3f, 0.2f, 0.1f);
    }


}

