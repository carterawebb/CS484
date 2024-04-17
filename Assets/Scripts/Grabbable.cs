using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : XRGrabInteractable
{

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on grab");
            return;
        }

        manager.SomethingGrabbed(transform.root.gameObject);

        base.OnSelectEntered(args);
    }
    /*protected override void Grab() // is this the right event? No, it isn't
    {
        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on grab");
            return;
        }

        manager.SomethingGrabbed(transform.root.gameObject);
        base.Grab();
    }*/

    protected override void Drop() // works
    {
        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on detach");
            return;
        }

        manager.SomethingDropped(transform.root.gameObject);
        base.Drop();
    }
}