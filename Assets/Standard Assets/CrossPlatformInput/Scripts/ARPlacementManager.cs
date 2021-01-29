﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARPlacementManager : MonoBehaviour
{

    ARRaycastManager m_aRRaycastManager;
    static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    public Camera arCamera;
    public GameObject Arena;

    private void Awake()
    {
        m_aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = arCamera.ScreenPointToRay(centerOfScreen);

        if (m_aRRaycastManager.Raycast(ray, raycastHits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = raycastHits[0].pose;
            Vector3 positionToBePlaced = hitPose.position;
            Arena.transform.position = positionToBePlaced;
        }
    }
}
