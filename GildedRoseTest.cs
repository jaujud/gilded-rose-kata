using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ShouldDecreseQualityForRegularItems()
        {
            IList<Item> Items = new List<Item> 
            { 
                new Item { Name = "Arrow", SellIn = 0, Quality = 0 },
                new Item { Name = "Apple", SellIn = 1, Quality = 10 },
                new Item { Name = "Sword", SellIn = 0, Quality = 10 },
                new Item { Name = "Backpack", SellIn = -1, Quality = 10 }
            };

            IList<Item> ItemsExpected = new List<Item>
            {
                new Item { Name = "Arrow", SellIn = -1, Quality = 0 },
                new Item { Name = "Apple", SellIn = 0, Quality = 9 },
                new Item { Name = "Sword", SellIn = -1, Quality = 8 },
                new Item { Name = "Backpack", SellIn = -2, Quality = 8 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item;
            Item itemExpected;

            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                itemExpected = ItemsExpected[i];

                Assert.AreEqual(itemExpected.Name, item.Name, $"Item: {i}, Error: Expected Name '{itemExpected.Name}' but found '{item.Name}'");
                Assert.AreEqual(itemExpected.SellIn, item.SellIn, $"Item: {i}, Error: Expected SellIn '{itemExpected.SellIn}' but found '{item.SellIn}'");
                Assert.AreEqual(itemExpected.Quality, item.Quality, $"Item: {i}, Error: Expected Quality '{itemExpected.Quality}' but found '{item.Quality}'");
            }
        }

        [Test]
        public void ShouldDecreseQualityForConjuredItems()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Conjured Arrow", SellIn = 0, Quality = 0 },
                new Item { Name = "Conjured Apple", SellIn = 1, Quality = 10 },
                new Item { Name = "+5 Conjured Sword", SellIn = 0, Quality = 10 },
                new Item { Name = "Conjured Backpack", SellIn = -1, Quality = 10 }
            };

            IList<Item> ItemsExpected = new List<Item>
            {
                new Item { Name = "Conjured Arrow", SellIn = -1, Quality = 0 },
                new Item { Name = "Conjured Apple", SellIn = 0, Quality = 8 },
                new Item { Name = "+5 Conjured Sword", SellIn = -1, Quality = 6 },
                new Item { Name = "Conjured Backpack", SellIn = -2, Quality = 6 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item;
            Item itemExpected;

            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                itemExpected = ItemsExpected[i];

                Assert.AreEqual(itemExpected.Name, item.Name, $"Item: {i}, Error: Expected Name '{itemExpected.Name}' but found '{item.Name}'");
                Assert.AreEqual(itemExpected.SellIn, item.SellIn, $"Item: {i}, Error: Expected SellIn '{itemExpected.SellIn}' but found '{item.SellIn}'");
                Assert.AreEqual(itemExpected.Quality, item.Quality, $"Item: {i}, Error: Expected Quality '{itemExpected.Quality}' but found '{item.Quality}'");
            }
        }

        [Test]
        public void ShouldIncreaseQualityForAgedBrie()
        {
            var itemName = "Aged Brie";
            IList<Item> Items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 10 },
                new Item { Name = itemName, SellIn = 0, Quality = 10 },
                new Item { Name = itemName, SellIn = -1, Quality = 10 },
                new Item { Name = itemName, SellIn = -1, Quality = 49 }
            };
            IList<Item> ItemsExpected = new List<Item>
            {
                new Item { Name = itemName, SellIn = 0, Quality = 11 },
                new Item { Name = itemName, SellIn = -1, Quality = 12 },
                new Item { Name = itemName, SellIn = -2, Quality = 12 },
                new Item { Name = itemName, SellIn = -2, Quality = 50 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item;
            Item itemExpected;

            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                itemExpected = ItemsExpected[i];

                Console.WriteLine($"item: {item.Name}, {item.SellIn}, {item.Quality}");
                Console.WriteLine($"itemExpected: {item.Name}, {item.SellIn}, {item.Quality}");
                

                Assert.AreEqual(itemExpected.Name, item.Name, $"Item: {i}, Error: Expected Name '{itemExpected.Name}' but found '{item.Name}'");
                Assert.AreEqual(itemExpected.SellIn, item.SellIn, $"Item: {i}, Error: Expected SellIn '{itemExpected.SellIn}' but found '{item.SellIn}'");
                Assert.AreEqual(itemExpected.Quality, item.Quality, $"Item: {i}, Error: Expected Quality '{itemExpected.Quality}' but found '{item.Quality}'");
            }
        }

        [Test]
        public void ShouldIncreaseQualityForBackstagePasses()
        {
            var itemName = "Backstage passes to a TAFKAL80ETC concert";
            IList<Item> Items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 11, Quality = 5 },
                new Item { Name = itemName, SellIn = 10, Quality = 5 },
                new Item { Name = itemName, SellIn = 9, Quality = 49 },
                new Item { Name = itemName, SellIn = 5, Quality = 5 },
                new Item { Name = itemName, SellIn = 4, Quality = 49 },
                new Item { Name = itemName, SellIn = 0, Quality = 5 }
            };

            IList<Item> ItemsExpected = new List<Item>
            {
                new Item { Name = itemName, SellIn = 10, Quality = 6 },
                new Item { Name = itemName, SellIn = 9, Quality = 7 },
                new Item { Name = itemName, SellIn = 8, Quality = 50 },
                new Item { Name = itemName, SellIn = 4, Quality = 8 },
                new Item { Name = itemName, SellIn = 3, Quality = 50 },
                new Item { Name = itemName, SellIn = -1, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item;
            Item itemExpected;

            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                itemExpected = ItemsExpected[i];

                Console.WriteLine($"item: {item.Name}, {item.SellIn}, {item.Quality}");
                Console.WriteLine($"itemExpected: {item.Name}, {item.SellIn}, {item.Quality}");

                Assert.AreEqual(itemExpected.Name, item.Name, $"Item: {i}, Error: Expected Name '{itemExpected.Name}' but found '{item.Name}'");
                Assert.AreEqual(itemExpected.SellIn, item.SellIn, $"Item: {i}, Error: Expected SellIn '{itemExpected.SellIn}' but found '{item.SellIn}'");
                Assert.AreEqual(itemExpected.Quality, item.Quality, $"Item: {i}, Error: Expected Quality '{itemExpected.Quality}' but found '{item.Quality}'");
            }
        }

        [Test]
        public void ShouldNotUpdateQualityForSulfuras()
        {
            var itemName = "Sulfuras, Hand of Ragnaros";
            IList<Item> Items = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 80 },
                new Item { Name = itemName, SellIn = 0, Quality = 80 },
                new Item { Name = itemName, SellIn = -1, Quality = 80 }
            };

            IList<Item> ItemsExpected = new List<Item>
            {
                new Item { Name = itemName, SellIn = 1, Quality = 80 },
                new Item { Name = itemName, SellIn = 0, Quality = 80 },
                new Item { Name = itemName, SellIn = -1, Quality = 80 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Item item;
            Item itemExpected;

            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                itemExpected = ItemsExpected[i];

                Console.WriteLine($"item: {item.Name}, {item.SellIn}, {item.Quality}");
                Console.WriteLine($"itemExpected: {item.Name}, {item.SellIn}, {item.Quality}");

                Assert.AreEqual(itemExpected.Name, item.Name, $"Item: {i}, Error: Expected Name '{itemExpected.Name}' but found '{item.Name}'");
                Assert.AreEqual(itemExpected.SellIn, item.SellIn, $"Item: {i}, Error: Expected SellIn '{itemExpected.SellIn}' but found '{item.SellIn}'");
                Assert.AreEqual(itemExpected.Quality, item.Quality, $"Item: {i}, Error: Expected Quality '{itemExpected.Quality}' but found '{item.Quality}'");
            }
        }
    }
}
