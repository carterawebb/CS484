using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour {
    public GameObject leftRay;
    public GameObject rightRay;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    private void Update() {
        leftRay.SetActive(leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);
        rightRay.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
