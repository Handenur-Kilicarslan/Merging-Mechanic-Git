using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //bu kod aktif olduğunda material'a erişip sarı yapmalıyız
    // public Material matYellow;
    // GetComponent<Renderer>().material = matYellow;

    public GameObject deathparticle;

    public Rigidbody rb;

    public float forwardForce = 300f;  //ilerleme hızı

    public float sidewaysForce = 300f; //sağ sol hızı

    Animator animator; //animasyona erişmek için 
    int isWalkingHash;

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Engel")
        {

            Destroy(this.gameObject, 0.7f);
            deathparticle.SetActive(true);
            // Destroy(this.gameObject, 0.5f);
        }

    }

    void Start()  //THIS PART WORK WHEN THE GAME STARTS
    {
        animator = GetComponent<Animator>(); //Get the component
        rb = GetComponent<Rigidbody>();
        if (rb.isKinematic == true)
        {
            rb.isKinematic = false;
        }
       
        isWalkingHash = Animator.StringToHash("IsWalking");
    }

     void FixedUpdate()
    { 
        

        if (Input.GetKey("w"))
        {
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0);
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }


        if (Input.GetKey("d")) //D ye basıldığında sağa
        {
            rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);  //mass ignore -> velocityChange
            animator.SetBool(isWalkingHash, true);
        }
        if (Input.GetKey("a")) //A ye basıldığında sola
        {
            rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange); //eksi koyduk
            animator.SetBool(isWalkingHash, true);
        }
        
        
     }



    


 }

