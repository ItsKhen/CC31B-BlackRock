﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traderList = new List<Trader>();

        static TraderFactory()
        {
            Trader susan = new Trader("Susan");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader farmerTed = new Trader("Farmer Ted");
            farmerTed.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            Trader peteTheHerbalist = new Trader("Pete the Herbalist");
            peteTheHerbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            AddTraderToList(susan);
            AddTraderToList(farmerTed);
            AddTraderToList(peteTheHerbalist);
        }

        private static void AddTraderToList(Trader trader)
        {
            if (_traderList.Any(t => trader.Name == t.Name))
            {
                throw new ArgumentException($"There is already a trader named {trader.Name}!");
            }
            else
            {
                _traderList.Add(trader);
            }
        }

        public static Trader GetTraderByName(string name)
        {
            return _traderList.FirstOrDefault(t => t.Name == name);
        }
    }
}
