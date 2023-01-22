using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public GameObject BuildEffect;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one BuildManager in scene!!");
            return;
        }
        Instance = this;
    }

    public GameObject StandardTurretPrefab;
    public GameObject MissleLauncherPrefab;
    private TurretBlueprint TurretToBuild;


    public bool CanBuild { get { return TurretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= TurretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint Turret)
    {
        TurretToBuild = Turret;
    }   

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < TurretToBuild.cost)
        {
            Debug.Log("No Money");
            return;
        }

        GameObject turret = (GameObject) Instantiate(TurretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        
        GameObject Effect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(Effect, 1f);

        PlayerStats.Money -= TurretToBuild.cost;
        Debug.Log("Money left: " + PlayerStats.Money);
    }
}
