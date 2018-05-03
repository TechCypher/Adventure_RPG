using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToArea : MonoBehaviour
{
    #region Varibles
    public GameObject areaGO;
    public static string area;
    GameObject player;
    Camera[] cam;
    Camera camm;
    public PlayerControl PC;
    #endregion
    #region Start
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PC = player.GetComponent<PlayerControl>();
        cam = player.GetComponentsInChildren<Camera>();
        camm = cam[0];
    }

    #endregion
    #region Trigger Events
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // PC.playerT.position = areaGO.transform.position;
            PC.playerT.position = areaGO.transform.position;
            Area(areaGO.ToString()); // Makes the area var static
        }

        if (areaGO.name == "House1")
        {
            camm.orthographicSize = 8;
            camm.clearFlags = CameraClearFlags.Skybox;
        }
        else { camm.orthographicSize = 3; camm.clearFlags = CameraClearFlags.Nothing; }
    }

    #endregion
    #region Other
    public static void Area(string _area) { area = _area; }
    #endregion
}
