using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 TargetPosition;
    public float RushSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 directionToTarget = TargetPosition - transform.position;
        // Quaternion.LookRotationを使用してCylinderを新しい方向に回転します。
        transform.rotation = Quaternion.LookRotation(directionToTarget);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, TargetPosition, RushSpeed * Time.deltaTime);

        if(Mathf.Approximately(this.transform.position.x, TargetPosition.x) && Mathf.Approximately(this.transform.position.y, TargetPosition.y) && Mathf.Approximately(this.transform.position.z, TargetPosition.z))
        {
            Destroy(this.gameObject);
        }
    }

}
