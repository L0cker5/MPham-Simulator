using NUnit.Framework;
using System;

public class MedicationTest
{
    string validLow, vaildEmpty, validMid, validHigh;
    string invalidEmpty, invalidHigh;
    float floatValidLow, floatValidMid, floatValidHigh, floatBadLow, floatBadHigh;
    int intValidLow, intValidMid, intValidHigh, intBadLow, intBadHigh;
    
    StrengthUnit kg, g, mg, mcg, ng, l, ml;
    MedicationType topical, suppositorie, drops, inhaler, tablet;

    bool isOutOfDate; 
    bool isSigned;

    Medication medication;

    [SetUp]
    public void Setup()
    {
        validLow = "a"; //1
        vaildEmpty = "";
        validMid = "abcdefghijklmnopqrstuvwxyz"; // 26
        validHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx"; //50
        
        invalidEmpty = "";
        invalidHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxy"; //51

        floatValidLow = 1f;
        floatValidMid = 5000f;
        floatValidHigh = 10000f;
        
        floatBadLow = 0f;
        floatBadHigh = 10001f;

        intValidLow = 1;
        intValidMid = 50;
        intValidHigh = 100;
        
        intBadLow = 0;
        intBadHigh = 101;

        kg = StrengthUnit.kg;
        g = StrengthUnit.g;
        mg = StrengthUnit.mg;
        mcg = StrengthUnit.mcg;
        ng = StrengthUnit.ng;
        l = StrengthUnit.L;
        ml = StrengthUnit.mL;
       
        topical = MedicationType.Topical;
        suppositorie = MedicationType.Suppositorie;
        drops = MedicationType.Drops;
        inhaler = MedicationType.Inhaler;
        tablet = MedicationType.Tablet;
        

        isOutOfDate = false;
        isSigned = false;

        medication = new Medication(validLow, floatValidLow, kg, tablet, validMid, intValidLow, validHigh, 
            intValidMid, vaildEmpty, isOutOfDate, isSigned);
    }

    [Test]
    public void testMedicationConstructorValid()

    {
        Assert.AreEqual(validLow, medication.MedicationName);
        Assert.AreEqual(floatValidLow, medication.Strength);
        Assert.AreEqual(kg, medication.StrengthUnit);
        Assert.AreEqual(tablet, medication.MedicationType);
        Assert.AreEqual(validMid, medication.Dose);
        Assert.AreEqual(intValidLow, medication.ExpectedDose);
        Assert.AreEqual(validHigh, medication.DosingFrequency);
        Assert.AreEqual(intValidMid, medication.Quantity);
        Assert.AreEqual(vaildEmpty, medication.BnfLabels);
        Assert.AreEqual(isOutOfDate, medication.IsOutOfDate);
        Assert.AreEqual(isSigned, medication.IsSigned);
    }

    [Test]
    public void testMedicationConstructorInValid()
    {
        //Medication Name
        Assert.Throws<ArgumentOutOfRangeException>(() => new Medication(invalidEmpty, floatValidLow, kg, tablet, validMid, 
            intValidLow, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Strength
        Assert.Throws<ArgumentException>(() => new Medication(validLow, floatBadLow, kg, tablet, validMid,
            intValidLow, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Strength Unit
        //Assert.Throws<ArgumentException>(() => new Medication(validLow, floatValidLow, null, tablet, validMid,
        //    intValidLow, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Medication Type
        //Assert.Throws<ArgumentException>(() => new Medication(validLow, floatValidLow, kg, null, validMid,
        //    intValidLow, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Dose
        Assert.Throws<ArgumentOutOfRangeException>(() => new Medication(validLow, floatValidLow, ml, suppositorie, invalidHigh,
            intValidLow, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Expected Dose
        Assert.Throws<ArgumentException>(() => new Medication(validLow, floatValidLow, ml, suppositorie, validHigh,
            intBadHigh, validHigh, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Dosing Frequency
        Assert.Throws<ArgumentOutOfRangeException>(() => new Medication(validLow, floatValidLow, ml, suppositorie, validHigh,
            intValidMid, invalidEmpty, intValidMid, vaildEmpty, isOutOfDate, isSigned));
        //Quantity
        Assert.Throws<ArgumentException>(() => new Medication(validLow, floatValidLow, ml, suppositorie, validHigh,
            intValidMid, validMid, intBadLow, vaildEmpty, isOutOfDate, isSigned));
        //Bnf Labels
        Assert.Throws<ArgumentOutOfRangeException>(() => new Medication(validLow, floatValidLow, ml, suppositorie, validHigh,
            intValidMid, validLow, intValidMid, invalidHigh, isOutOfDate, isSigned));
    }

    //Medication Name

    [Test]
    public void medicationNameValid()
    {
        medication.MedicationName = validLow;
        Assert.AreEqual(validLow, medication.MedicationName);

        medication.MedicationName = validMid;
        Assert.AreEqual(validMid, medication.MedicationName);

        medication.MedicationName = validHigh;
        Assert.AreEqual(validHigh, medication.MedicationName);

    }

    [Test]
    public void medicationNameInValid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.MedicationName = invalidEmpty);
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.MedicationName = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => medication.MedicationName = null);

    }

    //Strength
    [Test]
    public void medicationStrengthValid()
    {
        medication.Strength = floatValidLow;
        Assert.AreEqual(floatValidLow, medication.Strength);

        medication.Strength = floatValidMid;
        Assert.AreEqual(floatValidMid, medication.Strength);

        medication.Strength = floatValidHigh;
        Assert.AreEqual(floatValidHigh, medication.Strength);

    }

    [Test]
    public void medicationStrengthInValid()
    {
        Assert.Throws<ArgumentException>(() => medication.Strength = floatBadLow);
        Assert.Throws<ArgumentException>(() => medication.Strength = floatBadHigh);
    }

    //Strength Unit
    [Test]
    public void medicationStrengthUnitValid()
    {
        medication.StrengthUnit = kg;
        Assert.AreEqual(kg, medication.StrengthUnit);
        medication.StrengthUnit = g;
        Assert.AreEqual(g, medication.StrengthUnit);
        medication.StrengthUnit = mg;
        Assert.AreEqual(mg, medication.StrengthUnit);
        medication.StrengthUnit = mcg;
        Assert.AreEqual(mcg, medication.StrengthUnit);
        medication.StrengthUnit = ng;
        Assert.AreEqual(ng, medication.StrengthUnit);
        medication.StrengthUnit = l;
        Assert.AreEqual(l, medication.StrengthUnit);
        medication.StrengthUnit = ml;
        Assert.AreEqual(ml, medication.StrengthUnit);
    }

    //Medication Type
    [Test]
    public void medicationMedicationTypeValid()
    {
        medication.MedicationType = topical;
        Assert.AreEqual(topical, medication.MedicationType);
        medication.MedicationType = suppositorie;
        Assert.AreEqual(suppositorie, medication.MedicationType);
        medication.MedicationType = drops;
        Assert.AreEqual(drops, medication.MedicationType);
        medication.MedicationType = inhaler;
        Assert.AreEqual(inhaler, medication.MedicationType);
        medication.MedicationType = tablet;
        Assert.AreEqual(tablet, medication.MedicationType);
    }

    //Dose
    [Test]
    public void medicationDoseValid()
    {
        medication.Dose = validLow;
        Assert.AreEqual(validLow, medication.Dose);

        medication.Dose = validMid;
        Assert.AreEqual(validMid, medication.Dose);

        medication.Dose = validHigh;
        Assert.AreEqual(validHigh, medication.Dose);

    }

    [Test]
    public void medicationDoseInValid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.Dose = invalidEmpty);
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.Dose = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => medication.Dose = null);
    }

    //Expected Dose
    [Test]
    public void medicationExpectedDoseValid()
    {
        medication.ExpectedDose = intValidLow;
        Assert.AreEqual(intValidLow, medication.ExpectedDose);

        medication.ExpectedDose = intValidMid;
        Assert.AreEqual(intValidMid, medication.ExpectedDose);

        medication.ExpectedDose = intValidHigh;
        Assert.AreEqual(intValidHigh, medication.ExpectedDose);

    }

    [Test]
    public void medicationExpectedDoseInValid()
    {
        Assert.Throws<ArgumentException>(() => medication.ExpectedDose = intBadLow);
        Assert.Throws<ArgumentException>(() => medication.ExpectedDose = intBadHigh);
    }
    
    //Dosing Frequency
    [Test]
    public void medicationDosingFrequencyValid()
    {
        medication.DosingFrequency = validLow;
        Assert.AreEqual(validLow, medication.DosingFrequency);

        medication.DosingFrequency = validMid;
        Assert.AreEqual(validMid, medication.DosingFrequency);

        medication.DosingFrequency = validHigh;
        Assert.AreEqual(validHigh, medication.DosingFrequency);

    }

    [Test]
    public void medicationDosingFrequencyInValid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.DosingFrequency = invalidEmpty);
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.DosingFrequency = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => medication.DosingFrequency = null);
    }

    //Quantity
    [Test]
    public void medicationQuantityValid()
    {
        medication.Quantity = intValidLow;
        Assert.AreEqual(intValidLow, medication.Quantity);

        medication.Quantity = intValidMid;
        Assert.AreEqual(intValidMid, medication.Quantity);

        medication.Quantity = intValidHigh;
        Assert.AreEqual(intValidHigh, medication.Quantity);

    }

    [Test]
    public void medicationQuantityInValid()
    {
        Assert.Throws<ArgumentException>(() => medication.Quantity = intBadLow);
        Assert.Throws<ArgumentException>(() => medication.Quantity = intBadHigh);
    }

    //Bnf Labels
    [Test]
    public void medicationBnfLabelsValid()
    {
        medication.BnfLabels = vaildEmpty;
        Assert.AreEqual(vaildEmpty, medication.BnfLabels);

        medication.BnfLabels = validMid;
        Assert.AreEqual(validMid, medication.BnfLabels);

        medication.BnfLabels = validHigh;
        Assert.AreEqual(validHigh, medication.BnfLabels);

    }

    [Test]
    public void medicationBnfLabelsInValid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => medication.BnfLabels = invalidHigh);
    }

}
