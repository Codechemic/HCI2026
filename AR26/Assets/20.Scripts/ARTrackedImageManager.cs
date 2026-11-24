
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImagePrefabManager : MonoBehaviour
{
    [System.Serializable]
    public class ImagePrefab
    {
        public string imageName;
        public GameObject prefab;
    }

    [Header("AR Tracked Image Manager")]
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;

    [Header("Image Prefab List")]
    [SerializeField]
    private ImagePrefab[] imagePrefabs;

    private Dictionary<string, GameObject> prefabDictionary =
        new Dictionary<string, GameObject>();

    private Dictionary<TrackableId, GameObject> spawnedObjects =
        new Dictionary<TrackableId, GameObject>();

    private void Awake()
    {
        foreach (ImagePrefab item in imagePrefabs)
        {
            if (item.prefab != null)
            {
                prefabDictionary[item.imageName] = item.prefab;
            }
        }
    }

    private void OnEnable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackablesChanged.AddListener(
                OnTrackablesChanged
            );
        }
    }

    private void OnDisable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackablesChanged.RemoveListener(
                OnTrackablesChanged
            );
        }
    }

    private void OnTrackablesChanged(
    ARTrackablesChangedEventArgs<ARTrackedImage> changes)
    {
        foreach (var trackedImage in changes.added)
        {
            CreatePrefab(trackedImage);
        }

        foreach (var trackedImage in changes.updated)
        {
            UpdatePrefab(trackedImage);
        }

        foreach (var trackedImage in changes.removed)
        {
            RemovePrefab(trackedImage.Key);
        }
    }

    private void CreatePrefab(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (!prefabDictionary.TryGetValue(imageName, out GameObject prefab))
        {
            Debug.LogWarning("Prefab not found: " + imageName);
            return;
        }

        if (spawnedObjects.ContainsKey(trackedImage.trackableId))
            return;

        GameObject obj = Instantiate(
            prefab,
            trackedImage.transform
        );

        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        spawnedObjects.Add(trackedImage.trackableId, obj);
    }

    private void UpdatePrefab(ARTrackedImage trackedImage)
    {
        if (!spawnedObjects.TryGetValue(
            trackedImage.trackableId, out GameObject obj))
            return;

        obj.SetActive(
            trackedImage.trackingState == TrackingState.Tracking
        );
    }

private void RemovePrefab(TrackableId trackableId)
{
    if (spawnedObjects.TryGetValue(
        trackableId, out GameObject obj))
    {
        Destroy(obj);
        spawnedObjects.Remove(trackableId);
    }
}
}
