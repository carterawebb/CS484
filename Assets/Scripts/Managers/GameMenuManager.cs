using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour {
    public GameObject gameMenu;
    public InputActionProperty showMenu;

    public Transform playerHead;
    public float distanceFromHead = 2.0f;

    private void Update() {
        if (showMenu.action.WasPressedThisFrame()) {
            gameMenu.SetActive(!gameMenu.activeSelf);

            gameMenu.transform.position = playerHead.position + new Vector3(playerHead.forward.x, 0, playerHead.forward.z).normalized * distanceFromHead;
        }

        gameMenu.transform.LookAt(new Vector3(playerHead.position.x, gameMenu.transform.position.y, playerHead.position.z));
        gameMenu.transform.forward *= -1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
