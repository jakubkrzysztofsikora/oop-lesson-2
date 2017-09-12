using System.Collections.Generic;
using System.Linq;
using MadScientistLab.Cli;
using MadScientistLab.Configuration;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory;
using MadScientistLab.Tests.TestStubs;
using NUnit.Framework;

namespace MadScientistLab.Tests
{
    [TestFixture]
    public class LaboratoryTests
    {
        [TestCase(AnimalTypeEnum.Cat, "Tom")]
        [TestCase(AnimalTypeEnum.Coyote, "Frank")]
        [TestCase(AnimalTypeEnum.Dog, "Rex")]
        [TestCase(AnimalTypeEnum.Hamster, "Chomik")]
        [TestCase(AnimalTypeEnum.Lion, "Simba")]
        [TestCase(AnimalTypeEnum.Mouse, "Jerry")]
        [TestCase(AnimalTypeEnum.Rat, "Vlad")]
        [TestCase(AnimalTypeEnum.Tiger, "Enzo")]
        [TestCase(AnimalTypeEnum.Wolf, "Geralt")]
        public void ShouldCreateAnimalWithGivenNameAndType(AnimalTypeEnum testType, string testName)
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            string expectedInfo = $"Created {testType} with name {testName}.";

            //When
            laboratory.Create(testType, testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }

        [TestCase(AnimalTypeEnum.Cat, "Tom")]
        [TestCase(AnimalTypeEnum.Coyote, "Frank")]
        [TestCase(AnimalTypeEnum.Dog, "Rex")]
        [TestCase(AnimalTypeEnum.Hamster, "Chomik")]
        [TestCase(AnimalTypeEnum.Lion, "Simba")]
        [TestCase(AnimalTypeEnum.Mouse, "Jerry")]
        [TestCase(AnimalTypeEnum.Rat, "Vlad")]
        [TestCase(AnimalTypeEnum.Tiger, "Enzo")]
        [TestCase(AnimalTypeEnum.Wolf, "Geralt")]
        public void ShouldSentAnimalToEat(AnimalTypeEnum testType, string testName)
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            laboratory.Create(testType, testName);
            string expectedSuccessMessage = CommonConstants.GoEatSuccessMessage;

            //When
            laboratory.GoEat(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages.Any(message => message.Contains(testName) && message.Contains(expectedSuccessMessage)));
        }

        [TestCase(AnimalTypeEnum.Cat, "Tom")]
        [TestCase(AnimalTypeEnum.Coyote, "Frank")]
        [TestCase(AnimalTypeEnum.Dog, "Rex")]
        [TestCase(AnimalTypeEnum.Hamster, "Chomik")]
        [TestCase(AnimalTypeEnum.Lion, "Simba")]
        [TestCase(AnimalTypeEnum.Mouse, "Jerry")]
        [TestCase(AnimalTypeEnum.Rat, "Vlad")]
        [TestCase(AnimalTypeEnum.Tiger, "Enzo")]
        [TestCase(AnimalTypeEnum.Wolf, "Geralt")]
        public void ShouldSentAnimalToSleep(AnimalTypeEnum testType, string testName)
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            laboratory.Create(testType, testName);
            string expectedSuccessMessage = CommonConstants.GoSleepSuccessMessage;

            //When
            laboratory.GoToSleep(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages.Any(message => message.Contains(testName) && message.Contains(expectedSuccessMessage)));
        }

        [Test]
        public void ShouldSendDogToBarkerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
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
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
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
        public void ShouldSendCatToPurrerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            laboratory.Create(testType, testName);
            laboratory.GoEat(testName);
            laboratory.GoToSleep(testName);

            //When
            laboratory.Purrer(testName);

            //Then
            Assert.That(stubbedCli.PurrsMessages, Does.Contain(testName));
        }

        [Test]
        public void ShouldDisplayErrorWhenCatIsNotFedOrRestedButSentTPurrer()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            laboratory.Create(testType, testName);

            //When
            laboratory.Purrer(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.PurrsMessages, Does.Not.Contain(testName));
        }

        [Test]
        public void ShouldSendMouseToSqueakerIfFedAndRested()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Mouse;
            string testName = "Jerry";
            laboratory.Create(testType, testName);
            laboratory.GoEat(testName);
            laboratory.GoToSleep(testName);

            //When
            laboratory.Squeaker(testName);

            //Then
            Assert.That(stubbedCli.SqueaksMessages, Does.Contain(testName));
        }

        [Test]
        public void ShouldDisplayErrorWhenMouseIsNotFedOrRestedButSentToSqueaker()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Mouse;
            string testName = "Jerry";
            laboratory.Create(testType, testName);

            //When
            laboratory.Squeaker(testName);

            //Then
            Assert.That(stubbedCli.ErrorsMessages.Count, Is.EqualTo(1));
            Assert.That(stubbedCli.SqueaksMessages, Does.Not.Contain(testName));
        }

        [Test]
        public void ShouldListAllAnimalsInTheLaboratory()
        {
            //Given
            Dictionary<AnimalTypeEnum, string> givenCollectionOfAnimals = new Dictionary<AnimalTypeEnum, string>
            {
                { AnimalTypeEnum.Mouse, "Jerry" },
                { AnimalTypeEnum.Cat, "Tom" },
                { AnimalTypeEnum.Dog, "Rex" }
            };
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AddCollectionOfAnimalsToLaboratory(givenCollectionOfAnimals, laboratory);

            //When
            laboratory.ListAnimals();

            //Then
            foreach (var animal in givenCollectionOfAnimals)
            {
                Assert.That(stubbedCli.InfoMessages, Does.Contain($"{animal.Key} - {animal.Value}"));
            }
        }

        [Test]
        public void ShouldDeleteAnimalFromLaboratory()
        {
            //Given
            Dictionary<AnimalTypeEnum, string> givenCollectionOfAnimals = new Dictionary<AnimalTypeEnum, string>
            {
                { AnimalTypeEnum.Mouse, "Jerry" },
                { AnimalTypeEnum.Cat, "Tom" },
                { AnimalTypeEnum.Dog, "Rex" }
            };
            KeyValuePair<AnimalTypeEnum, string> animalToDelete = givenCollectionOfAnimals.First();
            StubCommandInterface stubbedCli = new StubCommandInterface();
            LabInventory.Laboratory laboratory = GivenLaboratory(stubbedCli);
            AddCollectionOfAnimalsToLaboratory(givenCollectionOfAnimals, laboratory);

            //When
            laboratory.Delete(animalToDelete.Value);

            //Then
            laboratory.ListAnimals();
            Assert.That(stubbedCli.InfoMessages, Does.Not.Contains($"{animalToDelete.Key} - {animalToDelete.Value}"));
        }

        private void AddCollectionOfAnimalsToLaboratory(Dictionary<AnimalTypeEnum, string> givenCollectionOfAnimals, LabInventory.Laboratory lab)
        {
            foreach (var animal in givenCollectionOfAnimals)
            {
                lab.Create(animal.Key, animal.Value);
            }
        }

        private Laboratory GivenLaboratory(ICommandInterface cli)
        {
            return new Laboratory(cli);
        }
    }
}