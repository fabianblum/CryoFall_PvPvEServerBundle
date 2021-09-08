﻿namespace AtomicTorch.CBND.CoreMod.UI.Controls.Game.Crafting
{
    using System.Collections.Generic;
    using System.Linq;
    using AtomicTorch.CBND.CoreMod.Characters.Player;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Core;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Game.Crafting.Data;
    using AtomicTorch.CBND.GameApi.Scripting;

    public partial class WindowCraftingStation : BaseUserControlWithWindow
    {
        private IProtoObjectCraftStation protoObjectCraftStation;

        public static WindowCraftingStation Instance { get; private set; }

        public WindowCraftingStationViewModel ViewModel { get; private set; }

        public static WindowCraftingStation Open(IProtoObjectCraftStation protoObjectCraftStation)
        {
            if (Instance is not null
                && Instance.protoObjectCraftStation == protoObjectCraftStation)
            {
                return Instance;
            }

            var instance = new WindowCraftingStation();
            Instance = instance;
            instance.protoObjectCraftStation = protoObjectCraftStation;
            Api.Client.UI.LayoutRootChildren.Add(instance);
            return Instance;
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            var recipes = this.GetAllRecipes();
            var recipesCountTotal = recipes.Count;
            RemoveLockedRecipes(recipes);

            this.DataContext = this.ViewModel = new WindowCraftingStationViewModel(
                                   recipes,
                                   recipesCountTotal);
        }

        protected override void OnUnloaded()
        {
            base.OnUnloaded();

            this.DataContext = null;
            this.ViewModel.Dispose();
            this.ViewModel = null;
            Instance = null;
        }

        private static void RemoveLockedRecipes(List<Recipe> list)
        {
            var character = Api.Client.Characters.CurrentPlayerCharacter;
            list.RemoveAll(r => !r.SharedIsTechUnlocked(character));
        }

        private List<Recipe> GetAllRecipes()
        {
            var character = Api.Client.Characters.CurrentPlayerCharacter;

            var privateState = PlayerCharacter.GetPrivateState(character);
            var origin = privateState.Origin;

            return Recipe.AllRecipes
                         .Where(r => r is Recipe.RecipeForStationCrafting stationRecipe1
                                     && stationRecipe1.StationTypes.Contains(this.protoObjectCraftStation) 
                                     && (
                                            (null == stationRecipe1.dependOrigins || stationRecipe1.dependOrigins.Count == 0)
                                            || stationRecipe1.dependOrigins.Contains(origin.ShortId)
                                        )
                                )
                         .ToList();
        }
    }
}