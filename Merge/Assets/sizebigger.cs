using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class sizebigger : MonoBehaviour
{
    private Material mevcutrenk;
    public Material mevcutrenk2;
    public Material yenirenk;
    public float gecissuresi;

    public GameObject obje;
    public GameObject obje2;

    [SerializeField]
    Ease easetipi = Ease.OutBounce;

    void Start()
    {
        DOTween.Init();
        mevcutrenk = GetComponent<MeshRenderer>().material;
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "obje2")
        {
            GetComponent<Collider>().enabled = false;
            // transform.parent = col.gameObject.transform;
            col.gameObject.transform.parent = transform;
            transform.DOScale(1.4f, 1);
            mevcutrenk.DOColor(yenirenk.color, gecissuresi);
            mevcutrenk2.DOColor(yenirenk.color, 0.8f);

            obje2.GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = true;
            Invoke(nameof(UnfreezeY), 0.7f);
            Invoke(nameof(UnfreezeRotationZ), 0.8f);


        }
    }
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //1 saniyede 0'a git
            transform.DOMoveX(0, 1).SetEase(easetipi); 
            obje2.transform.DOMoveX(0, 1).SetEase(easetipi);

            obje2.GetComponent<Collider>().enabled = true;
        }
        
    }
     
    void UnfreezeY()
    {
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
    }
    void UnfreezeRotationZ()
    {
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }


}


