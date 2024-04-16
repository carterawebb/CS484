using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : XRGrabInteractable
{
    /*protected override void Detach() // use detach? or drop? or OnSelectExit??
    {
        Debug.Log("Detach");

        PizzaManager manager = GameObject.FindObjectOfType<PizzaManager>();
        if (manager == null)
        {
            Debug.Log("Could not find a pizza manager on detach");
            return;
        }

        manager.SomethingDropped(transform.root.gameObject);

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
    }

    /*protected override void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("OnSelectExited");
    }*/ // works
}