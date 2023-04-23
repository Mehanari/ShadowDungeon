using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RoomsConfig", menuName ="Configs/RoomsConfig")]
public class RoomsConfig : ScriptableObject
{
    public List<Room> Rooms = new List<Room>();
    public Room StartRoom;
    public Room EndRoom;
}
