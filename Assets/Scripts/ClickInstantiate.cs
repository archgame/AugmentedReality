using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInstantiate : MonoBehaviour
{
    public LayerMask Mask;
    public GameObject Prefab;

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
            if (Physics.Raycast(ray, out hit, 1000, Mask))
            {
                //Debug.Log("Hit");
                float rand = Random.Range(1.0f, 4f);
                Debug.DrawRay(hit.point, Vector3.up * 3, Color.red, 2);
                Vector3 pos = hit.point;// + new Vector3(0, rand / 2.0f, 0);
                GameObject go = GameObject.Instantiate(Prefab, pos, Quaternion.identity);
                go.transform.localScale = new Vector3(rand, rand, rand);

                var script = FindObjectOfType<NavigationBaker>();
                script.UpdateNavMesh();
            }
        }
    }
}