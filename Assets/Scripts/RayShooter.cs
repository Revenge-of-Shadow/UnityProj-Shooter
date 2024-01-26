using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayShooter : MonoBehaviour
{

    //  Delay in frames;
    [SerializeField]
    private int shootingDelay = 0;
    [SerializeField]
    private int maxShootingDelay = 32;

    [SerializeField]
    private GameObject fireballPrefab;

    private GameObject _fireball;

    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootingDelay > 0)   --shootingDelay;

        if(Input.GetMouseButton(0)){
            /*
            Vector3 point = new Vector3(_camera.pixelWidth/2.0F, _camera.pixelHeight/2.0F, -_camera.pixelWidth);
            
            Ray ray = _camera.ScreenPointToRay(point);  //  Geometrical ray.
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                //Debug.Log(String.Format("Hit {0}", hit.point));

                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1.0F);

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null){
                    //Debug.Log(String.Format("Target hit at the point: {0}", hit.point));
                    target.ReactToHit();
                }
                else{
                }
            }
            */
            if(shootingDelay == 0){
                _fireball = Instantiate(fireballPrefab);
                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 5F);
                _fireball.transform.rotation = transform.rotation;
                _fireball.transform.parent = this.transform;
                shootingDelay = maxShootingDelay;
            }
        }
    }

    private IEnumerator CylinderIndicator(Vector3 pos){
        
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = pos;
        cylinder.transform.rotation = this.transform.rotation;
        yield return new WaitForSeconds(0.05F);
        Destroy(cylinder);
    }

    void OnGUI(){
        GUI.contentColor = Color.black;
        GUI.skin.label.fontSize = 20;
        float size = 48;
        float posX = _camera.pixelWidth/2.0F - size/8.0F;
        float posY = _camera.pixelHeight/2.0F - size/3.0F;
        //float posZ = -_camera.pixelWidth;

        GUI.Label(new Rect(posX, posY, size, size), "+");

        string datastr = "Health: "
            +transform.parent.gameObject.GetComponent<PlayerCharacter>().getHP
            +"/"
            +PlayerCharacter.maxHP
            +"   Reload time left: " 
            + shootingDelay
            +"  Score: "
            +transform.parent.gameObject.GetComponent<PlayerCharacter>().getScore;
        GUI.Label(new Rect(0, _camera.pixelHeight-size/2.0F, size*16, size), datastr);

    }
}
