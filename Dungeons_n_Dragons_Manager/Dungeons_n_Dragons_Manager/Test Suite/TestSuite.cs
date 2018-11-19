using Dungeons_n_Dragons_Manager.Test_Suite.Tests;
using System;
using System.Collections.Generic;

namespace Dungeons_n_Dragons_Manager.Test_Suite
{
    internal class TestSuite
    {
        public TestSuite()
        {
            m_testingOutput = new List<string>();
        }

        private List<String> m_testingOutput { get; set; }

        public List<string> RunAllTests()
        {
            m_testingOutput.AddRange(m_encountersTabTests.RunAllTests()); //Add EncountersTab tests.

            return m_testingOutput;
        }

        private EncountersTabTests m_encountersTabTests = new EncountersTabTests();
    }
}