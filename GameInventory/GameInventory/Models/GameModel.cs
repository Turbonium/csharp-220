using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory.Models
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

        public GameInventoryRepo.GameModel ToRepositoryModel()
        {
            var repositoryModel = new GameInventoryRepo.GameModel
            {
                GameId = GameId,
                GameTitle = GameTitle,
                GameType = GameType,
                GamePlatform = GamePlatform,
                GameQuantity = GameQuantity,
                GameCostPerUnit = GameCostPerUnit,
                GameTotalCost = GameTotalCost,
                GameRetailPerUnit = GameRetailPerUnit,
                GameTotalRetail = GameTotalRetail,
                CreateDate = CreateDate
            };
            return repositoryModel;
        }

        public static GameModel ToModel(GameInventoryRepo.GameModel repositoryModel)
        {
            var gameModel = new GameModel
            {
                GameId = repositoryModel.GameId,
                GameTitle = repositoryModel.GameTitle,
                GameType = repositoryModel.GameType,
                GamePlatform = repositoryModel.GamePlatform,
                GameQuantity = repositoryModel.GameQuantity,
                GameCostPerUnit = repositoryModel.GameCostPerUnit,
                GameTotalCost = repositoryModel.GameTotalCost,
                GameRetailPerUnit = repositoryModel.GameRetailPerUnit,
                GameTotalRetail = repositoryModel.GameTotalRetail,
                CreateDate = repositoryModel.CreateDate
            };
            return gameModel;
        }

        public GameModel Clone()
        {
            return MemberwiseClone() as GameModel;
        }

    }
}
