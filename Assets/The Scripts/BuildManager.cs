using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance; // to make only 1 instance of buildmanager, easier way to access / build manager inside build manager / could be acess on other

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab; //copy paste for another turret


    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one buildmanager!");
        }
        instance = this; // every start only 1 build manager
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
