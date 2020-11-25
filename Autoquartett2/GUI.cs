using System;
using System.Collections.Generic;
using System.Text;

namespace Autoquartett2
{
    public class GUI
    {
        public const char borderCharacter = '*';

        public GUI()
        {
        }

        public void WriteRectangle(int xVal, int yVal)
        {
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            xVal -= 1;

            WriteXAxis(xVal);

            SetWindowCursorCoords(posX, posY + yVal - 1);
            WriteXAxis(xVal);

            SetWindowCursorCoords(posX, posY);
            WriteYAxis(yVal);

            SetWindowCursorCoords(posX + xVal - 1, posY);
            WriteYAxis(yVal);
        }

        public void SetWindowCursorCoords(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        private void WriteYAxis(int yVal)
        {
            for (int i = 0; i < yVal; i++)
            {
                Console.Write(borderCharacter);
                Console.CursorTop = Console.CursorTop + 1;
                Console.CursorLeft = Console.CursorLeft - 1;
            }
        }

        private void WriteXAxis(int xVal)
        {
            for (int i = 0; i < xVal; i++)
            {
                Console.Write(borderCharacter);
            }
        }

        public void UserInput(string question)
        {
            SetWindowCursorCoords(2, Console.WindowHeight - 2);
            Console.Write(question + " ");
        }

        public void ShowCard(Car car)
        {
            //Kartengröße abhängig vom Fenster
            int width = Convert.ToInt32(Console.WindowWidth * 0.25);
            int height = Convert.ToInt32(Console.WindowHeight * 0.80);

            //Startpunkt
            int startPosX = Console.CursorLeft;
            int startPosY = Console.CursorTop;

            //Rand
            WriteRectangle(width, height);

            string[] cardInfo = car.GetCardInformation();
            //Verschobener Startpunkt für den Inhalt der Karte
            startPosY += 1;
            startPosX += 1;

            //Schleife aller Informationen einer Karte
            for (int i = 0; i < cardInfo.Length; i++)
            {
                SetWindowCursorCoords(startPosX + 1, startPosY + i);
                Console.Write(cardInfo[i]);
                //Doppelte Zeilensprünge, zur Übersichtlichkeit
                startPosY++;
            }
        }

        public void ReloadWindowWithBorder()
        {
            Console.Clear();
            WriteWindowBorder();
        }

        public void GetEndScreen()
        {

        }

        public void WriteWindowBorder()
        {
            WriteRectangle(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
