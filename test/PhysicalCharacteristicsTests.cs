/*
GHOSTS ANIMATOR
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon® and CERT® are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0930
*/

using System;
using Ghosts.Animator.Enums;
using Ghosts.Animator.Models;
using NUnit.Framework;

namespace Ghosts.Animator.Tests
{
    [TestFixture]
    public class PhysicalCharacteristicsTests
    {
        [Test]
        public void Sex_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetBiologicalSex());
        }
        [Test]
        public void Mil_Sex_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetMilBiologicalSex());
        }

        [Test]
        public void Birthdate_Is_A_Valid_Date()
        {
            var birthday = PhysicalCharacteristics.GetBirthdate();
            Assert.IsInstanceOf<System.DateTime>(birthday);
            Assert.True((DateTime.Now.Year - birthday.Year) > 17);
        }
        
        [Test]
        public void Height_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetHeight());
            Assert.IsNotNull(PhysicalCharacteristics.GetHeight(BiologicalSex.Male));
            Assert.IsNotNull(PhysicalCharacteristics.GetHeight(BiologicalSex.Female));
        }

        [Test]
        public void Mil_Height_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetMilHeight());
            Assert.IsNotNull(PhysicalCharacteristics.GetMilHeight(MilitaryBranch.USMC));
            Assert.IsNotNull(PhysicalCharacteristics.GetMilHeight(BiologicalSex.Male));
            Assert.IsNotNull(PhysicalCharacteristics.GetMilHeight(BiologicalSex.Female));
        }

        [Test]
        public void Mil_Height_Is_Above_Bound()
        {
            for (int i = 0; i < 500; i++)
            {
                Assert.GreaterOrEqual(80, PhysicalCharacteristics.GetMilHeight());
                Assert.GreaterOrEqual(78, PhysicalCharacteristics.GetMilHeight(BiologicalSex.Male, MilitaryBranch.USMC));
                Assert.GreaterOrEqual(72, PhysicalCharacteristics.GetMilHeight(BiologicalSex.Female, MilitaryBranch.USMC));
            }
        }
        [Test]
        public void Mil_Height_Is_Below_Bound()
        {
            for (int i = 0; i < 500; i++)
            {
                Assert.LessOrEqual(60, PhysicalCharacteristics.GetMilHeight(BiologicalSex.Male));
                Assert.LessOrEqual(58, PhysicalCharacteristics.GetMilHeight(BiologicalSex.Female));
                Assert.LessOrEqual(58, PhysicalCharacteristics.GetMilHeight(MilitaryBranch.USMC));
            }
        }

        [Test]
        public void Weight_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetWeight(66));
            Assert.IsNotNull(PhysicalCharacteristics.GetWeight(66, BiologicalSex.Male));
            Assert.IsNotNull(PhysicalCharacteristics.GetWeight(66, BiologicalSex.Female));
        }

        [Test]
        public void Mil_Weight_Is_Not_Null()
        {
            Assert.IsNotNull(PhysicalCharacteristics.GetMilWeight(70, new DateTime(2000, 4, 1)));
        }
        
        [Test]
        public void Blood_Type_Is_A_Non_Empty_String()
        {
            Assert.IsNotEmpty(PhysicalCharacteristics.GetBloodType());
        }

        [Test]
        public void Height_To_String_Works()
        {
            Assert.AreEqual("5' 10\"", PhysicalCharacteristics.HeightToString(70));
        }

        [Test]
        public void Weight_To_String_Works()
        {
            Assert.AreEqual("100 lbs", PhysicalCharacteristics.WeightToString(100));
        }
    }
}