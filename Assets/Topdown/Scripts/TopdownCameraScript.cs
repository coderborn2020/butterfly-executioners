using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TopdownCameraScript : MonoBehaviour
{
    GameObject player;
    public Camera camera;
    public float camZoomRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // these units are basically just the number 1 but scaled to a 16 by 9 aspect ratio
        //float iX = 16f/9f;
        //float iY = 9f/16f;
        // same logic but auto scale to different resolutions
        float iX = (float)Screen.width/(float)Screen.height;
        float iY = (float)Screen.height/(float)Screen.width;
        
        // raycast to find the four corners of the players vision
        Vector2[] directions = {
            new Vector2( iX,  iY), // top right
            new Vector2( iX, -iY), // bottom right
            new Vector2(-iX, -iY), // bottom left
            new Vector2(-iX,  iY)  // top left
        };
        
        List<RaycastHit2D> raycasts = new List<RaycastHit2D>();

        foreach (var direction in directions)
        {
            raycasts.Add(Physics2D.Raycast(player.transform.position, direction, Mathf.Infinity, LayerMask.GetMask("Walls")));
            // TODO: see what happens if a raycast doesn't hit
        }

        foreach (var ray in raycasts)
        {
            Debug.DrawRay(player.transform.position, new Vector3(ray.point.x, ray.point.y)-player.transform.position, Color.red);
        }
        float avgDist = raycasts.Average(ray => ray.distance);

        // camera height is set in units of space
        camera.orthographicSize = Mathf.MoveTowards(camera.orthographicSize, avgDist*iY, camZoomRate * Time.deltaTime);;
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f) ;

    }
}
