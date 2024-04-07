using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable {
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;

    private void Start() {
        if (!attachTransform) {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        } else {
            initialAttachLocalPos = attachTransform.localPosition;
            initialAttachLocalRot = attachTransform.localRotation;
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args) {
        if (args.interactorObject is XRDirectInteractor) {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        } else {
            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }

        base.OnSelectEntered(args);
    }
}
