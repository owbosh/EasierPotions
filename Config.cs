using Microsoft.Xna.Framework;
using System.ComponentModel;
using System.Collections.Generic;
using Terraria.ModLoader.Config;

namespace EasierPotions
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static Config Instance;

        [ReloadRequired]
        [Label("Remove Bottles")]
        [Tooltip("Removes any bottles or bottles of water from potion recipes.")]
        [DefaultValue(false)]
        public bool NoBottles;

        [ReloadRequired]
        [Label("Potion Multiplier")]
        [Tooltip("Multiplies the amount of potions created while crafting by the set value.")]
        [Range(1, 10)]
        [Increment(1)]
        [DefaultValue(2)]
        public int PotMultiplier;

        [ReloadRequired]
        [Label("Potions Within Potion Recipes Increase")]
        [Tooltip("Multiplies the amount of potions required within potion recipes by the Potion Multiplier value.\n" +
            "For example, if the Potion Multiplier value was 2, the amount of Lesser Healing potions required\n" +
            "to create a set of Healing Potions would be 8 instead of 4.")]
        [DefaultValue(true)]
        public bool PotIncrease;
    }
}
