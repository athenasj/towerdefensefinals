
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret; //current turret

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown() 
    {
        if (EventSystem.current.IsPointerOverGameObject()) //if shop touches node then clicked, this will prevent putting turrets on that node accidentally
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        } 

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter() //triggers when mouse hit the content of a collider
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
           return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
