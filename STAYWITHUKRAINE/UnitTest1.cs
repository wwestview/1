using System;
using Xunit;
using Fractional;
namespace STAYWITHUKRAINE
{
    public class TestingToStringWithIntPart
    {
        [Fact]
        public void TheFirstValueIsMinus()
        {
            Frac frac = new Frac();
            var myFrac = new Frac.MyFrac(-1, 315);
            string actual = frac.ToStringWithIntPart(myFrac);
            string expected = "-(1/315)";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TheSecondValueIsMinus()
        {
            Frac frac = new Frac();
            var myFrac = new Frac.MyFrac(1, -315);
            string actual = frac.ToStringWithIntPart(myFrac);
            string expected = "-(1/315)";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void MixedFrac()
        {
            Frac frac = new Frac();
            var myFrac = new Frac.MyFrac(14, 9);
            string actual = frac.ToStringWithIntPart(myFrac);
            string expected = "(1+5/9)";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void IntValue()
        {
            Frac frac = new Frac();
            var myFrac = new Frac.MyFrac(12, 4);
            string actual = frac.ToStringWithIntPart(myFrac);
            string expected = "(3)";
            Assert.Equal(expected, actual);
        }
       
      
    }
}