using UnityEngine;


public class QualityManager : MonoBehaviour
{
    public GameObject lowqual;
    public GameObject highqual;
    public void Start()
    {
        int level = QualitySettings.GetQualityLevel();
        Debug.Log("Quality level:" + level);
        if (level == 0)
        {
            lowqual.SetActive(true);
            highqual.SetActive(false);
        }
        else
        {
            lowqual.SetActive(false);
            highqual.SetActive(true);
        }
        
    }
}