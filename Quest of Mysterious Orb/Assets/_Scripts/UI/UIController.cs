using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : ExecutableController, IEnableable, IDisaable, IUpdatable, ILateUpdatable
{
    [SerializeField]
    private List<OrbSlot> orbsCollection;

    private int index = 0;

    public void SetOrbsButtons(OrbData orbData) {
        OrbSlot orbSlot = orbsCollection[index];
        orbSlot.GetComponent<RawImage>().texture = orbData.OrbRenderTexture;
        index++;
        index %= 3;
    }

    public void OnIEnable() {

    }

    public void OnIUpdate() {

    }

    public void OnIDisable() {

    }

    public void OnILateUpdate() {
        
    }
}
