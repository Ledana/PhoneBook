using PhoneBook.Ledana;

namespace TestProject1
{
    public class InputValidatorTests
    {

        [Test]
        public void IsEmailValid_WhenCalledWithValidInput_ReturnsTrue()
        {
            var email = "as@is.it";
            var result = InputValidator.IsEmailValid(email);

            Assert.That(result, Is.True);
        }
        [Test]
        public void IsEmailValid_WithEmailWithoutAtOrDot_ReturnsFalse()
        {
            var email = "sd@gf";
            var result = InputValidator.IsEmailValid(email);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsEmailValid_WithEmailWithAtAndWithoutDot_ReturnsFalse()
        {
            var email = "sd@gf";
            var result = InputValidator.IsEmailValid(email);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsEmailValid_WithEmailWithDotAndWithoutAt_ReturnsFalse()
        {
            var email = "sdg.f";
            var result = InputValidator.IsEmailValid(email);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsNumberValid_WhenCalledWithValidNumber_ReturnsTrue()
        {
            var number = "+355690124789";
            var result = InputValidator.IsNumberValid(number);

            Assert.That(result, Is.True);
        }
        [Test]
        public void IsNumberValid_WithNumberStartsWithPlusButTooShort_ReturnsTrue()
        {
            var number = "+35569512";
            var result = InputValidator.IsNumberValid(number);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsNumberValid_WithNumberDoesntStartsWithPlusAndLongEnough_ReturnsTrue()
        {
            var number = "0355695127755";
            var result = InputValidator.IsNumberValid(number);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsNumberValid_WithNumberStartsWithPlusAndLongEnoughButContainsLetters_ReturnsTrue()
        {
            var number = "+35569op27755";
            var result = InputValidator.IsNumberValid(number);

            Assert.That(result, Is.False);
        }
        [Test]
        public void IsNumberValid_NumberHasOnlyLetters_ReturnsTrue()
        {
            var number = "+tgrd";
            var result = InputValidator.IsNumberValid(number);

            Assert.That(result, Is.False);
        }
    }
}
