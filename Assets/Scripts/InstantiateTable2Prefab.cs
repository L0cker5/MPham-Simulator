using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class InstantiateTableTwoPrefab : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    [SerializeField, Tooltip("Prefab to be placed into the scene, or object in the scene to be moved around.")]
    public GameObject tablePrefab;
    private OVRAnchor table;


    public float UpdateFrequencySeconds = 5;

    List<(GameObject, OVRLocatable)> _tableObjects = new List<(GameObject, OVRLocatable)>();

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
        var secondTableAnchors = new List<OVRAnchor>();
        //var wallArtAnchors = new List<OVRAnchor>();
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
                    labels.Labels.Contains(OVRSceneManager.Classification.Table))
                {
                    secondTableAnchors.Add(anchor);
                }

            }

            // get the second anchor in the list
            table = secondTableAnchors[1];

            await SpawnOnTable(tablePrefab, roomObject, table);
        }).ToList();
        await Task.WhenAll(tasks);

    }

    async Task SpawnOnTable(GameObject prefab, GameObject roomGameObject, OVRAnchor table)
    {

            // enable locatable/tracking by checking for the presence of an OVRLocatable component.
            if (!table.TryGetComponent(out OVRLocatable locatable))
                return;
            await locatable.SetEnabledAsync(true);

            // get semantic classification for object _name
            var label = "other";
            table.TryGetComponent(out OVRSemanticLabels labels);
            label = labels.Labels;

            // create container object
            var gameObject = new GameObject(label);
            gameObject.transform.SetParent(roomGameObject.transform);
            var helper = new InstantiateHelper(gameObject);
            helper.SetTableTwoLocation(locatable);

            Instantiate(prefab, gameObject.transform);

            _tableObjects.Add((gameObject, locatable));

    }

    IEnumerator UpdateAnchorsPeriodically()
    {
        while (true)
        {
            foreach (var (gameObject, locatable) in _tableObjects)
            {
                var helper = new InstantiateHelper(gameObject);
                helper.SetTableTwoLocation(locatable);
            }

            yield return new WaitForSeconds(UpdateFrequencySeconds);
        }
    }
}
