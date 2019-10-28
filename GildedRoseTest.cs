using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ShouldDecreseQualityForRegularItems()
        {
            var items = new List<Item> 
            { 
                new Item { Name = "Arrow", SellIn = 0, Quality = 0 },
                new Item { Name = "Apple", SellIn = 1, Quality = 10 },
                new Item { Name = "Sword", SellIn = 0, Quality = 10 },
                new Item { Name = "Backpack", SellIn = -1, Quality = 10 }
            };
            var expectedItems = new List<Item>
            {
                new Item { Name = "Arrow", SellIn = -1, Quality = 0 },
                new Item { Name = "Apple", SellIn = 0, Quality = 9 },
                new Item { Name = "Sword", SellIn = -1, Quality = 8 },
                new Item { Name = "Backpack", SellIn = -2, Quality = 8 }
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            CompareItems(items, expectedItems);
        }

        [Test]
        public void ShouldDecreseQualityForConjuredItems()
        {
            var items = new List<Item>
            {
                new Item { Name = "Conjured Arrow", SellIn = 0, Quality = 0 },
                new Item { Name = "Conjured Apple", SellIn = 1, Quality = 10 },
                new Item { Name = "+5 Conjured Sword", SellIn = 0, Quality = 10 },
                new Item { Name = "Conjured Backpack", SellIn = -1, Quality = 10 }
            };
            var expectedItems = new List<Item>
            {
                new Item { Name = "Conjured Arrow", SellIn = -1, Quality = 0 },
                new Item { Name = "Conjured Apple", SellIn = 0, Quality = 8 },
                new Item { Name = "+5 Conjured Sword", SellIn = -1, Quality = 6 },
                new Item { Name = "Conjured Backpack", SellIn = -2, Quality = 6 }
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            CompareItems(items, expectedItems);
        }

        [Test]
        public void ShouldIncreaseQualityForAgedBrie()
        {
            var itemName = "Aged Brie";
            var items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 10 },
                new Item { Name = itemName, SellIn = 0, Quality = 10 },
                new Item { Name = itemName, SellIn = -1, Quality = 10 },
                new Item { Name = itemName, SellIn = -1, Quality = 49 }
            };
            var expectedItems = new List<Item>
            {
                new Item { Name = itemName, SellIn = 0, Quality = 11 },
                new Item { Name = itemName, SellIn = -1, Quality = 12 },
                new Item { Name = itemName, SellIn = -2, Quality = 12 },
                new Item { Name = itemName, SellIn = -2, Quality = 50 }
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            CompareItems(items, expectedItems);
        }

        [Test]
        public void ShouldIncreaseQualityForBackstagePasses()
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";
            var items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 11, Quality = 5 },
                new Item { Name = itemName, SellIn = 10, Quality = 5 },
                new Item { Name = itemName, SellIn = 9, Quality = 49 },
                new Item { Name = itemName, SellIn = 5, Quality = 5 },
                new Item { Name = itemName, SellIn = 4, Quality = 49 },
                new Item { Name = itemName, SellIn = 0, Quality = 5 }
            };
            var expectedItems = new List<Item>
            {
                new Item { Name = itemName, SellIn = 10, Quality = 6 },
                new Item { Name = itemName, SellIn = 9, Quality = 7 },
                new Item { Name = itemName, SellIn = 8, Quality = 50 },
                new Item { Name = itemName, SellIn = 4, Quality = 8 },
                new Item { Name = itemName, SellIn = 3, Quality = 50 },
                new Item { Name = itemName, SellIn = -1, Quality = 0 }
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            CompareItems(items, expectedItems);
        }

        [Test]
        public void ShouldNotUpdateQualityForSulfuras()
        {
            var itemName = "Sulfuras, Hand of Ragnaros";
            var items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 80 },
                new Item { Name = itemName, SellIn = 0, Quality = 80 },
                new Item { Name = itemName, SellIn = -1, Quality = 80 }
            };
            var expectedItems = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 80 },
                new Item { Name = itemName, SellIn = 0, Quality = 80 },
                new Item { Name = itemName, SellIn = -1, Quality = 80 }
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            CompareItems(items, expectedItems);
        }

        private void CompareItems(IList<Item> items, IList<Item> expectedItems)
        {
            Item item;
            Item expectedItem;
            var messageTemplate = "Item#: {0}, Error: {1} does not match the expected value";

            for (var i = 0; i < items.Count; i++)
            {
                item = items[i];
                expectedItem = expectedItems[i];

                Assert.AreEqual(expectedItem.Name, item.Name, string.Format(messageTemplate, i, "Name"));
                Assert.AreEqual(expectedItem.SellIn, item.SellIn, string.Format(messageTemplate, i, "SellIn"));
                Assert.AreEqual(expectedItem.Quality, item.Quality, string.Format(messageTemplate, i, "Quality"));
            }
        }
    }
}
