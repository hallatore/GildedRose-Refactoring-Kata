using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
            }
        }

        public void UpdateItemQuality(Item item)
        {
            item.SellIn--;
            var qualityFactor = -1;
            
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    item.SellIn++;
                    qualityFactor = 0;
                    break;
                case "Aged Brie":
                    qualityFactor = 1;
                    break;
                case "Conjured Mana Cake":
                    qualityFactor = -2;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert" when item.SellIn < 0:
                    qualityFactor = -9000;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert" when item.SellIn <= 5:
                    qualityFactor = 3;
                    break;
                case "Backstage passes to a TAFKAL80ETC concert" when item.SellIn <= 10:
                    qualityFactor = 2;
                    break;
            }
            
            if (item.SellIn < 0 && qualityFactor < 0)
            {
                qualityFactor *= 2;
            }

            item.Quality = Math.Max(0, Math.Min(50, item.Quality + qualityFactor));
        }
    }
}
