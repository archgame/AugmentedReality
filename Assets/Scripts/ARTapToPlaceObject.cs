using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject Indicator; //visual indicator
    private ARRaycastManager _manager;
    private Pose _pos; //position
    private bool isValid = false; //if surface is found = true

    public GameObject Prefab;

    private void Start()
    {
        _manager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        UpdatePos();
        UpdateIndicator();
        PlacePrefab();
    }

    private void PlacePrefab()
    {
        if (!isValid) { return; }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //first touch down
        {
            Instantiate(Prefab, _pos.position, _pos.rotation);
        }
    }

    private void UpdateIndicator()
    {
        Indicator.SetActive(isValid);//turn off or on (to visually show status)
        if (!isValid) { return; }//exit if indicator is turned off
        Indicator.transform.SetPositionAndRotation(_pos.position, _pos.rotation);
    }

    private void UpdatePos()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _manager.Raycast(screenCenter, hits, TrackableType.Planes);
        isValid = hits.Count > 0; //testing whether something was hit or not
        if (!isValid) { return; } //exit if nothing was hit

        _pos = hits[0].pose;
        var forward = Camera.main.transform.forward;
        var bearing = new Vector3(forward.x, 0, forward.z).normalized;
        _pos.rotation = Quaternion.LookRotation(bearing);
    }
}