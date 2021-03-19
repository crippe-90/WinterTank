using UnityEngine;

public class TurnPoint : MonoBehaviour {
    public VehicleDrivingLvl2 jeep;
    public VehicleDrivingLvl2 truck1;
    public VehicleDrivingLvl2 truck2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Hiting " + other.tag);
            jeep.ChangeFocus();
        }
        if (other.name.Equals("Truck1"))
        {
            Debug.Log("Hiting Truck1");
            truck1.ChangeFocus();
        }
        if (other.name.Equals("Truck2"))
        {
            Debug.Log("Hiting Truck2");
        }
    }
    
}
