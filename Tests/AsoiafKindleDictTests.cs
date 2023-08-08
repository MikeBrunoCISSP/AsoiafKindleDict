using AsoiafKindleDict.Api.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;
[TestClass]
public class AsoiafKindleDictTests {
    [TestMethod]
    public void TestCreateDictionary() {
        var dictionary = new DictionaryDto("A Song of Ice and Fire Kindle Dictionary", "Mike Bruno");
        dictionary.AddWord("Tywin Lannister", "Lord of Casterly Rock", "Characters");
        dictionary.AddWord("Daenerys Targaryen", "The stormborn", "Characters");
        dictionary.AddWord("Winterfell", "Seat of House Stark", "Locations");
        dictionary.AddWord("Highgarden", "Seat of House Tyrell", "Locations");
        dictionary.CreateArtifacts(@"P:\_temp");
    }
}