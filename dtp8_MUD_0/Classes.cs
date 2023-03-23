using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtp8_MUD_0 //ARIS
{
    class Room /test
    {
        // Constants:
        public const int North = 0;
        public const int East = 1;
        public const int South = 2;
        public const int West = 3;
        public const int NoDoor = -1;

        // Object attributes:
        public int number; //Unikt rumsnummer
        public int key; //Nyckel som ev. ligger i rummet
        public string roomname = "";
        public string story = "";
        public string imageFile = "";
        public int[] adjacent = new int[4]; // adjacent[Room.North] etc.
        public Room(int num, string name)
        {
            number = num; roomname = name;
        }
        public void SetStory(string theStory)
        {
            story = theStory;
        }
        public void SetImage(string theImage)
        {
            imageFile = theImage;
        }
        public void SetDirections(int N, int E, int S, int W)
        {
            adjacent[North] = N; adjacent[East] = E; adjacent[South] = S; adjacent[West] = W;
        }
        public int GetNorth() => adjacent[North];
        public int GetEast() => adjacent[East];
        public int GetSouth() => adjacent[South];
        public int GetWest() => adjacent[West];
    }

    class Door
    {
        // Object attributes:
        public int[] rooms = new int[2]; //Array som innehåller unikt rumsnummer(från klass ROOM), anger mellan vilka rum dörren går
        public bool open; //true = dörren är öppen
    }



    class KeyDoor
    {
        public int[] rooms = new int[2]; ////Array som innehåller unikt rumsnummer(från klass ROOM), anger mellan vilka rum dörren går
    }

    class Player
    {
        public string name; //Spelarens namn
        public int room;   //rumsnummer där spelaren befinner sig
        public List<KeyDoor> keys; //lista av nycklar som spelaren har hittat
    }

}
