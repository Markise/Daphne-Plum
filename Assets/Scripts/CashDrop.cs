using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashDrop : MonoBehaviour {

    public GameObject Cigs;
    public GameObject cigHand;
    public GameObject hand;
    private bool gotCash;
    private bool giveCigs;
    private bool cigsGiven;
	// Use this for initialization
	void Start () {
        cigsGiven = false;
        gotCash = false;
        giveCigs = false;
        Cigs.transform.SetParent(cigHand.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(gotCash == true)
        {
            transform.Translate(Vector3.up *10f*Time.deltaTime);
        }

        if(giveCigs == true)
        {
            cigHand.transform.Translate(-Vector3.up * 6f * Time.deltaTime);
        }

        if (cigHand.transform.position.y <= 6.5f)
        {
            giveCigs = false;
            Cigs.transform.parent = null;
            Cigs.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Cigs.transform.position = Cigs.transform.position;
            cigsGiven = true;
        }

        if(cigsGiven)
        {
            cigHand.transform.Translate(Vector3.up * 6f * Time.deltaTime);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interact")
        {
            other.transform.SetParent(hand.transform);
            gotCash = true;
        }
        
        if(other.tag == "Moveable")
        {
            giveCigs = true;
        }
    }
}
