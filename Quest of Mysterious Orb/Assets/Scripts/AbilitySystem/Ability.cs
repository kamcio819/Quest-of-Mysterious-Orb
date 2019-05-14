using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Orb
{
    public Texture icon;
    public string name;
    public string description;
    public int id;

    public Orb(Orb d)
    {
        icon = d.icon;
        name = d.name;
        description = d.description;
        id = d.id;
    }
}

/* 
 * public class Ability
{
    
    //For every ability:
    public Texture name;
    private string description;
    private Sprite icon;
    private List<AbilityBehaviours> behaviours;
    private bool requiresTarget;
    private bool canCastOnSelf;
    private float cooldown; //secs
    private GameObject particleEffect; //needs to be assigned when we create the ability

    public Ability(string aname, Sprite aicon, List<AbilityBehaviours> abehaviours)
    {
        name = aname;
        icon = aicon;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = 0;
        requiresTarget = false;
        canCastOnSelf = false;
        description = "Default";
    }

    public Ability(string aname, string adescription, Sprite aicon, List<AbilityBehaviours> abehaviours)
    {
        name = aname;
        icon = aicon;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = 0;
        requiresTarget = false;
        canCastOnSelf = false;
        description = "Default";
    }

    public Ability(string aname, string adescription, Sprite aicon, List<AbilityBehaviours> abehaviours, bool arequiresTarget, int acooldown, GameObject aparticleEffect)
    {
        name = aname;
        icon = aicon;
        behaviours = new List<AbilityBehaviours>();
        behaviours = abehaviours;
        cooldown = acooldown;
        requiresTarget = arequiresTarget;
        canCastOnSelf = aparticleEffect;
        description = adescription;
        particleEffect = aparticleEffect;
    }

    public string AbilityName
    {
        get { return name; }
    }

    public string AbilityDescription
    {
        get { return description; }
    }

    public Sprite AbilityIcon
    {
        get { return icon; }
    }

    public float AbilityCooldown
    {
        get { return cooldown; }
    }

    public List<AbilityBehaviours> AbilityBehaviours
    {
        get { return behaviours; }
    }

}
*/