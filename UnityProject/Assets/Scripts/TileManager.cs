using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Tile;
    [SerializeField]
    Vector3 spawnPosition;
    [SerializeField]
    private float speed = 1f;
    private bool animate = false;


    void Start()
    {
        //Tile.SetActive(false);
        // Keep a note of the time the movement started.
        speed += Random.Range(-0.5f, 0.5f);

    }

    // Move to the target end position.
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        Tile.SetActive(true);
        StartCoroutine(MoveObject(Tile.transform, spawnPosition, Vector3.zero));
    }

    private void OnTriggerExit(Collider other)
    {
        Tile.SetActive(false);
    }

    private IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos)
    {
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime * speed;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
            Debug.Log(thisTransform.localPosition + " Pos");
            yield return null;
        }
       
    }
}
