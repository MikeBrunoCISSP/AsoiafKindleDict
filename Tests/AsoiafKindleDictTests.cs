using AsoiafKindleDict.Api.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;
[TestClass]
public class AsoiafKindleDictTests {
    [TestMethod]
    public void TestCreateDictionary() {
        var characterIndex = new IndexDto("Characters");
        characterIndex.AddWord("Tywin Lannister", "Lord of Casterly Rock");
        characterIndex.AddWord("Daenerys Targaryen", "The stormborn");

        var locationIndex = new IndexDto("Locations");
        locationIndex.AddWord("Winterfell", "Seat of House Stark");
        locationIndex.AddWord("Highgarden", "Seat of House Tyrell");

        var dictionary = new DictionaryDto("A Song of Ice and Fire Kindle Dictionary", "Mike Bruno");
        dictionary.AddIndex(characterIndex);
        dictionary.AddIndex(locationIndex);
        dictionary.CreateArtifacts(@"P:\_temp");
    }
}