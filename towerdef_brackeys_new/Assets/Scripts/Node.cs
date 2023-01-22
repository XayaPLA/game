using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverNodeColor, BaseNodeColor, NoMoneyNodeColor;
    public Vector3 PositionOffset;
    [Header ("Optional")]
    public GameObject turret;

    private Renderer rend;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        BaseNodeColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("You can't build here");
            return;
        }

        buildManager.BuildTurretOn(this);   
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = HoverNodeColor;
        }
        else
        {
            rend.material.color = NoMoneyNodeColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = BaseNodeColor;
    }
}
