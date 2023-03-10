using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCommands : MonoBehaviour
{
    public GameObject gunPrefab;
    

    public void SpawnGun()
    {
        GameObject Gun = Instantiate(gunPrefab);
        Gun.transform.position = this.transform.position;
    }

    public void ClearGuns(){
        gun[] allObjects = FindObjectsOfType<gun>();
        foreach(gun obj in allObjects) {
            
            Destroy(obj);
        }
    }
}
