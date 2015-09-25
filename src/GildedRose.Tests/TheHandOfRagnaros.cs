using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GildedRose.Console;

namespace GildedRose.Tests
{
    class TheHandOfRagnaros
    {
	    Inventory store;

	    [SetUp]
	    public void setUp() {
		    store = new Inventory();
		    store.Items = new List<Item>();
	    }

	    [Test]
	    public void shouldNotDecreaseInQuality() {
		    Item sulfura = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
		    store.Items.Add(sulfura);
		    store.UpdateQuality();
		    Assert.That(sulfura.Quality, Is.GreaterThanOrEqualTo(80));
	    }

	    [Test]
	    public void shouldNotGetOlder() {
		    Item sulfura = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80};
		    store.Items.Add(sulfura);
		    store.UpdateQuality();
		    Assert.That(sulfura.SellIn, Is.EqualTo(10));
	    }
    }
}
