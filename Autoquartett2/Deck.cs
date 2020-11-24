using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquartett2
{
    class Deck
    {
        /**
         * Liste, die 32 Objekte des Typs Car enthält 
         */
        private LinkedList<Car> cars = new LinkedList<Car>();

        public Deck()
        {
            InitateCards();
        }

        /*
         *Liest einzelnen Karten aus einer JSON Datei aus und speichert sie als Objekte des Typs Car 
         */
        private bool InitateCards()
        {
            return true;
        }

        /*
         *Mischt die Karten des Decks 
        */
        public void ShuffleCars()
        {

        }
        /*
         * Teilt alle Karten gleichmäßig auf die teilnehmenden Spieler auf. Lässt sie Anzahl an Karten nicht glatt durch die Spieleranzahl teilen,
         * werden wird der nächst kleinere Teiler verwendet und die übrigen Karten ignoriert.
         */
        public bool DistributeCars(List<Player> playerList)
        {
            int toMuch = cars.Count % playerList.Count();

            for (int i = 0; i < (playerList.Count() - toMuch); i++)
            {
                int playerNumber = i % playerList.Count();
                playerList.ElementAt(playerNumber).AddCar(cars.ElementAt(i));
            }

            return true;
        }
    }
}