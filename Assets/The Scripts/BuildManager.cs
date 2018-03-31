using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance; // to make only 1 instance of buildmanager, easier way to access / build manager inside build manager / could be acess on other

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab; //copy paste for another turret
    public GameObject missileTurretPrefab;
    public GameObject cheapTurretPrefab;
    public Node selectedNode;
    public bool upAllowed;
    public static bool upgradeAllowed = true;

    void Update()
    {
        upgradeAllowed = upAllowed;
    }
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one buildmanager!");
        }
        instance = this; // every start only 1 build manager
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public Upgrade upgrade;

    public void SelectNode(Node node)
    {
        Node forUp = node.GetComponent<Node>();
       
        if (upAllowed && !forUp.nodeUpgraded)
        {
            Debug.Log("up allowed!");
            if (selectedNode == node)
            {
                upgrade.Hide();
                selectedNode = null;
                return;
            }
            upgrade.ChangePos(node);
            selectedNode = node;
            turretToBuild = null;
        }
    }
    

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        upgrade.Hide();
    }

    public void BuildTurretOn (Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret allowed. Money left: " + PlayerStats.Money);
    }

}
