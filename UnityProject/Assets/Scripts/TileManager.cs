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

    private void OnTriggerEnter(Collider other)
    {
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
            thisTransform.localPosition = Berp(startPos, endPos, i);
            thisTransform.localRotation = Quaternion.Lerp(startRotation, endRotation, i);
       
            // Debug.Log(thisTransform.localPosition + " Pos");
            yield return null;
        }
        thisTransform.gameObject.SetActive(finalState);

    }
    public  Vector3 Berp(Vector3 start, Vector3 end, float value)
    {
        return new Vector3(Berp(start.x, end.x, value), Berp(start.y, end.y, value), Berp(start.z, end.z, value));
    }
    public static float Berp(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        return start + (end - start) * value;
    }
}
