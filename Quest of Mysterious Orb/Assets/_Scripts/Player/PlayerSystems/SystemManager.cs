using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SystemManager : Singleton<SystemManager>
{
    [SerializeField]
    private List<Controller> controllers;

    private void Awake() {
        controllers.ForEach((x) =>  {
            (x as IAwakable).OnIAwake();
        });
    }

    private void OnEnable() {
        controllers.ForEach((x) =>  {
            (x as IEnableable).OnIEnable();
        });
        
    }

    private void OnDisable() {
        controllers.ForEach((x) =>  {
            (x as IDisaable).OnIDisable();
        });
    }

    private void Start() {

    }

    private void Update() {
        controllers.ForEach((x) =>  {
            (x as IUpdatable).OnIUpdate();
        });
        
    }

    private void LateUpdate() {
        controllers.ForEach((x) => {
            (x as ILateUpdatable).OnILateUpdate();
        });
    }

    private void FixedUpdate() {

    }

    [ContextMenu ("Load controllers")]
    void LoadControllers () {
        controllers = FindObjectsOfType<Controller>().ToList();
    }   
}
