using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    //Tags
    public string GroundTag = "Ground";

    public string PotTag = "Pot";
    public string PlantTag = "Plant";

    //Objects
    public GameObject[] Pots;

    public GameObject[] Plants;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var go = hit.transform.gameObject;
                if (go.tag == GroundTag)
                {
                    //Debug.Log("Ground");
                    float width = Random.Range(1.0f, 2f);
                    float height = Random.Range(1.0f, 4f);
                    int potIndex = Random.Range(0, Pots.Length);
                    GameObject pot = GameObject.Instantiate(Pots[potIndex], hit.point, Quaternion.identity);
                    pot.transform.localScale = new Vector3(width, height, width);
                }
                else if (go.tag == PotTag)
                {
                    //Debug.Log("Pot");
                    var plantIndex = Random.Range(0, Pots.Length);
                    var pot = hit.transform.gameObject.transform.parent.gameObject; //using pot as input instead of random
                    var pos = pot.transform.position;
                    pos.y += pot.transform.localScale.y * 2 * 0.9f;
                    var plant = GameObject.Instantiate(Plants[plantIndex], pos, Quaternion.identity);
                    plant.transform.localScale = pot.transform.localScale;
                }
                else if (go.tag == PlantTag)
                {
                    var plant = hit.transform.gameObject.transform.parent.gameObject;
                    Destroy(plant);
                }
            }
        }
    }
}