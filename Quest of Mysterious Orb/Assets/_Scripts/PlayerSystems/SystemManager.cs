using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SystemManager : Singleton<SystemManager>
{
    [SerializeField]
    private List<InputController> inputControllers;

    [SerializeField]
    private List<PlayerMovingController> playerMovementControllers;

    [SerializeField]
    private List<CameraMovingController> cameraMovementController;

    [SerializeField]
    private List<RotationController> rotationControllers;

    private void Awake() {

    }

    private void OnEnable() {
        inputControllers.ForEach((x) =>  {
            (x as IEnableable).OnIEnable();
        });
        playerMovementControllers.ForEach((x) => {
            (x as IEnableable).OnIEnable();
        });
        cameraMovementController.ForEach((x) => {
            (x as IEnableable).OnIEnable();
        });
        rotationControllers.ForEach((x) => {
            (x as IEnableable).OnIEnable();
        });
    }

    private void OnDisable() {
        inputControllers.ForEach((x) =>  {
            (x as IDisaable).OnIDisable();
        });
        playerMovementControllers.ForEach((x) => {
            (x as IDisaable).OnIDisable();
        });
        cameraMovementController.ForEach((x) => {
            (x as IDisaable).OnIDisable();
        });
        rotationControllers.ForEach((x) => {
            (x as IDisaable).OnIDisable();
        });
    }

    private void Start() {

    }

    private void Update() {
        inputControllers.ForEach((x) =>  {
            (x as IUpdatable).OnIUpdate();
        });
        playerMovementControllers.ForEach((x) => {
            (x as IUpdatable).OnIUpdate();
        });
        cameraMovementController.ForEach((x) => {
            (x as IUpdatable).OnIUpdate();
        });
        rotationControllers.ForEach((x) => {
            (x as IUpdatable).OnIUpdate();
        });
    }

    private void FixedUpdate() {

    }

    [ContextMenu ("Load controllers")]
    void LoadControllers () {
        inputControllers = FindObjectsOfType<InputController>().ToList();
        playerMovementControllers = FindObjectsOfType<PlayerMovingController>().ToList();
        cameraMovementController = FindObjectsOfType<CameraMovingController>().ToList();
        rotationControllers = FindObjectsOfType<RotationController>().ToList();
    }   
}
