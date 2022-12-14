namespace RogueDungeon;

public class Door
{
    private Room _roomA;
    private Room _roomB;

    public Door(Room roomA, Room roomB)
    {
        _roomA = roomA;
        _roomB = roomB;
    }

    public Room RoomOnTheOtherSideOf (Room room)
    {
        Room theOtherRoom = null;
        if (room == _roomA)
        {
            theOtherRoom = _roomB;
        }

        if (room == _roomB)
        {
            theOtherRoom = _roomA;
        }

        return theOtherRoom;
    }

    public static Door CreateDoor(Room roomA, Room roomB, string toRoomB, string toRoomA)
    {
        Door door = new Door(roomA, roomB);
        roomA.SetExit(toRoomB, door);
        roomB.SetExit(toRoomA, door);

        return door;
    }
}