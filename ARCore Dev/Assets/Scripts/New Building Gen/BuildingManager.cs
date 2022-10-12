using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public int numOfBuildings = 0;
    private int tempBuildingNum;

    public float buildingHeight;
    
    //Each time a building is newly generated (like when num of buildings change) 
    //the building height is multipled by a random number between the min and max 
    public float heightVarianceMin;
    public float heightVarianceMax;

    public float buildingX;
    public float buildingZ;


    public GameObject buildingPrefab;
    public GameObject baseGameObject;

    private GameObject building;
    private Renderer baseRend;

    public List<GameObject> allBuildings;

    private Vector3 baseMax;
    private Vector3 baseMin;

    public float edgeOffset;

    void Start() {
        //Find min and max points buildings should generate to
        baseRend = baseGameObject.GetComponent<Renderer>();
    }

    void Update() {

        //Regenerate everything if num of buildings change
        if(tempBuildingNum != numOfBuildings) {
            GenerateBuildings();
            tempBuildingNum = numOfBuildings;
        }

    }

    void GenerateBuildings() {
        
        //Destroy all current buildings before remaking them
        if (allBuildings.Count > 0) {
            foreach (GameObject building in allBuildings) {
                Destroy(building);
            }
        }

        //Loop through all buildings and place them on base
        for(int i = 0; i < numOfBuildings; i++) {

            //Get random points within cube to place buildings
            baseMax = baseRend.bounds.max - new Vector3 (edgeOffset, 0, edgeOffset);
            baseMin = baseRend.bounds.min + new Vector3 (edgeOffset, 0, edgeOffset);
            float x = Random.Range(baseMax.x, baseMin.x);
            float z = Random.Range(baseMax.z, baseMin.z);

            //Set points to random position and height to the base plane height
            Vector3 pos = new Vector3(x, baseGameObject.transform.position.y, z);

            //Reinstantiate the buildings with random rotation
            building = Instantiate(buildingPrefab, pos, Quaternion.AngleAxis(Random.Range(0,360), Vector3.up));

            building.transform.localScale += new Vector3 (0, buildingHeight, 0);

            //Set the buildings as a child to the building manager in the hierarchy for neatness 
            building.transform.SetParent(this.transform);

            //Add building to list of all buildings
            allBuildings.Add(building);
        }
    }
}
