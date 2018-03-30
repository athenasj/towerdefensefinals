
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret; //current turret

    public static GameObject currentTurret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public void ForUpgrade(TurretBlueprint upgradeTo, Node _node)
    {
        RemoveTurret();
        BuildHere(upgradeTo);
        Debug.Log("Node, for upgrade");
    }

    public void BuildHere(TurretBlueprint upgradeTo)
    {
        if (PlayerStats.Money < upgradeTo.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= upgradeTo.cost;

        GameObject turretGO = (GameObject)Instantiate(upgradeTo.prefab, GetBuildPosition(), Quaternion.identity);
        turret = turretGO;

        Debug.Log("Turret allowed. Money left: " + PlayerStats.Money);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    public void RemoveTurret()
    {
        Destroy(turret);
    }


    void OnMouseDown() 
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if shop touches node then clicked, this will prevent putting turrets on that node accidentally
        {
            return;
        }

        

        if(turret != null)
        {
            buildManager.SelectNode(this);
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    void OnMouseEnter() //triggers when mouse hit the content of a collider
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughColor;
        }

        if (!buildManager.CanBuild)
        {
            rend.material.color = notEnoughColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
