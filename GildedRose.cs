using System;
using System.Collections.Generic;

namespace csharp
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
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < maxItemQuality)
                    {
                        item.Quality = item.SellIn > 0 ? item.Quality + 1 : item.Quality + 2;
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
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
                }
                else
                {
                    var degradationAmount = item.SellIn > 0 ? 1 : 2;

                    if (item.Name.ToLower().Contains("conjured"))
                    {
                        degradationAmount *= 2;
                    }

                    item.Quality = Math.Max(minItemQuality, item.Quality - degradationAmount);
                }
                
                item.SellIn--;
            }
        }
    }
}
