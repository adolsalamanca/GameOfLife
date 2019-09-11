using NUnit.Framework;

namespace GameOfLifeKata.test
{
    public class LoggerTest
    {
        private Logger _logger;
        private const string STRING_MESSAGE = "TestMessage";

        [SetUp]
        public void SetUp()
        {
            _logger = new Logger();
        }

        [TearDown]
        public void TearDown()
        {
            _logger = null;
        }

        [Test]
        public void should_exist_method_to_print_new_lines()
        {
            _logger.PrintLine(STRING_MESSAGE);
        }

        [Test]
        public void should_exist_method_to_print_in_the_same_line()
        {
            _logger.Print(STRING_MESSAGE);
        }
    }
}