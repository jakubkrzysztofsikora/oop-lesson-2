using MadScientistLab.Enums;
using MadScientistLab.LabInventory;
using MadScientistLab.Tests.TestStubs;
using NUnit.Framework;

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
        public void ShouldSendDogToBarkerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);
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
            laboratory.Create(testType, testName);

            //When
            laboratory.Barker(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.BarksMessages, Does.Not.Contain(testName));
        }

        [Test]
        public void ShouldMakeTheAnimalRested()
        {
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);

            //When
            laboratory.GoToSleep(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(0));
            Assert.That(stubbedCli.InfoMessages.Count, Is.EqualTo(2));// 2 messages, animal created + animal well rested
        }

        [Test]
        public void ShouldMakeTheAnimalfed()
        {
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);

            //When
            laboratory.GoEat(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(0));
            Assert.That(stubbedCli.InfoMessages.Count, Is.EqualTo(2));// 2 messages, animal created + animal well fed
        }

        [Test]
        public void ShouldDisplayAnimalList()
        {
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);
            stubbedCli.InfoMessages.Clear();
            //When
            laboratory.ListAnimals();

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(0));
            Assert.That(stubbedCli.InfoMessages[0], Is.EqualTo("Dog - Rex"));// 2 messages, animal created + animal well fed
        }

        [Test]
        public void ShouldAnimalFromList()
        {
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);
            stubbedCli.InfoMessages.Clear();
            //When
            laboratory.Delete(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(0));
            Assert.That(stubbedCli.InfoMessages[0], Is.EqualTo("Removed Rex from the lab"));// 2 messages, animal created + animal well fed
        }
    }
}
