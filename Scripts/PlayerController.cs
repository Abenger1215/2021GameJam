using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public GameObject checkFallingBlock;
    public GameObject boosterFireParticle;

    public WheelCollider[] wheels = new WheelCollider[4];
    GameObject[] wheelMesh = new GameObject[4];

    public float power = 100f; //power to rotate wheel
    public float rot = 45f; //rotation angle of wheel
    Rigidbody rb;

    //BoosterFunction
    public Camera mainCamera;
    public bool isBooster = false;
    float extraSpeed = 3;
    public float maxSpeed = 1000;
    public float curSpeed;

    //ReverseController
    public bool isReverseController = false;

    public Vector3 startPosition;

    bool control;

    // Start is called before the first frame update
    void Start()
    {
        //cameraTransform = mainCamera.GetComponent<Transform>();
        //carTransform = GetComponent<Transform>();
        startPosition = gameObject.transform.position + new Vector3(0, 5, 0);

        wheelMesh = GameObject.FindGameObjectsWithTag("WheelMesh");//return is array
        int size = wheelMesh.Length;
        for(int i = 0; i < size; i++)
        {
            //move position of wheel to wheel mesh position
            wheels[i].transform.position = wheelMesh[i].transform.position;
        }

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0); //centerOfMass는 물체의 무게중심 위치를 변경시키는 메서드, 무게 중심을 y축 아래 방향으로 낮춘다.
        boosterFireParticle.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if(GameManager.instance.isWin || GameManager.instance.isLoose)
        {
            GetComponent<AudioSource>().volume = 0f;
        }

        SyncWheelPos();

        isBooster = GameManager.instance.isBooster;
        isReverseController = GameManager.instance.isReverseController;
        control = GameManager.instance.isPlaying;

        //restart
        if(Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = startPosition;
        }

        if (control)
        {
            boosterFireParticle.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            if (isBooster)
            {
                //Debug.Log("right");
                boosterFireParticle.GetComponent<Transform>().localScale = new Vector3(3, 3, 3);
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = extraSpeed * power;
                    curSpeed = wheels[0].motorTorque;
                    mainCamera.fieldOfView = 80;
                }
                for (int i = 0; i < 2; i++)
                {
                    //앞바퀴만 각도 전환이 되도록
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * rot;
                }
            }
            else if (isReverseController)
            {
                //Debug.Log("reverse");
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = Input.GetAxis("Vertical") * -power;
                    curSpeed = wheels[0].motorTorque;
                    mainCamera.fieldOfView = 60;
                }
                for (int i = 0; i < 2; i++)
                {
                    //앞바퀴만 각도 전환이 되도록
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * -rot;
                }
            }
            else
            {
                //Debug.Log("right");
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].motorTorque = Input.GetAxis("Vertical") * power;
                    curSpeed = wheels[0].motorTorque;
                    mainCamera.fieldOfView = 60;
                }
                for (int i = 0; i < 2; i++)
                {
                    //앞바퀴만 각도 전환이 되도록
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * rot;
                }
            }
        }
    }

    void SyncWheelPos()
    {
        Vector3 wheelPosiotion = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for(int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosiotion, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosiotion;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == checkFallingBlock)
        {
            gameObject.transform.position = startPosition;
            //Debug.Log("Falling");
        }
    }
}
