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
        public void ShouldSendDogToSleep()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);
            string expectedInfo = $"{testName} is well rested.";

            //When
            laboratory.GoToSleep(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }

        [Test]
        public void ShouldSendDogToEat()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Dog;
            string testName = "Rex";
            laboratory.Create(testType, testName);
            string expectedInfo = $"{testName} is well fed.";

            //When
            laboratory.GoEat(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }

        [Test]
        public void ShouldListAnimals()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            string[] testName = { "Rex", "Rox", "Rix" };
            AnimalTypeEnum[] testType = { AnimalTypeEnum.Cat, AnimalTypeEnum.Dog, AnimalTypeEnum.Rat };
            string[] expectedInfo = new string[testName.GetLength(0)];
            for (int i = 0; i < 2; i++)
            {
                laboratory.Create(testType[i], testName[i]);
                expectedInfo[i] = $"{testType[i]} - {testName[i]}";
            }


            //When
            laboratory.ListAnimals();

            //Then
            for (int i = 0; i < 2; i++)
            {
                Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo[i]));
            }
        }

        [Test]
        public void ShouldDeleteAnimalWithGivenName()
        {
            //Given
            StubCommandInterface stubbedCli = new StubCommandInterface();
            Laboratory laboratory = new Laboratory(stubbedCli);
            AnimalTypeEnum testType = AnimalTypeEnum.Cat;
            string testName = "Tom";
            laboratory.Create(testType, testName);
            string expectedInfo = $"Removed {testName} from the lab";

            //When
            laboratory.Delete(testName);

            //Then
            Assert.That(stubbedCli.InfoMessages, Does.Contain(expectedInfo));
        }
    }
}
