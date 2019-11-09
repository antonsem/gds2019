using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    [SerializeField]
    private Transform Tile;
    [SerializeField]
    private Transform childObject;
    [SerializeField]
    Vector3 spawnPosition;
    [SerializeField]
    Quaternion spawnRotation;
    [SerializeField]
    private float speed = 5f;


    private Vector3 initPosition;
    private Quaternion initRotation;
    private Vector3 initScale;
    private bool animate = false;
    IEnumerator currentCorutine = null;

    void Start()
    {
        initPosition = Tile.localPosition;
        initRotation = Tile.localRotation;



        speed += Random.Range(-0.5f, 0.5f);
        Tile.gameObject.SetActive(false);
        Tile.transform.localPosition = spawnPosition;
        Tile.transform.localRotation = spawnRotation;
        if (childObject != null)
        {
            Instantiate(childObject,Tile);
           // childObject.transform.localScale = Vector3.zero;
        }
    }

    // Move to the target end position.
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        Tile.gameObject.SetActive(true);
        if (currentCorutine != null)
        {
            StopCoroutine(currentCorutine);
        }
        StartCoroutine(MoveObject(Tile, Tile.localPosition, initPosition, Tile.localRotation,initRotation ,true));
    }



    private void OnTriggerExit(Collider other)
    {
        Tile.gameObject.SetActive(false);
        if (currentCorutine != null)
        {
            StopCoroutine(currentCorutine);
        }
        StartCoroutine(MoveObject(Tile, Tile.localPosition, spawnPosition, Tile.localRotation, spawnRotation, false));
    }

    private IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, Quaternion startRotation, Quaternion endRotation, bool finalState)
    {
        thisTransform.gameObject.SetActive(true);
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime * speed;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
            thisTransform.localRotation = Quaternion.Lerp(startRotation, endRotation, i);
       
            // Debug.Log(thisTransform.localPosition + " Pos");
            yield return null;
        }
        thisTransform.gameObject.SetActive(finalState);

    }
}
