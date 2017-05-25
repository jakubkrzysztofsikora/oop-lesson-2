using MadScientistLab.Enums;
using MadScientistLab.LabInventory;
using MadScientistLab.Tests.TestStubs;
using NUnit.Framework;
using System.Collections.Generic;

namespace MadScientistLab.Tests
{
    [TestFixture]
    public class LaboratoryTests
    {
        [Test]
        public void ShouldCreateAnimalWithGivenNameAndType()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            string expectedInfo = $"Created {testType} with name {testName}.";

            //When
            laboratory.Create(testType, testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }

        [Test]
        public void ShouldDeleteAnimalWithGivenName()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            string expectedInfo = $"Removed {testName} from the lab";
            laboratory.Create(AnimalTypeEnum.Cat, testName);

            //When
            laboratory.Delete(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }

  
        [Test]
        public void ShouldSendDogToBarkerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(AnimalTypeEnum.Dog, testName);
            laboratory.GoEat(testName);
            laboratory.GoToSleep(testName);

            //When
            laboratory.Barker(testName);

            //Then
            Assert.That(stubbedCli.BarksMessages, Does.Contain(testName));
        }

        [Test]
        public void ShouldDisplayErrorWhenDogIsNotFedOrRestedButSentToBarker()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(AnimalTypeEnum.Dog, testName);

            //When
            laboratory.Barker(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.BarksMessages, Does.Not.Contain(testName));
        }

        [Test]
        public void ShouldSendCatToPurrerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            laboratory.Create(AnimalTypeEnum.Cat, testName);
            laboratory.GoEat(testName);
            laboratory.GoToSleep(testName);

            //When
            laboratory.Purrer(testName);

            //Then
            Assert.That(stubbedCli.PurrsMessages, Does.Contain(testName));
        }

        [Test]
        public void ShouldDisplayErrorWhenCatIsNotFedOrRestedButSentToPurrer()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            laboratory.Create(AnimalTypeEnum.Cat, testName);

            //When
            laboratory.Purrer(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.PurrsMessages, Does.Not.Contain(testName));
        }
        [Test]
        public void ShouldSendRatToSqueakerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Rat;
            string testName = "Jerry";
            laboratory.Create(AnimalTypeEnum.Rat, testName);
            laboratory.GoEat(testName);
            laboratory.GoToSleep(testName);

            //When
            laboratory.Squeaker(testName);

            //Then
            Assert.That(stubbedCli.SqueaksMessages, Does.Contain(testName));
        }

        [Test]
        public void ShouldDisplayErrorWhenRatIsNotFedOrRestedButSentToSqueaker()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Rat;
            string testName = "Jerry";
            laboratory.Create(AnimalTypeEnum.Rat, testName);

            //When
            laboratory.Squeaker(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.SqueaksMessages, Does.Not.Contain(testName));
        }

    }
}
