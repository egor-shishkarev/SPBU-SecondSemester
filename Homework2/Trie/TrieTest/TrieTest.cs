namespace Trie.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddNullStringShouldThrowException()
    {
        var trie = new Trie();
        
        Assert.Throws<Exception>(() => Trie.Add(null));
    }

    [Test]
    public void RemoveNullStringShouldThrowException() 
    {
         
    }

    [Test]
    public void ContainNullStringShouldThrowEXception()
    {

    }

    [Test]
    public void HowManyStartsWithPrefixNullPrefixShouldThrowException()
    {

    }

    [Test]
    public void ContainElementShouldWork()
    {

    }

    [Test]
    public void AddNewElementShouldContainIt()
    {

    }

    [Test]
    public void RemoveElementShouldNotContainIt()
    {

    }

    [Test] 
    public void HowManyStartsWithPrefixShouldWork()
    {

    }

    [Test]
    public void SizeOfTrieShouldWork()
    {

    }

    [Test]
    public void RemoveFromNullOrEmptyTrieShoulThrowException()
    {

    }
}
