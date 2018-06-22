using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Infrastructure.Utility;
using Xunit;

namespace App.Module32.Tests
{
    public class LevenshteinTest
    {
        [Fact]
        public void EqualStringsNoEdits()
        {
            Assert.Equal(0, LevenshteinDistance.Compute("test", "test"));
        }

        [Fact]
        public void Additions()
        {
            Assert.Equal(1, LevenshteinDistance.Compute("test", "tests"));
            Assert.Equal(1, LevenshteinDistance.Compute("test", "stest"));
            Assert.Equal(2, LevenshteinDistance.Compute("test", "mytest"));
            Assert.Equal(7, LevenshteinDistance.Compute("test", "mycrazytest"));
        }

        [Fact]
        public void AdditionsPrependAndAppend()
        {
            Assert.Equal(9, LevenshteinDistance.Compute("test", "mytestiscrazy"));
        }

        [Fact]
        public void AdditionOfRepeatedCharacters()
        {
            Assert.Equal(1, LevenshteinDistance.Compute("test", "teest"));
        }

        [Fact]
        public void Deletion()
        {
            Assert.Equal(1, LevenshteinDistance.Compute("test", "tst"));
        }

        [Fact]
        public void Transposition()
        {
            Assert.Equal(1, LevenshteinDistance.Compute("test", "tset"));
        }

        [Fact]
        public void AdditionWithTransposition()
        {
            Assert.Equal(2, LevenshteinDistance.Compute("test", "tsets"));
        }

        [Fact]
        public void TranspositionOfRepeatedCharacters()
        {
            Assert.Equal(1, LevenshteinDistance.Compute("banana", "banaan"));
            Assert.Equal(1, LevenshteinDistance.Compute("banana", "abnana"));
            Assert.Equal(2, LevenshteinDistance.Compute("banana", "baanaa"));
        }

        [Fact]
        public void EmptyStringsNoEdits()
        {
            Assert.Equal(0, LevenshteinDistance.Compute("", ""));
        }


    }
}
