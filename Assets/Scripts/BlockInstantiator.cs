using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiator : MonoBehaviour
{
    public GameObject prefab;
    public float speed = 1;
    private float _timer = 0;
    private GameObject _parent;

    // Start is called before the first frame update
    private void Start()
    {
        _parent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        _parent.name = "BlockParent";
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime; //Debug.Log(_timer);
        if (_timer > speed)
        {
            DropBlock();
            _timer = 0; //reset time
        }

        if (Input.GetKeyDown(KeyCode.Space))//(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Zero");
            DropBlock();
        }
    }

    private void DropBlock()
    {
        var block = Instantiate(prefab, this.transform.position, Quaternion.identity);
        block.transform.parent = _parent.transform;
    }
}