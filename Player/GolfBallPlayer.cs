using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallPlayer : MonoBehaviour
{
    public Camera camera;
    public Vector3 oldPos;
    //Сила и направление
    public float force;
    private Rigidbody playerRB;
    public LayerMask RayLayer;
    //Позиция курсора
    public Vector3 screenPos;
    public Vector3 worldPos;

    private LineRenderer line;
    public int lineLen;
    public float ballSpeed;
    public bool isPlayable = true;


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        oldPos = transform.position;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //Вращение камеры вокруг объекта
        screenPos = Input.mousePosition;
        UpdateCamera(camera, oldPos);
        oldPos = transform.position;
        PlayerControls(playerRB);
//        print(playerRB.velocity);
    }


    void LateUpdate()
    {
        RaycastHit lineHit;
        Ray lineRay = camera.ScreenPointToRay(screenPos);

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        if (Physics.Raycast(lineRay, out lineHit, 1000, RayLayer))
        {
            Vector3 hitPoint = lineHit.point;
            hitPoint.y = transform.position.y;

            Vector3 lineDir = (hitPoint - transform.position);
            lineDir.Normalize();
            lineDir *= lineLen;

            line.SetPosition(1, (transform.position + lineDir));
        }
    }
    /// <summary>
    /// Функция для повоторов и отслеживания камеры
    /// </summary>
    /// <param name="camera">Объект камеры</param>
    private void UpdateCamera(Camera camera, Vector3 oldPosition)
    {
        if (Input.GetMouseButton(0))
        {
            camera.transform.RotateAround(this.transform.position, camera.transform.up, -Input.GetAxis("Mouse X") * 3f);
            camera.transform.RotateAround(this.transform.position, camera.transform.right, -Input.GetAxis("Mouse Y") * 3f);
            camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x, camera.transform.eulerAngles.y, 0);
        }
        camera.transform.Translate(this.transform.position - oldPosition, Space.World);
    }
    /// <summary>
    /// Функция для удара шара. 
    /// </summary>
    private void ForceCounter()
    {
        if (Input.GetMouseButton(1) && force != 1000)
        {
            force += 1f;
        }
        //Толкаем шар и сбрасываем силу
        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = camera.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hData, 1000, RayLayer))
            {
                playerRB.AddForce(hData.point.x * force, 0, hData.point.z * force);
            }
            force = 0;
        }
    }
    private void PlayerControls(Rigidbody player)
    {
        if (Mathf.Abs(player.velocity.x) <= 0.5f && Mathf.Abs(player.velocity.z) <= 0.5f && Mathf.Abs(player.velocity.y) == 0)
        {
            isPlayable = true;
            ForceCounter();
            //Попробовать добавить остановку шара
            print("Stopped");
        }
        else
        {
            isPlayable = false;
        }
    }
}
 