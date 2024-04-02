using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using static OVRPlugin;
using UnityEngine.UIElements;

public class InstantiateWallArtPrefab : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField, Tooltip("Prefab to be placed into the scene, or object in the scene to be moved around.")]
    public GameObject wallArtPrefab;

    private OVRAnchor wallArt;

    public float UpdateFrequencySeconds = 5;

        List<(GameObject, OVRLocatable)> _wallArtObjects = new List<(GameObject, OVRLocatable)>();

    // List of Room Anchors https://developer.oculus.com/documentation/unity/unity-scene-ovranchor/
    void Start()
    {
        SpawnStart();
        StartCoroutine(UpdateAnchorsPeriodically());
    }


    // Start is called before the first frame update
    async void SpawnStart()
    {
        // fetch all rooms, with a SceneCapture fallback
        var rooms = new List<OVRAnchor>();
        var tableAnchors = new List<OVRAnchor>();
        var wallArtAnchors = new List<OVRAnchor>();
        
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(rooms);
        if (rooms.Count == 0)
        {
            var sceneCaptured = await InstantiateHelper.RequestSceneCapture();
            if (!sceneCaptured)
                return;

            await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(rooms);
        }
        // fetch room elements, create objects for them
        var tasks = rooms.Select(async room =>
        {
            var roomObject = new GameObject($"Room-{room.Uuid}");
            if (!room.TryGetComponent(out OVRAnchorContainer container))
                return;

            var anchors = new List<OVRAnchor>();
            await container.FetchChildrenAsync(anchors);

            foreach (var anchor in anchors)
            {

                if (anchor.TryGetComponent(out OVRSemanticLabels labels) &&
                    labels.Labels.Contains(OVRSceneManager.Classification.WallArt))
                {
                    wallArtAnchors.Add(anchor);
                }

            }

            wallArt = wallArtAnchors[0];

            await SpawnOnWallArt(wallArtPrefab, roomObject, wallArt);
        }).ToList();
        await Task.WhenAll(tasks);

    }

    async Task SpawnOnWallArt(GameObject prefab, GameObject roomGameObject, OVRAnchor wallArt)
    {
        // creates an instance "test" from the TestProps script and access the TestProps script attached to the prefab (GameObject)
        TestProps test = wallArtPrefab.GetComponent<TestProps>();

        float objectDepth = 0;
        // assigns the value of test.objHeight to the variable objectHeight
        objectDepth = test.objDepth;
        // get half of the height
        float halfDepth = objectDepth / 2.0f;

        // enable locatable/tracking by checking for the presence of an OVRLocatable component.
        if (!wallArt.TryGetComponent(out OVRLocatable locatable))
                return;
            await locatable.SetEnabledAsync(true);

            // get semantic classification for object name
            var label = "other";
            wallArt.TryGetComponent(out OVRSemanticLabels labels);
            label = labels.Labels;

            // create container object
            var gameObject = new GameObject(label);
            gameObject.transform.SetParent(roomGameObject.transform);
            var helper = new InstantiateHelper(gameObject);
            helper.SetWallArtLocation(locatable);
        
            var position = gameObject.transform.position + (Vector3.left * halfDepth);

            gameObject.transform.SetPositionAndRotation(position, Quaternion.identity);
        
            Instantiate(prefab, gameObject.transform);

            _wallArtObjects.Add((gameObject, locatable));

    }

    IEnumerator UpdateAnchorsPeriodically()
    {
        while (true)
        {
            foreach (var (gameObject, locatable) in _wallArtObjects)
            {
                var helper = new InstantiateHelper(gameObject);
                helper.SetWallArtLocation(locatable);
            }

            yield return new WaitForSeconds(UpdateFrequencySeconds);
        }
    }
}
