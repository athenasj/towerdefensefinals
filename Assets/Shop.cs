using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret() //copy paste for other turrets, dont forget to change properties > onclick()
    {
        Debug.Log("Standard Turrent Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }


}
