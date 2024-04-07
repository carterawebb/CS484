using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour {
    public GameObject leftRay;
    public GameObject rightRay;

    public XRDirectInteractor leftInteractor;
    public XRDirectInteractor rightInteractor;

    private void Update() {
        leftRay.SetActive(leftInteractor.interactablesSelected.Count == 0);
        rightRay.SetActive(rightInteractor.interactablesSelected.Count == 0);
    }
}
