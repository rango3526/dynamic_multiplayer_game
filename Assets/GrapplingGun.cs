using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial for Grappling Hook: https://www.youtube.com/watch?v=Xgh4v1w5DxU

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 1500f;
    private SpringJoint joint;

    

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
            Debug.Log("Click!");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
       
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        // gameObject.GetComponent<CharacterController>().enabled = false;

        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            // The distance grapple will try to keep from grapple point
            joint.maxDistance = distanceFromPoint * 0.05f;
            joint.minDistance = distanceFromPoint * 0.01f;

            // This affects strength of grapple - may change later:
            joint.spring = 10f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    

    void DrawRope()
    {
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
        
    }
}
