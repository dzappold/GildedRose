using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRose.Console;

namespace GildedRose.Tests
{
    class AnAgedBrie
    {
        Inventory store;
	    Item agedBrie;
	    int oldQuality = 15;

	    [SetUp]
	    public void setUp() {
		    store = new Inventory();
		    store.Items = new List<Item>();
            agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = oldQuality };
	    }

	    [Test]
	    public void shouldIncreaseInQualityWhileAging() {
		    agedBrie.SellIn = 15;
		    store.Items.Add(agedBrie);
		    store.UpdateQuality();

		    Assert.That(agedBrie.Quality, Is.EqualTo(oldQuality + 1));
	    }

	    [Test]
	    public void shouldDoubleItsQualityIncreaseWhenOverdue() {
		    agedBrie.SellIn = -5;
		    store.Items.Add(agedBrie);
		    store.UpdateQuality();

		    Assert.That(agedBrie.Quality, Is.EqualTo(oldQuality + 2));
	    }
	
	    [Test]
	    public void qualityCannotExceedMaximumQuality() {
		    agedBrie.Quality = 50;
		    store.Items.Add(agedBrie);
		    store.UpdateQuality();
		    Assert.That(agedBrie.Quality, Is.LessThanOrEqualTo(50));
	    }
    }
}
