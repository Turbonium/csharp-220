using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameInventoryDB;

namespace GameInventoryRepo
{
    class DatabaseManager
    {
        private static readonly GameInventoryEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new GameInventoryEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static GameInventoryEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
