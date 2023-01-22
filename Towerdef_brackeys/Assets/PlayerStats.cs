using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 400;

    void Start()
    {
        Money = StartMoney;    
    }
}
