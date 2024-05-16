using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PatientTest
{
    string validLow, validMid, validHigh;
    string invalidLow, invalidHigh;
    string validDate;
    DateTime validDateOfBirth, invalidDateOfBirth;

    Patient patient;

    [SetUp]
    public void Setup()
    {
        validLow = "a"; //1
        validMid = "abcdefghijklmnopqrstuvwxyz"; // 26
        validHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwx"; //50
        invalidLow = ""; // empty string
        invalidHigh = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxy"; //51

        validDateOfBirth = new DateTime(29, 04, 1928, 00,00,00);
        invalidDateOfBirth = new DateTime(2020, 02, 30);

        patient = new Patient(validLow, validMid, invalidHigh, validDateOfBirth);
    }

    [Test]
    public void testPatientConstructorValid()
    {
        Assert.AreEqual(validLow, patient.Name);
        Assert.AreEqual(validMid, patient.Address);
        Assert.AreEqual(validHigh, patient.City);
        Assert.AreEqual(validDateOfBirth, patient.DateOfBirth);
    }
}
