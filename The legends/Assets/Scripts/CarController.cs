using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public WheelCollider RRight;
    public WheelCollider RLeft;
    public WheelCollider FRight;
    public WheelCollider FLeft;

    public Transform FRWheel;
    public Transform FLWheel;
    public Transform RRWheel;
    public Transform RLWheel;

    public float rpmEngine;// колл оборото в минуту итог
    public float rpmRRight;// колл оборото в минуту правого заднего колеса
    public float rpmRLeft;// колл оборото в минуту левого заднего колеса 


    public float motorTorque;//Крутящий момент двигателя

    



    // Start is called before the first frame update
    void Update()
    {
        Vector3 FRposi;
        Quaternion FRquator;
        FRight.GetWorldPose(out FRposi,out FRquator);
        FRWheel.position = FRposi;
        FRWheel.rotation = FRquator;

        Vector3 FLposi;
        Quaternion FLquator;
        FLeft.GetWorldPose(out FLposi,out FLquator);
        FLWheel.position = FLposi;
        FLWheel.rotation = FLquator;

        Vector3 RRposi;
        Quaternion RRquator;
        RRight.GetWorldPose(out RRposi,out RRquator);
        RRWheel.position = RRposi;
        RRWheel.rotation = RRquator;

        Vector3 RLposi;
        Quaternion RLquator;
        RLeft.GetWorldPose(out RLposi,out RLquator);
        RLWheel.position = RLposi;
        RLWheel.rotation = RLquator;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FRight.steerAngle = Input.GetAxis("Horizontal")*45;//вращение по оси горизонта
        FLeft.steerAngle = Input.GetAxis("Horizontal")*45;

        RRight.motorTorque = Input.GetAxis("Vertical")*motorTorque*5;//вращение по оси вертикали 
        RLeft.motorTorque = Input.GetAxis("Vertical")*motorTorque*5;

        Engine();

        
    }

    public void Engine()
    {
        rpmRRight = RRight.rpm;//прием оборотов в минуту заднего правого колеса 
        rpmRLeft = RLeft.rpm;//прием оборотов в минуту заднего левого колеса 

        if(rpmRRight > rpmRLeft)//определение обаротов в минуту какого колеса будут приниматься 
        {
            rpmEngine = rpmRRight;
        }
        else rpmEngine = rpmRLeft;

        if(rpmEngine<2700f) motorTorque =100;
        if (rpmEngine>2700f && rpmEngine <3200f) motorTorque = 0.29f * rpmEngine - 683;
        if (rpmEngine>3200f && rpmEngine <3700f) motorTorque = (-0.09f) * rpmEngine - 43;
        if (rpmEngine>3700f && rpmEngine <4200f) motorTorque = (-0.01f) * rpmEngine +372;
        if (rpmEngine>4200f && rpmEngine <4700f) motorTorque = 0.01f * rpmEngine +243;
        if (rpmEngine>4700f && rpmEngine <5200f) motorTorque = (-0.02f) * rpmEngine +384;
        if (rpmEngine>5200f && rpmEngine <5700f) motorTorque =(-0.1f) * rpmEngine +800;
        if (rpmEngine>5700f && rpmEngine <6200f) motorTorque =(-0.1f) * rpmEngine +800;
        if (rpmEngine>6200f && rpmEngine <9000f) motorTorque =(-0.06f) * rpmEngine +552;


    }

}
