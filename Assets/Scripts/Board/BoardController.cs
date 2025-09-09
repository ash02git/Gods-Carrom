using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private GameObject blocker;
    [SerializeField] private PolygonCollider2D spawnArea;

    public void TurnOnBlocker() => blocker.SetActive(true);

    public void TurnOffBlocker() => blocker.SetActive(false);
}
