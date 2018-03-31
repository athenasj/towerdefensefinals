using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public Node target;
    public GameObject UpgradeBar;
    public TurretBlueprint upgradeStandard;
    public TurretBlueprint upgradeMissile;
    BuildManager buildManager;
    bool makeObjActive;
    // Use this for initialization
    void Start()
    {
        makeObjActive = false;
        UpgradeBar.SetActive(makeObjActive);
    }

    void Update()
    {
        UpgradeBar.SetActive(makeObjActive);
    }

    public void ChangePos(Node theNode)
    {
        target = theNode;
        //Debug.Log("Target:"+target.name);
        //Debug.Log(UpgradeBar.name);
        //Debug.Log(gameObject.name);
        transform.position = target.GetBuildPosition();
        UpgradeBar.SetActive(true);
        makeObjActive = true;
        //Debug.Log("State: "+UpgradeBar.activeSelf);
        //Debug.Log("upgrade bar set active true");
    }

    public void Hide()
    {
        //Debug.Log("in upgrade HIDE");
        makeObjActive = false;
        UpgradeBar.SetActive(false);
    }

    public void UpgradeButton()
    {
        // make target call other function pass node here -> buildmanager build on node
        //Debug.Log(target.name);

        Node forUp = target.GetComponent<Node>();
        if (forUp.turret.name.Contains("Standard"))
        {
            forUp.ForUpgrade(upgradeStandard, target);
            Debug.Log("standard upgrade");
        }else if (forUp.turret.name.Contains("Missile"))
        {
            forUp.ForUpgrade(upgradeMissile, target);
            Debug.Log("missile upgrade");
        }
        makeObjActive = false;


        /*
         * I HAVE TARGET. I NEED FOR UPGRADE FROM BUILDMANAGER. MAINLY I NEED TYPE OF TURRENT PRESENT
         * 
         * if (target.currentTurret.name.Contains("Standard"))
        {
            Debug.Log("Standard Upgrade Turrent Selected");
            buildManager.ForUpgrade(upgradeStandard,target);
            
        }
        HINT TO SELF: GET CODE FROM PREVIOUS UPDATE GET COMPONENT
         
         */
    }
}
