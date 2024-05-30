using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Used to instantiate the set GameObject prefab at the loaction of a specified type of room anchor
/// </summary>
public class InstantiateTableTwoPrefab : MonoBehaviour
{
    [SerializeField, Tooltip("Prefab to be placed into the scene, or object in the scene to be moved around.")]
    public GameObject tableTwoPrefab;
    
    private OVRAnchor table;

    public float UpdateFrequencySeconds = 5;

    List<(GameObject, OVRLocatable)> _tableTwoObjects = new List<(GameObject, OVRLocatable)>();

    void Awake()
    {
        SpawnStart();
        StartCoroutine(UpdateAnchorsPeriodically());
    }

    // Asynchronously fetches and initializes lists of room and table anchors
    async void SpawnStart()
    {
        // fetch room, with a SceneCapture fallback
        var rooms = new List<OVRAnchor>();
        
        var secondTableAnchors = new List<OVRAnchor>();

        // Fetch room anchors. If none are found, request a scene capture and fetch again.
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
            var roomObject = new GameObject($"{tableTwoPrefab.name}AnchorLocation");
            if (!room.TryGetComponent(out OVRAnchorContainer container))
                return;

            var anchors = new List<OVRAnchor>();
            await container.FetchChildrenAsync(anchors);

            foreach (var anchor in anchors)
            {
                // if the anchor has the semantic classification "Table" add it to the list of secondTableAnchors
                if (anchor.TryGetComponent(out OVRSemanticLabels labels) &&
                    labels.Labels.Contains(OVRSceneManager.Classification.Table))
                {
                    secondTableAnchors.Add(anchor);
                }

            }

            // get the second anchor in the list
            table = secondTableAnchors[1];

            await SpawnOnTable(tableTwoPrefab, roomObject, table);
        }).ToList();
        await Task.WhenAll(tasks);

    }

    /// <summary>
    /// Asynchronously spawns a prefab on a specified table anchor within a room.
    /// </summary>
    /// <param name="prefab">the prefab to be spawned</param>
    /// <param name="roomGameObject">parent gameobject to hold the prefab when instantiated</param>
    /// <param name="table">the anchor where the prefab is to be instantiated</param>
    /// <returns></returns>
    async Task SpawnOnTable(GameObject prefab, GameObject roomGameObject, OVRAnchor table)
    {

            // enable locatable/tracking by checking for the presence of an OVRLocatable component.
            if (!table.TryGetComponent(out OVRLocatable locatable))
                return;
            await locatable.SetEnabledAsync(true);

            // get semantic classification for object
            var label = "other";
            table.TryGetComponent(out OVRSemanticLabels labels);
            label = labels.Labels;

            // create container object
            var gameObject = new GameObject(label);
            gameObject.transform.SetParent(roomGameObject.transform);
            var helper = new InstantiateHelper(gameObject);
            helper.SetTableTwoLocation(locatable);

            Instantiate(prefab, gameObject.transform);

            _tableTwoObjects.Add((gameObject, locatable));

    }

    /// <summary>
    /// Coroutine that periodically updates the positions of the anchors.
    /// </summary>
    IEnumerator UpdateAnchorsPeriodically()
    {
        while (true)
        {
            foreach (var (gameObject, locatable) in _tableTwoObjects)
            {
                var helper = new InstantiateHelper(gameObject);
                helper.SetTableTwoLocation(locatable);
            }

            yield return new WaitForSeconds(UpdateFrequencySeconds);
        }
    }
}
