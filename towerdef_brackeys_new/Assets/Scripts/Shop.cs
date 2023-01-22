using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.Instance;    
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected!");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected!");
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}
