using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRose.Console;
using GildedRose.Tests;

namespace GildedRose.Tests
{
    class ABackstagePass
    {
        	Inventory store;

	[SetUp]
	public void setUp() {
		store = new Inventory();
		store.Items = new List<Item>();
	}

	[Test]
	public void with11DaysShouldIncreaseQualityByOne() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 30};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.EqualTo(31));
	}

	[Test]
	public void with10DaysShouldIncreaseQualityByTwo() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.EqualTo(32));
	}

	[Test]
	public void with6DaysShouldIncreaseQualityByTwo() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 30};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.EqualTo(32));
	}

	[Test]
	public void with5DaysShouldIncreaseQualityByThree() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.EqualTo(33));
	}

	[Test]
	public void shouldHaveZeroQualityWhenTheConcertIsOver() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.EqualTo(InventoryTest.MIN_QUALITY));
	}

	[Test]
	public void qualityCannotExceedMaximumQuality() {
		Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50};
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.LessThanOrEqualTo(50));
	}

	[Test]
	public void qualityCannotExceedMinimumQuality() {
        Item backstagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = -50 };
		store.Items.Add(backstagePass);
		store.UpdateQuality();
		Assert.That(backstagePass.Quality, Is.LessThan(0));
	}
    }
}
