using NUnit.Framework;
using System;

public class BnfLabelTest
{
    string validLow, validMid, validHigh;
    string invalidEmpty, invalidHigh;
    int intValidLow, intValidMid, intValidHigh, intBadLow, intBadHigh;

    BnfLabel bnfLabel;

    [SetUp]
    public void Setup()
    {
        validLow = "a"; //1
        validMid = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx"; // 100
        validHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx" +
            "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxabcdefghijklmnopqrstuvwxyzabcdefghi"; //185

        invalidEmpty = "";
        invalidHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx" +
            "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxabcdefghijklmnopqrstuvwxyzabcdefghij"; //186

        intValidLow = 1;
        intValidMid = 16;
        intValidHigh = 32;

        intBadLow = 0;
        intBadHigh = 33;

        bnfLabel = new BnfLabel(intValidLow,validHigh);
        
    }

    [Test]
    public void testBnfLabelConstructorValid()

    {
        Assert.AreEqual(intValidLow, bnfLabel.Number);
        Assert.AreEqual(validHigh, bnfLabel.Label);

    }

    [Test]
    public void testBnfLabelConstructorInValid()

    {
        Assert.Throws<ArgumentException>(() => new BnfLabel(intBadLow, validMid));
        Assert.Throws<ArgumentOutOfRangeException>(() => new BnfLabel(intValidHigh, invalidEmpty));

    }

    [Test]
    public void medicationNumberValid()
    {
        bnfLabel.Number = intValidLow;
        Assert.AreEqual(intValidLow, bnfLabel.Number);

        bnfLabel.Number = intValidMid;
        Assert.AreEqual(intValidMid, bnfLabel.Number);

        bnfLabel.Number = intValidHigh;
        Assert.AreEqual(intValidHigh, bnfLabel.Number);

    }

    [Test]
    public void medicationExpectedDoseInValid()
    {
        Assert.Throws<ArgumentException>(() => bnfLabel.Number = intBadLow);
        Assert.Throws<ArgumentException>(() => bnfLabel.Number = intBadHigh);
    }

    [Test]
    public void medicationDoseValid()
    {
        bnfLabel.Label = validLow;
        Assert.AreEqual(validLow, bnfLabel.Label);

        bnfLabel.Label = validMid;
        Assert.AreEqual(validMid, bnfLabel.Label);

        bnfLabel.Label = validHigh;
        Assert.AreEqual(validHigh, bnfLabel.Label);

    }

    [Test]
    public void medicationDoseInValid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => bnfLabel.Label = invalidEmpty);
        Assert.Throws<ArgumentOutOfRangeException>(() => bnfLabel.Label = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => bnfLabel.Label = null);
    }
}
