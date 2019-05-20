using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : ExecutableController, IEnableable, IDisaable, IUpdatable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private List<OrbSlot> orbsCollection;

    [SerializeField]
    private Image healthBar;

    private int index = 0;

    public void SetOrbsButtons(OrbData orbData) {
        OrbSlot orbSlot = orbsCollection[index];
        orbSlot.GetComponent<RawImage>().texture = orbData.OrbRenderTexture;
        index++;
        index %= 3;
    }

    public void OnIAwake() {}

    public void OnIEnable() {}

    public void OnIUpdate() {}

    public void OnIDisable() {}

    public void OnILateUpdate() {}

    public void RemoveHealthFromBar(float value) {
        healthBar.fillAmount = value/100;
    }
}
