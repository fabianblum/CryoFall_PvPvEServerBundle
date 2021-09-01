﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Seeds;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeSeedsMushroomPink : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectFarmingWorkbench>();

            duration = CraftingDuration.Short;

            inputItems.Add<ItemMushroomPink>(count: 2);
            inputItems.Add<ItemSand>(count: 5);
            inputItems.Add<ItemMulch>(count: 1);

            outputItems.Add<ItemSeedsMushroomPink>(count: 1);
        }
    }
}