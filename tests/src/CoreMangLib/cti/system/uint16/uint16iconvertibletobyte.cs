using System;

/// <summary>
/// UInt16.System.IConvertible.ToByte(IFormatPrvoider)
/// </summary>
public class UInt16IConvertibleToByte
{
    public static int Main()
    {
        UInt16IConvertibleToByte testObj = new UInt16IConvertibleToByte();

        TestLibrary.TestFramework.BeginTestCase("for method: UInt16.System.IConvertible.ToByte(IFormatProvider)");
        if(testObj.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = NegTest1() && retVal;

        return retVal;
    }

    #region Positive tests
    public bool PosTest1()
    {
        bool retVal = true;
        string errorDesc;

        UInt16 uintA;
        Byte expectedValue;
        Byte actualValue;
        IConvertible convert;

        uintA = (UInt16)(TestLibrary.Generator.GetInt32(-55) % (Byte.MaxValue + 1));

        TestLibrary.TestFramework.BeginScenario("PosTest1: Random UInt16 value between 0 and Byte.MaxValue.");
        try
        {
            convert = (IConvertible)uintA;

            actualValue = convert.ToByte(null);
            expectedValue = (byte)uintA;

            if (actualValue != expectedValue)
            {
                errorDesc = "The byte value of " + uintA + " is not the value " + expectedValue + 
                                 " as expected: actual(" + actualValue + ")";
                TestLibrary.TestFramework.LogError("001", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            TestLibrary.TestFramework.LogError("002", errorDesc);
            retVal = false;
        }
        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;
        string errorDesc;

        UInt16 uintA;
        Byte expectedValue;
        Byte actualValue;
        IConvertible convert;

        uintA = byte.MaxValue;

        TestLibrary.TestFramework.BeginScenario("PosTest2: value is Byte.MaxValue.");
        try
        {
            convert = (IConvertible)uintA;
            actualValue = convert.ToByte(null);
            expectedValue = (byte)uintA;

            if (actualValue != expectedValue)
            {
                errorDesc = "The byte value of " + uintA + " is not the value " + expectedValue +
                                 " as expected: actual(" + actualValue + ")";
                TestLibrary.TestFramework.LogError("003", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            TestLibrary.TestFramework.LogError("004", errorDesc);
            retVal = false;
        }
        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;
        string errorDesc;

        UInt16 uintA;
        Byte expectedValue;
        Byte actualValue;
        IConvertible convert;

        uintA = UInt16.MinValue;

        TestLibrary.TestFramework.BeginScenario("PosTest3: value is UInt16.MinValue.");
        try
        {
            convert = (IConvertible)uintA;
            actualValue = convert.ToByte(null);
            expectedValue = (byte)uintA;

            if (actualValue != expectedValue)
            {
                errorDesc = "The byte value of " + uintA + " is not the value " + expectedValue +
                                 " as expected: actual(" + actualValue + ")";
                TestLibrary.TestFramework.LogError("005", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            TestLibrary.TestFramework.LogError("006", errorDesc);
            retVal = false;
        }
        return retVal;
    }
    #endregion

    #region Negative tests

    //OverflowException
    public bool NegTest1()
    {
        bool retVal = true;

        const string c_TEST_ID = "N001";
        const string c_TEST_DESC = "NegTest1: value is greater than Byte.MaxValue";
        string errorDesc;

        UInt16 uintA;
        IConvertible convert;

        uintA = byte.MaxValue + 1;
        convert = (IConvertible)uintA;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            convert.ToByte(null);
            errorDesc = "OverflowException is not thrown as expected.";
            TestLibrary.TestFramework.LogError("011" + " TestId-" + c_TEST_ID, errorDesc);
            retVal = false;

        }
        catch (OverflowException)
        { }
        catch (Exception e)
        {
            errorDesc = "Unexpected exception: " + e;
            TestLibrary.TestFramework.LogError("012" + " TestId-" + c_TEST_ID, errorDesc);
            retVal = false;
        }
        return retVal;
    }

    #endregion
}

