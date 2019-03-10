using UnityEngine;

public class BuildController : MonoBehaviour {
    
    public static BuildController instance;    

    [SerializeField] private GameObject[] placeableObjectPrefabs;
    private GameObject currentPlaceableObject;

    private float mouseWheelRotation;

    void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    private void Update() {
    /*    if (Input.GetKeyDown(KeyCode.B)) { //for testing purposes
            BuildTower(2);
        }*/
        if (currentPlaceableObject != null) {
            MoveCurrentObjectToMouse();
            ReleaseIfClicked();
            RotateFromMouseWheel();
        }        
    }

    private void MoveCurrentObjectToMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo)) {
            currentPlaceableObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(hitInfo.point.x, 40.8f, hitInfo.point.z),5000);
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void ReleaseIfClicked() {
        if (Input.GetMouseButtonDown(0)) {
            UIController.instance.UpdateCurrencyText(-currentPlaceableObject.GetComponent<TowerController>().currentTower.price);
            currentPlaceableObject = null;
        }
    }

    public void BuildTower(int index) {
        if (currentPlaceableObject != null) {
            Destroy(currentPlaceableObject);
        } else {
            currentPlaceableObject = Instantiate(placeableObjectPrefabs[index]);
            PlayerController.instance.DeTarget();
        }
    }

     private void RotateFromMouseWheel() {
        if(currentPlaceableObject != null) {
         mouseWheelRotation += Input.mouseScrollDelta.y;
         currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
     }
    }
}
