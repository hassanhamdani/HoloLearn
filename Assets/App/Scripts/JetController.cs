using MRTKExtensions.QRCodes;
using UnityEngine;

public class JetController : MonoBehaviour
{
    [SerializeField]
    private QRTrackerController trackerController;

    [SerializeField]
    private Transform spawnZone;

    private void Start()
    {
        trackerController.PositionSet += PoseFound;
    }

    private void PoseFound(object sender, Pose pose)
    {
        var childObj = transform.GetChild(0);
        childObj.SetPositionAndRotation(spawnZone.position, spawnZone.rotation);
        childObj.gameObject.SetActive(true);
    }

    public void Reset()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}