using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager _rayManager;
    private GameObject _visual;

    private void Start()
    {
        //get the components
        _rayManager = FindObjectOfType<ARRaycastManager>();
        _visual = transform.GetChild(0).gameObject;

        //hide the placement visual
        _visual.SetActive(false);
    }

    private void Update()
    {
        //shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if we hit an AR Plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!_visual.activeInHierarchy)
            {
                _visual.SetActive(true);
            }
        }
    }
}
