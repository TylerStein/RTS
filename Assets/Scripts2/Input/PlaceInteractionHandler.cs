using UnityEngine;
using UnityEngine.AI;
using RTS2.Entities;
using RTS2.Player;
namespace RTS2.Input
{
    class PlaceInteractionHandler : MonoBehaviour
    {
        [SerializeField] public float maxSnapToNavMeshDistance = 1.0f;
        [SerializeField] public int navMeshAreaMask = -1;

        [SerializeField] private PlayerState playerState;
        [SerializeField] private InteractionEventConsumer interactionConsumer;

        private bool active = false;
        private bool validPlacement = false;

        private Vector3 lastValidPosition = Vector3.zero;

        public GameObject spawnPrefab;
        public GameObject spawnGhostObject;
  
        public void SetWorldCursor(Vector3 cursorPosition) {
            if (active && spawnGhostObject) {
                Vector3 ghostPosition = cursorPosition;
                validPlacement = FindNearestValidPosition(cursorPosition, out ghostPosition);
                if (validPlacement) {
                    spawnGhostObject.transform.position = ghostPosition;
                }

            }
        }

        public void OnEntityInteraction(InteractionEvent<Entity> interactionEvent) {
            //
        }

        public void OnPositionInteraction(InteractionEvent<Vector3> interactionEvent) {
            if (validPlacement) {
                GameObject newObject = Instantiate(spawnPrefab, spawnGhostObject.transform.position, spawnGhostObject.transform.rotation);
                Entity entity = newObject.GetComponent<Entity>();
                entity.SetOwningPlayerIndex(playerState.GetPlayerIndex());
                Destroy(spawnGhostObject);
                interactionConsumer.SetSelectMode();
            }
        }

        public void SetActive(GameObject thingPrefab, GameObject ghostPrefab) {
            if (!spawnGhostObject) spawnGhostObject = Instantiate(ghostPrefab, Vector3.zero, ghostPrefab.transform.rotation);
            spawnPrefab = thingPrefab;
            active = true;
        }

        public void Cancel() {
            active = false;
            spawnPrefab = null;
            spawnGhostObject = null;
        }

        public bool FindNearestValidPosition(Vector3 testPosition, out Vector3 adjustedPosition) {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(testPosition, out hit, maxSnapToNavMeshDistance, navMeshAreaMask)) {
                adjustedPosition = hit.position;
                lastValidPosition = adjustedPosition;
                return true;
            }

            adjustedPosition = lastValidPosition;
            return false;
        }
    }
}
