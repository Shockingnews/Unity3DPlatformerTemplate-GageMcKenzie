using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZipLineScript : MonoBehaviour
{
    [SerializeField] private ZipLineScript targetZip;
    [SerializeField] private float Zipspeed = 5f;
    [SerializeField] private float arrival = 0.4f;

    static GameObject player;

    public Transform ZipTransform;

    private bool onZippLine = false;
    private GameObject localZipLine;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player  == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //if (!onZippLine) return;
        localZipLine.GetComponent<Rigidbody>().AddForce((targetZip.ZipTransform.position - ZipTransform.position));
        if (Vector3.Distance(localZipLine.transform.position, targetZip.ZipTransform.position) <= arrival)
        {
            ResetZip();
        }
    }

    public void StartZipLine()
    {
        if (onZippLine) return;
        localZipLine = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        localZipLine.transform.position = ZipTransform.position;
        localZipLine.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        localZipLine.AddComponent<Rigidbody>().useGravity = false;
        localZipLine.GetComponent<Collider>().isTrigger = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player.GetComponent<PlayerController>().enabled = false;
        //player.GetComponent<PlayerInput>().enabled = false;
        onZippLine = true;
    }

    private void ResetZip()
    {
        if (!onZippLine) return;
        player = localZipLine.transform.GetChild(0).gameObject;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player.GetComponent<PlayerController>().enabled = true;
        //player.GetComponent<PlayerInput>().enabled = true;
        Destroy(localZipLine);
        onZippLine = false;
    }
}
