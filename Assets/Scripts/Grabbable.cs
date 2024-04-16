using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : XRGrabInteractable
{
    protected override void Grab() // is this the right event?
    {
        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on grab");
            return;
        }

        manager.SomethingGrabbed(transform.root.gameObject);
    }

    protected override void Drop() // works
    {
        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on detach");
            return;
        }

        manager.SomethingDropped(transform.root.gameObject);
    }
}