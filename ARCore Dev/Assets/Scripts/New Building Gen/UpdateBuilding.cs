using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBuilding : MonoBehaviour
{
    public GameObject buildingManager;
    Vector3 tempLocalScale;

    private float heightVariance;
    private float hvMin;
    private float hvMax;

    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("Base");

        hvMin = buildingManager.GetComponent<BuildingManager>().heightVarianceMin;
        hvMax = buildingManager.GetComponent<BuildingManager>().heightVarianceMax;

        heightVariance = Random.Range(hvMin, hvMax);

        tempLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        tempLocalScale.y = buildingManager.GetComponent<BuildingManager>().buildingHeight * heightVariance;
        tempLocalScale.x = buildingManager.GetComponent<BuildingManager>().buildingX;
        tempLocalScale.z = buildingManager.GetComponent<BuildingManager>().buildingZ;

        transform.localScale = tempLocalScale;
    }
}
