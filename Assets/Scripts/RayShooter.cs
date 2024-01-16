using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayShooter : MonoBehaviour
{
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
        if(Input.GetMouseButton(0)){
            
            Vector3 point = new Vector3(_camera.pixelWidth/2.0F, _camera.pixelHeight/2.0F, -_camera.pixelWidth);
            
            Ray ray = _camera.ScreenPointToRay(point);  //  Geometrical ray.
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                //Debug.Log(String.Format("Hit {0}", hit.point));

                StartCoroutine(SphereIndicator(hit.point));

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null){
                    //Debug.Log(String.Format("Target hit at the point: {0}", hit.point));
                    target.ReactToHit();
                }
                else{
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos){
        
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Quad);
        sphere.transform.position = pos;
        sphere.transform.rotation = this.transform.rotation;
        yield return new WaitForSeconds(0.05F);
        Destroy(sphere);
    }

    void OnGUI(){
        float size = 24;
        float posX = _camera.pixelWidth/2.0F - size/8.0F;
        float posY = _camera.pixelHeight/2.0F - size/2.0F;
        //float posZ = -_camera.pixelWidth;

        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}