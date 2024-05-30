using NUnit.Framework;
using System;

public class PatientTest
{
    string validLow, validMid, validHigh;
    string invalidLow, invalidHigh;
    DateTime validDateOfBirth ,  validMaxDate , vaildMinDate;

    Patient patient;

    [SetUp]
    public void Setup()
    {
        validLow = "a"; //1
        validMid = "abcdefghijklmnopqrstuvwxyz"; // 26
        validHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx"; //50
        invalidLow = ""; // empty string
        invalidHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxy"; //51

        validDateOfBirth = DateTime.MinValue;
        vaildMinDate = DateTime.MinValue;
        validMaxDate = DateTime.MinValue;

        patient = new Patient(validLow, validMid, validHigh, validDateOfBirth);
    }

    [Test]
    public void testPatientConstructorValid()
    {
        Assert.AreEqual(validLow, patient.Name);
        Assert.AreEqual(validMid, patient.Address);
        Assert.AreEqual(validHigh, patient.City);
        Assert.AreEqual(validDateOfBirth, patient.DateOfBirth);
    }

    [Test]
    public void testPatientConstructorInValid()

    {
        Assert.Throws<ArgumentException>(() => new Patient(invalidLow, validMid, validHigh, validDateOfBirth));
        Assert.Throws<ArgumentException>(() => new Patient(validLow, invalidHigh, validHigh, validDateOfBirth));
        Assert.Throws<ArgumentException>(() => new Patient(validLow, validMid, invalidLow, validDateOfBirth));
    }

    [Test]
    public void patientNameValid()
    {
        patient.Name = validLow;
        Assert.AreEqual(validLow, patient.Name);

        patient.Name = validMid;
        Assert.AreEqual(validMid, patient.Name);

        patient.Name = validHigh;
        Assert.AreEqual(validHigh, patient.Name);

    }

    [Test]
    public void doctorNameInValid()
    {
        Assert.Throws<ArgumentException>(() => patient.Name = invalidLow);
        Assert.Throws<ArgumentException>(() => patient.Name = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => patient.Name = null);

    }

    [Test]
    public void patientAddressValid()
    {
        patient.Address = validLow;
        Assert.AreEqual(validLow, patient.Address);

        patient.Address = validMid;
        Assert.AreEqual(validMid, patient.Address);

        patient.Address = validHigh;
        Assert.AreEqual(validHigh, patient.Address);

    }

    [Test]
    public void doctorAddressInValid()
    {
        Assert.Throws<ArgumentException>(() => patient.Address = invalidLow);
        Assert.Throws<ArgumentException>(() => patient.Address = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => patient.Address = null);

    }

    [Test]
    public void patientCityValid()
    {
        patient.City = validLow;
        Assert.AreEqual(validLow, patient.City);

        patient.City = validMid;
        Assert.AreEqual(validMid, patient.City);

        patient.City = validHigh;
        Assert.AreEqual(validHigh, patient.City);

    }

    [Test]
    public void doctorCityInValid()
    {
        Assert.Throws<ArgumentException>(() => patient.City = invalidLow);
        Assert.Throws<ArgumentException>(() => patient.City = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => patient.City = null);

    }

    [Test]
    public void patientDateOfBirthValid()
    {
        patient.DateOfBirth = validDateOfBirth;
        Assert.AreEqual(validDateOfBirth, patient.DateOfBirth);

        patient.DateOfBirth = vaildMinDate;
        Assert.AreEqual(vaildMinDate, patient.DateOfBirth);

        patient.DateOfBirth = validMaxDate;
        Assert.AreEqual(validMaxDate, patient.DateOfBirth);

    }
    
    //[Test]
    //public void doctorDateOfBirthInValid()
    //{
    //    DateTime invaildDate = new DateTime(30,02,2020);


    //    Assert.Throws<ArgumentOutOfRangeException>(() => patient.DateOfBirth = invaildDate);
    //}

}
