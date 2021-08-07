﻿namespace AtomicTorch.CBND.CoreMod.CraftRecipes
{
    using System;
    using AtomicTorch.CBND.CoreMod.Items.Equipment;
	using AtomicTorch.CBND.CoreMod.Items.Food;
    using AtomicTorch.CBND.CoreMod.Items.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.CraftingStations;
    using AtomicTorch.CBND.CoreMod.Systems;
    using AtomicTorch.CBND.CoreMod.Systems.Crafting;

    public class RecipeRepairWoodHelmet : Recipe.RecipeForStationCrafting
    {
        public override bool IsAutoUnlocked => false;

        protected override void SetupRecipe(
            StationsList stations,
            out TimeSpan duration,
            InputItems inputItems,
            OutputItems outputItems)
        {
            stations.Add<ObjectRepairWorkbench>();

            duration = CraftingDuration.Medium;
			
			//Initial Item Cost.
			inputItems.Add<ItemWoodHelmet>();

            inputItems.Add<ItemPlanks>(count: 37);
			inputItems.Add<ItemThread>(count: 5);
			inputItems.Add<ItemFibers>(count: 5);			
			inputItems.Add<ItemGlue>(count: 1);
			
            outputItems.Add<ItemWoodHelmet>();
			outputItems.Add<ItemBottleEmpty>();
        }
    }
}