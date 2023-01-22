using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

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
        PlayerStats.Money -= TurretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(TurretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Money left: " + PlayerStats.Money);
    }
}
