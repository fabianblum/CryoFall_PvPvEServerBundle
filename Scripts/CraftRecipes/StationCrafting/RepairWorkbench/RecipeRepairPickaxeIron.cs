﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.Items.Tools.Pickaxes;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairPickaxeIron : Recipe.RecipeForStationCrafting
    {
        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Medium;

            inputItems.Add<ItemPlanks>(count: 10);
            inputItems.Add<ItemIngotIron>(count: 3);
			inputItems.Add<ItemDuctTape>(count: 1);
            inputItems.Add<ItemPickaxeIron>(count: 1);

            outputItems.Add<ItemPickaxeIron>();
        }
    }
}