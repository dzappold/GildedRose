using GildedRose.Console;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose.Tests
{
	[TestFixture]
    public class InventoryTest
    {
		[Test]
        public void TestTheTruth()
        {
			Assert.IsTrue(true);
        }

		public static readonly int MIN_QUALITY = 0;

		public static readonly int MAX_QUALITY = 50;

		Inventory Store;

		Item oldBoots;
		int bootSellIn = 100;
		int bootQuality = 1;

		Item overdueMustardYoghurt;
		int overdueMustardYoghurtQuality = 10;

		[SetUp]
		public void SetUp() {
			Store = new Inventory(){
				Items = new List<Item>
				{
					new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
					new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
					new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
					new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
					new Item
					{
						Name = "Backstage passes to a TAFKAL80ETC concert",
						SellIn = 15,
						Quality = 20
					},
					new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
				}

			};

			oldBoots = new Item {Name = "Boot", SellIn = bootSellIn, Quality = bootQuality};
			overdueMustardYoghurt = new Item {Name = "Mustard-Yoghurt", SellIn = 0, Quality = overdueMustardYoghurtQuality};
		}
		
		[Test]
		public void AtEndOfTheDayItemQualityShouldBeDecreasedByOne() {
			Store.Items.Add(oldBoots);
			Store.UpdateQuality();

            Assert.That(oldBoots.Quality, Is.EqualTo(bootQuality - 1));
		}
        
		[Test]
		public void AtEndOfTheDayItemSellInShouldBeDecreasedByOne() {
			Store.Items.Add(oldBoots);
			Store.UpdateQuality();

			Assert.That(oldBoots.SellIn, Is.EqualTo(bootSellIn - 1));
		}

		[Test]
		public void AtEndOfTheDayItemQualityShouldBeDecreasedByTwoWhenSellInDateHasPassed() {
			Store.Items.Add(overdueMustardYoghurt);
			Store.UpdateQuality();

			Assert.That(overdueMustardYoghurt.Quality, Is.EqualTo(overdueMustardYoghurtQuality - 2));
		}

		[Test]
		public void QualityCanNeverBeDecreasedBelowMinimumQuality() {
            Item deOideLederhosn = new Item { Name = "Lederhose", SellIn = 1000, Quality = MIN_QUALITY };
			Store.Items.Add(deOideLederhosn);
			Store.UpdateQuality();

			Assert.That(deOideLederhosn.Quality, Is.GreaterThanOrEqualTo(MIN_QUALITY));
		}

		[Test]
		public void QualityCannotExceedMaximumQuality() {
			Item goldenSunWatch = new Item{Name = "Golden Pocket Sun Watch", SellIn = 14, Quality = MAX_QUALITY};
			Store.Items.Add(goldenSunWatch);
			Store.UpdateQuality();
			Assert.That(goldenSunWatch.Quality, Is.LessThanOrEqualTo(MAX_QUALITY));
		}
    }
}