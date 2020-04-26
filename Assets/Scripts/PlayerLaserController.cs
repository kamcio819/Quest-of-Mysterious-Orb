using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : ExecutableController, IAwakable, IEnableable, IDisaable, IUpdatable, ILateUpdatable
{
    [SerializeField]
    private GameObject leftLaser;

    [SerializeField]
    private GameObject rightLaser;

    [SerializeField]
    private Transform playerBody;

    public void OnIAwake() { }

    public void OnIDisable()
    {
        InputController.mouseRightButtonPressed -= AimLaser;
    }

    public void OnIEnable()
    {
        InputController.mouseRightButtonPressed += AimLaser;
    }

    private void AimLaser(bool obj)
    {
        if (obj)
        {
            float leftLaserAngle = Mathf.LerpAngle(-5, 0.25f, 1f);
            leftLaser.transform.localEulerAngles = new Vector3(0, leftLaserAngle, 0);

            float rightLaserAngle = Mathf.LerpAngle(5, -0.25f, 1f);
            rightLaser.transform.localEulerAngles = new Vector3(0, rightLaserAngle, 0);
        }
        else
        {
            leftLaser.transform.localEulerAngles = new Vector3(0, -5, 0);
            rightLaser.transform.localEulerAngles = new Vector3(0, 5, 0);
        }

    }

    public void OnIUpdate() { }

    public void OnILateUpdate() { }
}
