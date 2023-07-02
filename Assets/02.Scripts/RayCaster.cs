using UnityEngine;
using UnityEngine.Events;

public class RayCaster : MonoBehaviour {
  public GameObject from;
  public LineRenderer line;
  public float maxRayDistance = 10.0f;
  public UnityEvent<GameObject> OnHit;

  private bool isUseRayCast = true;
  private RaycastHit hit;

  public void SetRayCast(bool _isUseRayCast) {
    isUseRayCast = _isUseRayCast;
    line.enabled = _isUseRayCast;
  }
  void Update() {
    if (!isUseRayCast) return;

    line.SetPosition(0, from.transform.position);
    line.SetPosition(1, from.transform.forward * maxRayDistance);

    if (Physics.Raycast(from.transform.position, from.transform.forward, out hit, maxRayDistance)) {
      OnHit.Invoke(hit.collider.gameObject);
    }
  }
}
