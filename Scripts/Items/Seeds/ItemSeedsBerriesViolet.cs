﻿namespace AtomicTorch.CBND.CoreMod.Items.Seeds
{
    using System.Collections.Generic;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Structures.Farms;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation;
    using AtomicTorch.CBND.CoreMod.StaticObjects.Vegetation.Plants;

    public class ItemSeedsBerriesViolet : ProtoItemSeed
    {
        public override string Description => "Purple berry seeds prepared for planting.";

        public override string Name => "Purple berry seeds.";

        protected override void PrepareProtoItemSeed(
            out IProtoObjectVegetation objectPlantProto,
            List<IProtoObjectFarm> allowedToPlaceAt)
        {
            objectPlantProto = GetPlant<ObjectPlantPurple>();

            allowedToPlaceAt.Add(GetPlot<ObjectFarmPlot>());
        }
    }
}