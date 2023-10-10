using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTrackedImages : MonoBehaviour
{
    public GameObject[] ARPrefabs; //each element correspond to a reference image in the images manager
    private ARTrackedImageManager _trackedImagesManager;
    private Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>(); //prefabs we've created

    private void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged; //listen to events, looking at video feed for images
    }

    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //1 get new tracked images
        foreach (var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ARPrefabs)
            {
                if (string.Compare(curPrefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) != 0) { continue; }
                if (_instantiatedPrefabs.ContainsKey(imageName)) { continue; } //skip if already added

                var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                _instantiatedPrefabs.Add(imageName, newPrefab);
            }
        }

        //2 if image updated, update prefab
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
            _instantiatedPrefabs[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        }
    }
}