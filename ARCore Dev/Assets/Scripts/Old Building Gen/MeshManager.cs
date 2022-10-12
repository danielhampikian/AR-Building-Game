using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour
{

    public float meshHeight = 1f;

    public float meshScaleMin = .1f;

    public float posOffset = .04f;

    public int numOfBuildings = 20;
    private int tempBuildingNum;

    public float meshZScale = 1f;
    public float meshXScale = 1f;

    public GameObject buildingPrefab;
    private GameObject building;

    public List<GameObject> allBuildings;

    void Update() {

        if(tempBuildingNum != numOfBuildings) {
            GenerateBuildings();
            tempBuildingNum = numOfBuildings;
        }

    }

    void GenerateBuildings() {

        foreach (GameObject building in allBuildings) {
            Destroy(building);
        }

        for(int i = 0; i < numOfBuildings; i++) {
            float x = Random.Range(transform.position.x - posOffset, transform.position.x + posOffset);
            float z = Random.Range(transform.position.z - posOffset, transform.position.z + posOffset);

            Vector3 pos = new Vector3(x, transform.position.y + .05f, z);

            building = Instantiate(buildingPrefab, pos, Quaternion.AngleAxis(Random.Range(0,360), Vector3.up));

            building.transform.SetParent(this.transform);
            allBuildings.Add(building);

        }
    }


}
