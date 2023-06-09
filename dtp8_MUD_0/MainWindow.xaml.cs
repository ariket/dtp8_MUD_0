﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dtp8_MUD_0
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room[] labyrinth = new Room[100];
        int currentRoom;
        public MainWindow()
        {
            InitializeComponent();

            // Init Rooms here: TODO: ladda rummen från en fil
            Room R;
            R = new Room(0, "startrummet");
            R.SetStory("Du står i ett rum med rött tegel. Väggarna fladdrar i facklornas sken. Du ser en hög med tyg nere till vänster. ");
            R.SetImage("ingang-stangd.png");
            R.SetDirections(N: 1, E: Room.NoDoor, S: Room.NoDoor, W: Room.NoDoor);
            labyrinth[0] = R;

            R = new Room(1, "Korsvägen");
            R.SetStory("Du står i korsväg. Det går gångar i alla riktningar. ");
            R.SetImage("vagskal.png");
            R.SetDirections(N: 2, E: 3, S: 0, W: 4);
            labyrinth[1] = R;
            
            R = new Room(1, "Korsvägen2");
            R.SetStory("Du står i korsväg. Det går gångar i alla riktningar. ");
            R.SetImage("a.png");
            R.SetDirections(N: Room.NoDoor, E: Room.NoDoor, S: 1, W: Room.NoDoor); 
            labyrinth[2] = R;

            currentRoom = 0;
            DisplayCurrentRoom();
        }

        private void ApplicationKeyPress(object sender, KeyEventArgs e)
        {
            string output = "Key pressed: ";
            output += e.Key.ToString();
            // output += ", ";
            // output += AppDomain.CurrentDomain.BaseDirectory;
            KeyPressDisplay.Text = output;

            if(e.Key == Key.Escape || e.Key == Key.Q || e.Key == Key.X)
            {
                System.Windows.Application.Current.Shutdown();
            }
            else if(e.Key == Key.Up && labyrinth[currentRoom].GetNorth() != Room.NoDoor)
            {
                currentRoom = labyrinth[currentRoom].GetNorth();
                DisplayCurrentRoom();
            }
            else if (e.Key == Key.Down && labyrinth[currentRoom].GetSouth() != Room.NoDoor)
            {
                currentRoom = labyrinth[currentRoom].GetSouth();
                DisplayCurrentRoom();
            }
            else if (e.Key == Key.Left && labyrinth[currentRoom].GetWest() != Room.NoDoor)
            {
                currentRoom = labyrinth[currentRoom].GetWest();
                DisplayCurrentRoom();
            }
            else if (e.Key == Key.Right && labyrinth[currentRoom].GetEast() != Room.NoDoor)
            {
                currentRoom = labyrinth[currentRoom].GetEast();
                DisplayCurrentRoom();
            }
            else if (e.Key == Key.S )
            {
             
                DisplayCurrentRoom();
            }
            else if (e.Key == Key.N )
            {
               
                DisplayCurrentRoom();
            }
        }
        private void DisplayCurrentRoom()
        {
            //string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string baseDir = "C:\\Temp\\MJU_bilder\\";
            Room R = labyrinth[currentRoom];
            string bitmapFileName = baseDir + R.imageFile;
          
           if (File.Exists(bitmapFileName))
           {
               Uri uri = new Uri(bitmapFileName, UriKind.RelativeOrAbsolute);
               RoomImage.Source = BitmapFrame.Create(uri);
            }
            string text = $"Du befinner dig i {R.roomname}. ";
            text += R.story+" ";
            if (R.GetNorth() != Room.NoDoor) text += "Det finns en gång norrut. ";
            if (R.GetEast() != Room.NoDoor) text += "Det finns en gång österut. ";
            if (R.GetSouth() != Room.NoDoor) text += "Det finns en gång söderut. ";
            if (R.GetWest() != Room.NoDoor) text += "Det finns en gång västerut. ";
            RoomText.Text = text;
            

            /* Andra texter som man kan sätta:
             * KeyAlt1.Text = "upp      gå norrut"; 
             * KeyAlt2.Text = "vänster  gå västerut"; 
             * ... etc. ...
             */
        }
    }
}
