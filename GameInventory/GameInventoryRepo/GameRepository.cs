using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameInventoryDB;

namespace GameInventoryRepo
{
    public class GameModel
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameType { get; set; }
        public string GamePlatform { get; set; }
        public int GameQuantity { get; set; }
        public decimal GameCostPerUnit { get; set; }
        public decimal GameTotalCost { get; set; }
        public decimal GameRetailPerUnit { get; set; }
        public decimal GameTotalRetail { get; set; }
        public System.DateTime CreateDate { get; set; }
    }


    public class GameRepository
    {
        public GameModel Add(GameModel gameModel)
        {
            var gameDb = ToDbModel(gameModel);

            DatabaseManager.Instance.Games.Add(gameDb);
            DatabaseManager.Instance.SaveChanges();

            gameModel = new GameModel
            {
                GameId = gameDb.GameId,
                GameTitle = gameDb.GameTitle,
                GameType = gameDb.GameType,
                GamePlatform = gameDb.GamePlatform,
                GameQuantity = gameDb.GameQuantity,
                GameCostPerUnit = gameDb.GameCostPerUnit,
                GameTotalCost = gameDb.GameTotalCost,
                GameRetailPerUnit = gameDb.GameRetailPerUnit,
                GameTotalRetail = gameDb.GameTotalRetail,
                CreateDate = gameDb.CreateDate
            };
            return gameModel;
        }


        public List<GameModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Games
              .Select(t => new GameModel
              {
                  GameId = t.GameId,
                  GameTitle = t.GameTitle,
                  GameType = t.GameType,
                  GamePlatform = t.GamePlatform,
                  GameQuantity = t.GameQuantity,
                  GameCostPerUnit = t.GameCostPerUnit,
                  GameTotalCost = t.GameTotalCost,
                  GameRetailPerUnit = t.GameRetailPerUnit,
                  GameTotalRetail = t.GameTotalRetail,
                  CreateDate = t.CreateDate
              }).ToList();

            return items;
        }

        public bool Update(GameModel gameModel)
        {
            var original = DatabaseManager.Instance.Games.Find(gameModel.GameId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(gameModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int gameId)
        {
            var items = DatabaseManager.Instance.Games
                                .Where(t => t.GameId == gameId);

            if (!items.Any())
            {
                return false;
            }

            DatabaseManager.Instance.Games.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Game ToDbModel(GameModel gameModel)
        {
            var gameDb = new Game
            {
                GameId = gameModel.GameId,
                GameTitle = gameModel.GameTitle,
                GameType = gameModel.GameType,
                GamePlatform = gameModel.GamePlatform,
                GameQuantity = gameModel.GameQuantity,
                GameCostPerUnit = gameModel.GameCostPerUnit,
                GameTotalCost = gameModel.GameTotalCost,
                GameRetailPerUnit = gameModel.GameRetailPerUnit,
                GameTotalRetail = gameModel.GameTotalRetail,
                CreateDate = gameModel.CreateDate
            };
            return gameDb;
        }
    }
}
