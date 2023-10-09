using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    PointerMove Pm;
    public Vector3 TargetPosition;
    [SerializeField] float ShootSpeed;
    [SerializeField] ScoreText st;
    [SerializeField] GameObject ClickEffect;
    [SerializeField] SEManager se;
    // Start is called before the first frame update
    void Start()
    {
        Pm = GetComponent<PointerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 FirstPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            GameObject B = Instantiate(Bullet, FirstPoint, Quaternion.Euler(90f, 0.0f, 0.0f));
            Vector3 origin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            Ray ray = new Ray(FirstPoint, origin - FirstPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Vector3.Distance(FirstPoint, origin)))
            {
                TargetPosition = hit.point;
                FirstPoint.z = 0.0f;
                Instantiate(ClickEffect, FirstPoint, Quaternion.identity);
                if (hit.collider.gameObject.CompareTag("Player") && hit.collider.GetComponent<StudentStateManager>().currentState == StudentStateManager.StudentState.sleep)
                {
                    B.GetComponent<Bullet>().st = GetComponent<ScoreText>();
                    B.GetComponent<Bullet>().isPlayer_Sleeping = true;
                    B.GetComponent<Bullet>().Student = hit.collider.gameObject;
                }
                else if(hit.collider.gameObject.CompareTag("Player") && hit.collider.GetComponent<StudentStateManager>().currentState != StudentStateManager.StudentState.sleep)
                {
                    B.GetComponent<Bullet>().st = GetComponent<ScoreText>();
                    B.GetComponent<Bullet>().isPlayer = true;
                }
                else if(hit.collider.gameObject.CompareTag("Floor"))
                {
                    B.GetComponent<Bullet>().isFloor = true;
                }
            }
            else
            {
                TargetPosition = origin;
            }
            B.GetComponent<Bullet>().TargetPosition = TargetPosition;
            B.GetComponent<Bullet>().RushSpeed = ShootSpeed;
            B.GetComponent<Bullet>().se = se;
        }
    }
}
