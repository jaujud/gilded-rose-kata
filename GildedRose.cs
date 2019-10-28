using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private const int maxItemQuality = 50;
        private const int minItemQuality = 0;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        // Quality should not exceed maximum allowed quality of 50
                        item.Quality = Math.Min(maxItemQuality, item.SellIn > 0 ? item.Quality + 1 : item.Quality + 2);

                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn <= 0)
                        {
                            item.Quality = minItemQuality;
                        }
                        else if (item.Quality < maxItemQuality)
                        {
                            if (item.SellIn <= 5)
                            {
                                item.Quality = Math.Min(maxItemQuality, item.Quality + 3);
                            }
                            else if (item.SellIn <= 10)
                            {
                                item.Quality = Math.Min(maxItemQuality, item.Quality + 2);
                            }
                            else
                            {
                                item.Quality++;
                            }
                        }

                        break;
                    default:
                        var degradationAmount = item.SellIn > 0 ? 1 : 2;

                        if (item.Name.ToLower().Contains("conjured"))
                        {
                            degradationAmount *= 2;
                        }

                        // Item quality should never go bellow minimum allowed quality of 0
                        item.Quality = Math.Max(minItemQuality, item.Quality - degradationAmount);

                        break;
                }
                
                item.SellIn--;
            }
        }
    }
}
