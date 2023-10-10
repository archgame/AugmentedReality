using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Lerp = 0.5f;

    //public float Offset = 1.5f;
    public GameObject Agent;

    private float Height;
    private float ForwardOffset;

    private float UpOffset;

    // Start is called before the first frame update
    private void Start()
    {
        //Height = Camera.main.transform.position.y;
        Vector3 Offset = Camera.main.transform.position - Agent.transform.position;
        ForwardOffset = -Offset.z;
        UpOffset = -Offset.y;
    }

    // Update is called once per frame
    private void Update()
    {
        //Update Position
        UpdatePosition();
        UpdateForward();
    }

    private void UpdateForward()
    {
        Vector3 forward = Agent.transform.forward;
        forward = Vector3.Lerp(Camera.main.transform.forward, forward, Lerp * Time.deltaTime);
        Camera.main.transform.forward = forward;
    }

    private void UpdatePosition()
    {
        //var result = Mathf.Lerp(-60, 60, Lerp);
        //Debug.Log(result);
        Vector3 pos = Agent.transform.position;
        //pos.y = Height;
        Vector3 offset = Agent.transform.forward * ForwardOffset + Agent.transform.up * UpOffset; ;
        pos -= offset;
        pos = Vector3.Lerp(Camera.main.transform.position, pos, Lerp * Time.deltaTime);
        Camera.main.transform.position = pos;
    }
}