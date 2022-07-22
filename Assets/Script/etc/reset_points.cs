using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_points : MonoBehaviour
{
    public GameObject surver;
    public int points_id;
    private receiver script;
    // Start is called before the first frame update
    void Start()
    {
        script = surver.GetComponent<receiver>();
        points_id = script.points_cnt;
        script.points_cnt++;
    }

    // Update is called once per frame
    void Update()
    {
        if(script.point_flag == 0 && points_id > 0)
        {
            Destroy(this.gameObject);
        }
    }
}
