using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraCycle : MonoBehaviour {

    public Color startColor;
    public Color endColor;

    public Camera camFront;
    public Camera camAngle;
    public Camera camSide;
    public Camera camFrontCig;
    public Camera camAngleCig;
    public Camera camSideCig;
    public Camera camStand;
    public Camera camAtFeet;
    public Camera camAthead;
    public GameObject DaphneStanding;
    public GameObject RoomMate;
    public GameObject Cig;
    public Transform roomMatePoint;
    public GameObject Door;
    public GameObject Daphnesit;
    public GameObject ClosingDoor;
    public Image Stop;
    public Image lArrow;
    public Image rArrow;
    public Sprite daphLookUp;
    public Sprite daphCloseEyes;

    private int interactiveCycle;
    private int interactiveCycle2;
    private int camNum;
    private bool phase1Compelete;
    private bool phase2Active;
    private bool spawnedRM;
    private bool cigFlick;
    private bool moveInside;
    private GameObject RM;

    // Use this for initialization
    void Start () {
        interactiveCycle = 0;
        interactiveCycle2 = 0;
        camNum = 1;
        spawnedRM = false;
        phase1Compelete = true;
        phase2Active = false;
        StartCoroutine(IntroScene());
	}
	
	// Update is called once per frame
	void Update () {

        if (phase1Compelete == false)
        {
            CamChange();
            Color temp = lArrow.color;
            temp.a = 1f;
            lArrow.color = temp;

            Color temp2 = rArrow.color;
            temp2.a = 1f;
            rArrow.color = temp2;
        }
        if (phase2Active == true)
        {
            CamChange2();
            Color temp = lArrow.color;
            temp.a = 1f;
            lArrow.color = temp;

            Color temp2 = rArrow.color;
            temp2.a = 1f;
            rArrow.color = temp2;
        }
        switch (camNum)
        {

            case 1:
                camFront.enabled = true;
                camSide.enabled = false;
                camAngle.enabled = false;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 2:
                camFront.enabled = false;
                camAngle.enabled = true;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 3:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = true;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 4:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = true;
                camAngleCig.enabled = false;
                camSideCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 5:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camAngleCig.enabled = true;
                camSideCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 6:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camAngleCig.enabled = false;
                camSideCig.enabled = true;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 7:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = true;
                camStand.enabled = false;
                camAthead.enabled = false;
                break;
            case 8:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = true;
                camAthead.enabled = false;
                break;
            case 9:
                camFront.enabled = false;
                camAngle.enabled = false;
                camSide.enabled = false;
                camFrontCig.enabled = false;
                camSideCig.enabled = false;
                camAngleCig.enabled = false;
                camAtFeet.enabled = false;
                camStand.enabled = false;
                camAthead.enabled = true;
                break;
        }

        if (cigFlick == false)
        {
            if (interactiveCycle == 3)
            {
                phase1Compelete = true;
                StartCoroutine(CigFlick());
                cigFlick = true;
                Color temp = lArrow.color;
                temp.a = 0f;
                lArrow.color = temp;

                Color temp2 = rArrow.color;
                temp2.a = 0f;
                rArrow.color = temp2;

                Color temp3 = Stop.color;
                temp3.a = 1f;
                Stop.color = temp3;
            }
        }

        if (moveInside == false)
        {
            if (interactiveCycle2 == 3)
            {
                phase2Active = false;
                StartCoroutine(MoveInside());
                moveInside = true;
                Color temp = lArrow.color;
                temp.a = 0f;
                lArrow.color = temp;

                Color temp2 = rArrow.color;
                temp2.a = 0f;
                rArrow.color = temp2;

                Color temp3 = Stop.color;
                temp3.a = 1f;
                Stop.color = temp3;
            }
        }
    }

    void CamChange()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            camNum++;
          
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            camNum--;
            if (camNum == 1)
            {
                interactiveCycle++;
            }
        }
        if (camNum <= 1)
        {
            camNum = 1;
        }
        if (camNum >= 3)
        {
            camNum = 3;
        }
    }

    public IEnumerator IntroScene()
    {
        yield return new WaitForSeconds(2.5f);
        phase1Compelete = false;
    }

    public IEnumerator CigFlick()
    {

        yield return new WaitForSeconds(1);
        Color temp = Stop.color;
        temp.a = 0f;
        Stop.color = temp;

        yield return new WaitForSeconds(1);
        Door.transform.localScale = new Vector3(1f, 5f, .5f);
        Door.transform.position = new Vector3(1F,2.28f,3.23f);

        if (spawnedRM == false)
        {
            RM = Instantiate(RoomMate, roomMatePoint.transform.position, transform.rotation);
            
            spawnedRM = true;
        }

        yield return new WaitForSeconds(1.25f);
        Destroy(Cig.gameObject);
        Daphnesit.GetComponent<SpriteRenderer>().sprite = daphLookUp;

        yield return new WaitForSeconds(1.25f);
        Daphnesit.GetComponent<SpriteRenderer>().sprite = daphCloseEyes;

        yield return new WaitForSeconds(1f);
        Destroy(RM.gameObject);

        phase2Active = true;
    }

    void CamChange2()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            camNum++;
            if (camNum == 6)
            {
                interactiveCycle2++;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            camNum--;
      
        }
        if (camNum <= 4)
        {
            camNum = 4;
        }
        if (camNum >= 6)
        {
            camNum = 6;
        }
    }

    public IEnumerator MoveInside()
    {
        yield return new WaitForSeconds(1);
        Color temp = Stop.color;
        temp.a = 0f;
        Stop.color = temp;
        yield return new WaitForSeconds(1.25f);
        camNum = 7;

        yield return new WaitForSeconds(1.25f);
        camNum = 8;

        yield return new WaitForSeconds(1);
        camNum = 9;

        yield return new WaitForSeconds(.75f);
        Destroy(DaphneStanding.gameObject);
        ClosingDoor.transform.position = new Vector3(-115.9f, ClosingDoor.transform.position.y, ClosingDoor.transform.position.z);
        


    }
}
