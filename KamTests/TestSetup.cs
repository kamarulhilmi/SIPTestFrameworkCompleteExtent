using Framework;
using NUnit.Framework;

namespace KamTests
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void Start()
        {
            MyTestBase.BeginExecution();
        }

        [OneTimeTearDown]
        public void End()
        {
            MyTestBase.ExitExecution();
        }
    }
}
