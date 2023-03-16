namespace TrieClass.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddNewElementShouldContainItAndReturnTrue()
    {
        var trie = new Trie();
        bool isContain = trie.Add("ololo");
        Assert.Multiple(() =>
        {
            Assert.That(trie.Contains("ololo"), Is.True);
            Assert.That(isContain, Is.True);
        });
    }

    [Test] 
    public void AddNewElementShouldChangeSize()
    {
        var trie = new Trie();
        int firstSize = trie.Size;
        trie.Add("aba");
        int secondSize = trie.Size;

        Assert.That(secondSize - firstSize, Is.EqualTo(1));
    }

    [Test]
    public void AddExistingElementShouldReturnFalseAndNotChangeSize()
    {
        var trie = new Trie();
        trie.Add("aba");
        int firstSize = trie.Size;
        bool isContain = trie.Add("aba");
        int secondSize = trie.Size;

        Assert.Multiple(() =>
        {
            Assert.That(isContain, Is.False);
            Assert.That(firstSize - secondSize, Is.EqualTo(0));
        });
    }

    [Test]
    public void RemoveExistingElementShouldNotContainItAndReturnTrue()
    {
        var trie = new Trie();
        trie.Add("olo");
        trie.Add("ololo");
        trie.Add("o");
        bool isContain = trie.Remove("o");

        Assert.Multiple(() =>
        {
            Assert.That(trie.Contains("o"), Is.False);
            Assert.That(isContain, Is.True);
        });
    }

    [Test]
    public void RemoveNotContainedStringShouldReturnFalse()
    {
        var trie = new Trie();

        Assert.That(trie.Remove("aba"), Is.False);
    }

    [Test] 
    public void RemoveElementShouldChangeSize()
    {
        var trie = new Trie();
        trie.Add("abab");
        int firstSize = trie.Size;
        trie.Remove("abab");
        int secondSize = trie.Size;

        Assert.That(firstSize - secondSize, Is.EqualTo(1));
    }

    [Test]
    public void ContainsShouldReturnFalseToNotContainedString()
    {
        var trie = new Trie();

        Assert.That(trie.Contains("aba"), Is.False);
    }

    [Test] 
    public void HowManyStartsWithPrefixShouldWork()
    {
        var trie = new Trie();
        trie.Add("ababc");
        trie.Add("aba");
        trie.Add("a");
        trie.Add("abca");

        Assert.That(trie.HowManyStartsWithPrefix("aba"), Is.EqualTo(2));
    }

    [Test]
    public void SizeOfTrieShouldWork()
    {
        var trie = new Trie();
        trie.Add("abc");
        trie.Add("aba");

        Assert.That(trie.Size, Is.EqualTo(2));
    }
}
