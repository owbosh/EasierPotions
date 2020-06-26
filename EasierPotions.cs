using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EasierPotions
{
    public class EasierPotions : Mod
    {
        public EasierPotions()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void AddRecipes()
        {
            List<Recipe> rec = Main.recipe.ToList();

            rec.Where(x => (x.createItem.UseSound == SoundID.Item3 || x.createItem.Name.Contains("Potion")) && x.createItem.consumable && !x.createItem.Name.Contains("Bottle")).ToList().ForEach(s =>
            {
                s.createItem.stack *= ModContent.GetInstance<Config>().PotMultiplier;
                if (ModContent.GetInstance<Config>().NoBottles)
                {
                    List<Item> potRec = s.requiredItem.ToList();
                    potRec.Where(i => (i.Name.Contains("Bottle"))).ToList().ForEach(j =>
                    {
                        potRec.Remove(j);
                        potRec.Add(new Item());
                    });
                    s.requiredItem = potRec.ToArray();
                }
                if (ModContent.GetInstance<Config>().PotIncrease)
                {
                    List<Item> potRec = s.requiredItem.ToList();
                    potRec.Where(i => (i.UseSound == SoundID.Item3 || i.Name.Contains("Potion")) && i.consumable && !i.Name.Contains("Bottle")).ToList().ForEach(j =>
                    {
                        j.stack *= ModContent.GetInstance<Config>().PotMultiplier;
                    });
                }
            });
        }
    }
}