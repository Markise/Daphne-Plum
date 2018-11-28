using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvienceInteractions : MonoBehaviour
{

    public GameObject DontTouch;
    public GameObject PleaseStop;
    public GameObject ThisIsntOk;
    public GameObject ImSerious;
    public GameObject IHaveFeelings;
    public GameObject CmonNow;
    public GameObject Fine;
    public GameObject TotalSale;

    public GameObject Thought;
    public GameObject Hand;
    public GameObject target;
    public GameObject DaphArm;
    public GameObject ClerkArm;
    public GameObject Money;
    public GameObject Cigs;
    public Camera Cam;

    private int phrase;
    private bool spawned;
    private bool hold;
    private Vector3 mousePos;
    private GameObject Holding;

    // Use this for initialization
    void Start()
    {
        hold = false;
        phrase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = 27.5f;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        if(hold == true)
        {
            DaphArm.transform.position = new Vector3(Mathf.Clamp(v3.x, -13f, .4f), Mathf.Clamp(v3.y, -10f, -1.5f), v3.z);
            if (Input.GetMouseButtonUp(0))
            {
                hold = false;
                Holding.GetComponent<Collider>().enabled = true;
                Holding.transform.parent = null;
            }
        }
        else { DaphArm.transform.position = new Vector3(Mathf.Clamp(v3.x, -13f, 14f), Mathf.Clamp(v3.y, -10f, -1.5f), v3.z); }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interact")
        {
            if (Input.GetMouseButton(0))
            {
                Holding = other.gameObject;
                Holding.transform.SetParent(Hand.transform);
                Holding.GetComponent<Collider>().enabled = false;
                hold = true;
            }

        }

        if(other.tag == "Register")
        {
            if(Input.GetMouseButtonDown(0))
            {
                phrase += 1;
                spawned = false;
                switch (phrase)
                {

                    case 1:
                        if (spawned == false)
                        {
                            Instantiate(DontTouch, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
     
                    case 2:
                        if (spawned == false)
                        {
                            Instantiate(PleaseStop, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 3:
                        if (spawned == false)
                        {
                            Instantiate(ThisIsntOk, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 4:
                        if (spawned == false)
                        {
                            Instantiate(ImSerious, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 5:
                        if (spawned == false)
                        {
                            Instantiate(IHaveFeelings, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 6:
                        if (spawned == false)
                        {
                            Instantiate(CmonNow, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 7:
                        if (spawned == false)
                        {
                            Instantiate(Fine, target.transform.position, Quaternion.identity);
                            spawned = true;
                        }
                        break;
                    case 8:
                        if (spawned == false)
                        {
                            Instantiate(TotalSale, target.transform.position, Quaternion.identity);
                            Destroy(Thought.gameObject);
                            spawned = true;
                            
                        }
                        break;

                }
            }
        }
    }

}
