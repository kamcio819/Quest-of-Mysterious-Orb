using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystemManager : MonoBehaviour
{
    [SerializeField]
    private List<InputController> inputControllers;

    [SerializeField]
    private List<MovingController> movementControllers;

    private void Awake() {

    }

    private void OnEnable() {
        inputControllers.ForEach((x) =>  {
            (x as IEnableable).OnIEnable();
        });
        movementControllers.ForEach((x) => {
            (x as IEnableable).OnIEnable();
        });
    }

    private void OnDisable() {
        inputControllers.ForEach((x) =>  {
            (x as IDisaable).OnIDisable();
        });
        movementControllers.ForEach((x) => {
            (x as IDisaable).OnIDisable();
        });
    }

    private void Start() {

    }

    private void Update() {
        inputControllers.ForEach((x) =>  {
            (x as IUpdatable).OnIUpdate();
        });
        movementControllers.ForEach((x) => {
            (x as IUpdatable).OnIUpdate();
        });
    }


}
