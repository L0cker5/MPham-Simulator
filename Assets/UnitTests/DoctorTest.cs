using NUnit.Framework;
using System;

public class DoctorTest
{
    string validLow, validMid, validHigh;
    string invalidLow, invalidHigh;
    string validPostcode, validPostcodeSix, invalidPostcode, invalidEmptyPostcode;

    Doctor doctor;

    [SetUp]
    public void Setup()
    {
        validLow = "a"; //1
        validMid = "abcdefghijklmnopqrstuvwxyz"; // 26
        validHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx"; //50
        invalidLow = ""; // empty string
        invalidHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxy"; //51

        validPostcode = "BT20 3RU";
        validPostcodeSix = "BT2 3RU";
        invalidPostcode = "BT2 03RU";
        invalidEmptyPostcode = "";

        doctor = new Doctor(validLow, validMid, validHigh, validMid, validLow, validPostcode);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void testDoctorConstructorValid()

    {
        Assert.AreEqual(validLow, doctor.Name);
        Assert.AreEqual(validMid, doctor.Signature);
        Assert.AreEqual(validHigh, doctor.HealthCentre);
        Assert.AreEqual(validMid, doctor.AddressLineOne);
        Assert.AreEqual(validLow, doctor.City);
        Assert.AreEqual(validPostcode, doctor.Postcode);
    }

    [Test]
    public void testDoctorConstructorInValid()

    {
        Assert.Throws<ArgumentException>(() => new Doctor(invalidLow, validMid, validHigh, validMid, validLow, validPostcode));
        Assert.Throws<ArgumentException>(() => new Doctor(validLow, invalidLow, validHigh, validMid, validLow, validPostcodeSix));
        Assert.Throws<ArgumentException>(() => new Doctor(validLow, validMid, invalidHigh, validMid, validLow, validPostcode));
        Assert.Throws<ArgumentException>(() => new Doctor(validLow, validMid, validHigh, invalidLow, validLow, validPostcodeSix));
        Assert.Throws<ArgumentException>(() => new Doctor(validLow, validMid, validHigh, validMid, invalidHigh, validPostcode));
        Assert.Throws<ArgumentException>(() => new Doctor(validLow, validMid, validHigh, validMid, validLow, invalidPostcode));
    }


    [Test]
    public void doctorNameValid()
    {
        doctor.Name = validLow;
        Assert.AreEqual(validLow, doctor.Name);

        doctor.Name = validMid;
        Assert.AreEqual(validMid, doctor.Name);

        doctor.Name = validHigh;
        Assert.AreEqual(validHigh, doctor.Name);

    }

    [Test]
    public void doctorNameInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.Name = invalidLow);
        Assert.Throws<ArgumentException>(() => doctor.Name = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => doctor.Name = null);

    }

    [Test]
    public void testDoctorNameNull()
    {
        //var ex = Assert.Throws<ArgumentNullException>(() => doctor.Name = null);
        Assert.Throws<ArgumentNullException>(() => doctor.Name = null);

        //Assert.AreEqual(ex.Message, "Doctor name cannot be null");
    }

    [Test]
    public void doctorSignatureValid()
    {
        doctor.Signature = validLow;
        Assert.AreEqual(validLow, doctor.Signature);

        doctor.Signature = validMid;
        Assert.AreEqual(validMid, doctor.Signature);

        doctor.Signature = validHigh;
        Assert.AreEqual(validHigh, doctor.Signature);

    }

    [Test]
    public void doctorSignatureInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.Signature = invalidLow);
        Assert.Throws<ArgumentException>(() => doctor.Signature = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => doctor.Signature = null);

    }

    [Test]
    public void doctorHealthCentreValid()
    {
        doctor.HealthCentre = validLow;
        Assert.AreEqual(validLow, doctor.HealthCentre);

        doctor.HealthCentre = validMid;
        Assert.AreEqual(validMid, doctor.HealthCentre);

        doctor.HealthCentre = validHigh;
        Assert.AreEqual(validHigh, doctor.HealthCentre);

    }

    [Test]
    public void doctorHealthCentreInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.HealthCentre = invalidLow);
        Assert.Throws<ArgumentException>(() => doctor.HealthCentre = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => doctor.HealthCentre = null);

    }

    [Test]
    public void doctorAddressLineOneValid()
    {
        doctor.AddressLineOne = validLow;
        Assert.AreEqual(validLow, doctor.AddressLineOne);

        doctor.AddressLineOne = validMid;
        Assert.AreEqual(validMid, doctor.AddressLineOne);

        doctor.AddressLineOne = validHigh;
        Assert.AreEqual(validHigh, doctor.AddressLineOne);

    }

    [Test]
    public void doctorAddressLineOneInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.AddressLineOne = invalidLow);
        Assert.Throws<ArgumentException>(() => doctor.AddressLineOne = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => doctor.AddressLineOne = null);

    }

    [Test]
    public void doctorCityValid()
    {
        doctor.City = validLow;
        Assert.AreEqual(validLow, doctor.City);

        doctor.City = validMid;
        Assert.AreEqual(validMid, doctor.City);

        doctor.City = validHigh;
        Assert.AreEqual(validHigh, doctor.City);

    }

    [Test]
    public void doctorCityInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.City = invalidLow);
        Assert.Throws<ArgumentException>(() => doctor.City = invalidHigh);
        Assert.Throws<ArgumentNullException>(() => doctor.City = null);

    }

    [Test]
    public void doctorPostcodeValid()
    {
        doctor.Postcode = validPostcode;
        Assert.AreEqual(validPostcode, doctor.Postcode);

        doctor.Postcode = validPostcodeSix;
        Assert.AreEqual(validPostcodeSix, doctor.Postcode);
    }

    [Test]
    public void doctorPostcodeInValid()
    {
        Assert.Throws<ArgumentException>(() => doctor.Postcode = invalidPostcode);
        Assert.Throws<ArgumentException>(() => doctor.Postcode = invalidEmptyPostcode);
        Assert.Throws<ArgumentNullException>(() => doctor.Postcode = null);

    }

}
