using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ArPlacementeAndPlaneDetectionController : MonoBehaviour
{
    ARPlacementManager m_ARPlacement;
    ARPlaneManager m_ARPlane;

    public GameObject placeButton;
    public GameObject adjustButton;
    public GameObject controlButton;
    //public TextMeshProUGUI infoText;

    private void Awake()
    {
        m_ARPlacement = GetComponent<ARPlacementManager>();
        m_ARPlane = GetComponent<ARPlaneManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //infoText.text = "Mueve tu dispositivo y coloca el escenario.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAllPlanesActiveOrDeactive(bool value)
    {
        foreach (var plane in m_ARPlane.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

    public void DisablePlacementAndDetection()
    {
        m_ARPlacement.enabled = false;
        m_ARPlane.enabled = false;

        SetAllPlanesActiveOrDeactive(false);

        placeButton.SetActive(false);
        adjustButton.SetActive(true);
    }

    public void EnablePlacementAndDetection()
    {
        m_ARPlacement.enabled = true;
        m_ARPlane.enabled = true;

        SetAllPlanesActiveOrDeactive(true);

        placeButton.SetActive(true);
        adjustButton.SetActive(false);
    }
}
